using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjReversingPuzzleSolver.Forms
{

    /// <summary>
    /// 【反転方式】
    /// </summary>
    public enum Enum_TurnMode
    {
        /// <summary>
        /// 【自分だけ】
        /// </summary>
        Self=0,

        /// <summary>
        /// 【十字形】
        /// </summary>
        Cross=4,

        /// <summary>
        /// 【3×3】
        /// </summary>
        Square=8
    }

    /// <summary>
    /// 【盤面】
    /// </summary>
    public partial class uclBoard : UserControl
    {
        /// <summary>
        /// 【ボタン同士の間隔】
        /// </summary>
        private const int M_INT_LEN_BETWEEN_BUTTONS = 2;

        #region ●valuables

        /// <summary>
        /// 【盤面幅】
        /// </summary>
        private int m_intWidth;

        /// <summary>
        /// 【盤面高さ】
        /// </summary>
        private int m_intHeight;

        /// <summary>
        /// 【色の最大値】
        /// </summary>
        private int m_intMaxColorNumber;

        /// <summary>
        /// 【ボタン配列】
        /// </summary>
        private Classes.clsArray<clsIntButton> m_insBtnArray;

        /// <summary>
        /// 【反転方法】
        /// </summary>
        private Enum_TurnMode m_enmTurnMode;

        #endregion

        #region ●Property

        /// <summary>
        /// 【反転方法】
        /// </summary>
        public Enum_TurnMode enmTurnMode
        {
            get { return this.m_enmTurnMode; }
            set { this.m_enmTurnMode = value; }
        }

        #endregion

        #region ●初期化

        /// <summary>
        /// 【初期化】
        /// </summary>
        /// <param name="intWidth"></param>
        /// <param name="intHeight"></param>
        /// <param name="intMax"></param>
        public void subInit(int intWidth,int intHeight,int intMax)
        {            
            this.m_intWidth = intWidth;
            this.m_intHeight = intHeight;
            this.m_intMaxColorNumber = intMax;

            this.Width = Classes.clsConfig.intPixelSize * intWidth + M_INT_LEN_BETWEEN_BUTTONS * (intWidth - 1);
            this.Height = Classes.clsConfig.intPixelSize * intHeight + M_INT_LEN_BETWEEN_BUTTONS * (intHeight - 1);

            //ボタン作成
            this.m_subCreateButtons();
        }

        /// <summary>
        /// 【ボタン作成】
        /// </summary>
        private void m_subCreateButtons()
        {
            //ボタン作成
            this.m_insBtnArray = new Classes.clsArray<clsIntButton>(this.m_intWidth, this.m_intHeight);

            for (int i = 0; i < this.m_intHeight; i++)
            {
                for (int j = 0; j < this.m_intWidth; j++)
                {
                    int num = i * this.m_intWidth + j;
                    this.m_insBtnArray[num] = new clsIntButton();
                    var insBtn = this.m_insBtnArray[num];
                    insBtn.Name = "btn" + num;
                    insBtn.Width = Classes.clsConfig.intPixelSize;
                    insBtn.Height = insBtn.Width;
                    insBtn.TabIndex = num;
                    insBtn.Location = new Point(j * (insBtn.Width + M_INT_LEN_BETWEEN_BUTTONS), i * (insBtn.Height + M_INT_LEN_BETWEEN_BUTTONS));
                    insBtn.Click += this.m_btnXXX_Click;
                    insBtn.Enter += this.m_btnXXX_Enter;
                    insBtn.PreviewKeyDown += this.m_btnXXX_PreviewKeyDown;

                    insBtn.subInit(this.m_intMaxColorNumber, Classes.clsConfig.lstColor);

                    this.Controls.Add(insBtn);
                }
            }

            //先頭のTabstopのみTrue
            this.m_insBtnArray[0].TabStop = true;

        }

        #endregion

        #region ●Button関連イベント

        /// <summary>
        /// 【Click】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnXXX_Click(object sender,EventArgs e)
        {
            //座標解析
            var insBtn = (clsIntButton)sender;
            int x = insBtn.TabIndex % this.m_intWidth;
            int y = insBtn.TabIndex / this.m_intWidth;

            //クリックされたもの自身は自分で値を処理しているので無視

            if (this.enmTurnMode== Enum_TurnMode.Cross||this.enmTurnMode== Enum_TurnMode.Square){
                if (y > 0) this.m_insBtnArray[y - 1, x].intValue++;                     //上
                if (y < this.m_intHeight - 1) this.m_insBtnArray[y + 1, x].intValue++;  //下
                if (x > 0) this.m_insBtnArray[y, x - 1].intValue++;                     //左
                if (x < this.m_intWidth - 1) this.m_insBtnArray[y, x + 1].intValue++;   //右
            }

            if(this.enmTurnMode== Enum_TurnMode.Square)
            {
                if (y > 0 && x > 0) this.m_insBtnArray[y - 1, x - 1].intValue++;                                        //左上
                if (y > 0 && x < this.m_intWidth - 1) this.m_insBtnArray[y - 1, x + 1].intValue++;                      //右上
                if (y < this.m_intHeight - 1 && x > 0) this.m_insBtnArray[y + 1, x - 1].intValue++;                     //左下
                if (y < this.m_intHeight - 1 && x < this.m_intWidth - 1) this.m_insBtnArray[y + 1, x + 1].intValue++;   //右下
            }
        }

        /// <summary>
        /// 【Enter】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnXXX_Enter(object sender,EventArgs e)
        {
            var insSender = (clsIntButton)sender;
            insSender.TabStop = true;

            //EnterしたButtonのTabStopをTrueにする
            //他のButtonのTabStopはFalseにする
            for (int i = 0; i < this.m_insBtnArray.intLen; i++) this.m_insBtnArray[i].TabStop = false;
            insSender.TabStop = true;
        }

        /// <summary>
        /// 【PreviewKeyDown（上下左右キーでの移動）】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnXXX_PreviewKeyDown(object sender,PreviewKeyDownEventArgs e)
        {
            int index = ((clsIntButton)sender).TabIndex;
            int x = index % this.m_intWidth;
            int y = index / this.m_intWidth;

            //e.handled=trueできないので、もともとの上下左右キー動作で移動する分も考慮して移動する
            switch (e.KeyCode)
            {
                case Keys.Left:
                    //一番左の列にいた場合は、一つ右に移動して相殺
                    //それ以外は何もしない
                    if (x == 0) this.ActiveControl = this.m_insBtnArray[index + 1];
                    break;

                case Keys.Right:
                    //一番右の列にいた場合は、一つ左に移動して相殺
                    //それ以外は何もしない
                    if (x == this.m_intWidth - 1) this.ActiveControl = this.m_insBtnArray[index - 1];
                    break;

                case Keys.Up:
                    //一番上の行にいた場合は、一つ後ろに移動して相殺
                    //それ以外の行では、真上の一つ手前に移動
                    if (y == 0) this.ActiveControl = this.m_insBtnArray[index + 1];
                    else this.ActiveControl = this.m_insBtnArray[index - this.m_intWidth + 1];
                    break;

                case Keys.Down:
                    //一番下の行にいた場合は、一つ前に移動して相殺
                    //それ以外の行では、真下の一つ手前に移動
                    if (y == this.m_intHeight - 1) this.ActiveControl = this.m_insBtnArray[index - 1];
                    else this.ActiveControl = this.m_insBtnArray[index + this.m_intWidth - 1];
                    break;
            }
        }

        #endregion

        #region ●処理

        /// <summary>
        /// 【データ画面反映】
        /// </summary>
        /// <param name="insArray"></param>
        public void subShowData(Classes.clsIntArray insArray)
        {
            for(int i = 0; i < insArray.intLen; i++)
            {
                this.m_insBtnArray[i].intValue = insArray[i];
            }
        }

        /// <summary>
        /// 【盤面データを取得】
        /// </summary>
        /// <returns></returns>
        public Classes.clsIntArray insGetData()
        {

            var insArray = new Classes.clsIntArray(this.m_intWidth, this.m_intHeight,this.m_intMaxColorNumber);

            for(int y = 0; y < this.m_intHeight; y++)
            {
                for(int x = 0; x < this.m_intWidth; x++)
                {
                    insArray[y, x] = this.m_insBtnArray[this.m_intWidth * y + x].intValue;
                }
            }

            return insArray;
        }

        #endregion

        #region ●ボタンクラス

        /// <summary>
        /// 【Intで値を保持するボタン】
        /// </summary>
        private class clsIntButton : Button
        {

            /// <summary>
            /// 【内部値】
            /// </summary>
            private int m_intValue;

            /// <summary>
            /// 【色数】
            /// </summary>
            private int m_intColors;

            /// <summary>
            /// 【色リスト】
            /// </summary>
            private List<Color> m_lstColors;

            /// <summary>
            /// 【値の取得・設定】
            /// </summary>
            public int intValue
            {
                get { return this.m_intValue; }
                set
                {
                    this.m_intValue = value % this.m_intColors;
                    this.m_subChangeColor();
                }
            }

            /// <summary>
            /// 【色数】
            /// </summary>
            public int intMaxColors
            {
                get { return this.m_intColors; }
            }

            /// <summary>
            /// 【New】
            /// </summary>
            public clsIntButton()
            {
                this.m_intValue = 0;
                this.m_intColors = 1;

                this.BackColor = Color.White;
                this.AutoSize = false;
                this.Font = new Font("MS UI Gothic", 8);
                this.TabStop = false;
            }

            /// <summary>
            /// 【初期化】
            /// </summary>
            /// <param name="intColors">色数</param>
            /// <param name="lstColors">色リスト</param>
            public void subInit(int intColors, List<Color> lstColors)
            {
                this.m_intColors = intColors;
                this.m_lstColors = lstColors;

                this.m_subChangeColor();
            }

            /// <summary>
            /// 【色変更】
            /// </summary>
            private void m_subChangeColor()
            {
                this.BackColor = this.m_lstColors[this.m_intValue];
            }

            /// <summary>
            /// 【クリック時処理】
            /// </summary>
            /// <param name="e"></param>
            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                this.intValue++;
                this.m_subChangeColor();
            }

            /// <summary>
            /// 【OnLeave】
            /// </summary>
            /// <param name="e"></param>
            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);
                this.ForeColor = SystemColors.Control;
            }

            /// <summary>
            /// 【OnEnter】
            /// </summary>
            /// <param name="e"></param>
            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                this.ForeColor = Color.MediumBlue;
            }
        }

        #endregion

    }

}
