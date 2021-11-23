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
    /// 【メイン】
    /// </summary>
    public partial class frmMain : Form
    {
        #region ●Valuables

        /// <summary>
        /// 【開始時点の状態】
        /// </summary>
        private Classes.clsIntArray m_insInitial;

        /// <summary>
        /// 【終了時点の状態】
        /// </summary>
        private Classes.clsIntArray m_insFinal;

        #endregion

        #region ●Form関連

        /// <summary>
        /// 【New】
        /// </summary>
        public frmMain()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 【Load】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_frmMain_Load(object sender, EventArgs e)
        {
            //コンフィグロード
            Classes.clsConfig.subLoad();

            this.m_subInitComboBox();
            this.m_subSetTabIndex();
            this.m_subAddHandler();

            this.radReverse_UDLR.Checked = true;
        }

        /// <summary>
        /// 【コンボボックス初期化】
        /// </summary>
        private void m_subInitComboBox()
        {

            for(int i = Classes.clsConfig.intMinBoardSize; i <= Classes.clsConfig.intMaxBoardSize; i++)
            {
                this.cmbHeight.Items.Add(i);
                this.cmbWidth.Items.Add(i);
            }

            for(int i = 2; i <= Classes.clsConfig.lstColor.Count; i++)
            {
                this.cmbColor.Items.Add(i);
            }

            this.cmbHeight.SelectedIndex = 0;
            this.cmbWidth.SelectedIndex = 0;
            this.cmbColor.SelectedIndex = 0;
        }

        /// <summary>
        /// 【タブインデックス】
        /// </summary>
        private void m_subSetTabIndex()
        {
            var lstControl = new List<Control>() {
            this.cmbColor,
            this.cmbWidth,
            this.cmbHeight,
            this.btnBoardSetting,
            this.radReverse_UDLR,
            this.radReverse_3by3,
            this.btnStart,
            this.btnClose
            };

            for(int i = 1; i <= lstControl.Count; i++)
            {
                lstControl[i-1].TabIndex = i;
            }
        }

        /// <summary>
        /// 【Enter・Leaveハンドラ追加】
        /// </summary>
        private void m_subAddHandler()
        {
            var lstControl = new List<Control>() {
            this.cmbColor,
            this.cmbWidth,
            this.cmbHeight,
            this.btnBoardSetting,
            this.radReverse_UDLR,
            this.radReverse_3by3,
            this.btnStart,
            this.btnClose
            };

            foreach (var insCtrl in lstControl)
            {
                insCtrl.Enter += this.m_insXXX_Enter;
                insCtrl.Leave += this.m_insXXX_Leave;
            }
        }

        #endregion

        #region ●Button

        /// <summary>
        /// 【終了】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 【開始】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnStart_Click(object sender, EventArgs e)
        {
            var insSolve = new Classes.clsSolve();
            insSolve.insInitial = this.m_insInitial;
            insSolve.insFinal = this.m_insFinal;
            if (this.radReverse_UDLR.Checked) insSolve.enmTurnMode = Enum_TurnMode.Cross;
            else insSolve.enmTurnMode = Enum_TurnMode.Square;

            insSolve.subSolve();
            Classes.clsUtils.blnShowMsgBox("完了", Classes.clsUtils.Enum_MsgBoxStyle.Information);
            //foreach(var insArray in insSolve.lstAns)
            //{
            //    for(int i = 0; i < insArray.intHeight; i++)
            //    {
            //        for(int j = 0; j < insArray.intWidth; j++)
            //        {
            //            Console.Write(insArray[j, i]);
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}
        }

        /// <summary>
        /// 【盤面の設定】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnBoardSetting_Click(object sender, EventArgs e)
        {
            var insBoard = new frmBoard();
            insBoard.enmTurnMode = Enum_TurnMode.Self;
            insBoard.enmUse = frmBoard.Enum_Use.Set;

            if (this.m_insInitial is null)
            {
                //未設定の場合→初期値を投入
                insBoard.insInitial = new Classes.clsIntArray(Convert.ToInt32(this.cmbWidth.SelectedItem), Convert.ToInt32(this.cmbHeight.SelectedItem), Convert.ToInt32(this.cmbColor.SelectedItem));
                insBoard.insFinal = insBoard.insInitial.insCreateCopy();
            }
            else
            {
                //設定済みの場合→既存の設定と画面上のコンボボックス選択が一致しなければ注意メッセージ表示
                if (this.m_insInitial.intWidth != Convert.ToInt32(this.cmbWidth.SelectedItem) ||
                    this.m_insInitial.intHeight != Convert.ToInt32(this.cmbHeight.SelectedItem) ||
                    this.m_insInitial.intBase != Convert.ToInt32(this.cmbColor.SelectedItem))
                {
                    if (!Classes.clsUtils.blnShowMsgBox("色数・幅・高さのうち1つ以上が変更されています。\n設定済の盤面が削除されますが、続行してよいですか？", Classes.clsUtils.Enum_MsgBoxStyle.Question))
                    {
                        insBoard.Dispose();
                        return;
                    }

                    //初期化して渡す
                    insBoard.insInitial = new Classes.clsIntArray(Convert.ToInt32(this.cmbWidth.SelectedItem), Convert.ToInt32(this.cmbHeight.SelectedItem), Convert.ToInt32(this.cmbColor.SelectedItem));
                    insBoard.insFinal = insBoard.insInitial.insCreateCopy();
                }
                else
                {
                    //変更なかった場合は盤面設定渡す
                    insBoard.insInitial = this.m_insInitial.insCreateCopy();
                    insBoard.insFinal = this.m_insFinal.insCreateCopy();
                }
            }

            if (insBoard.ShowDialog() == DialogResult.OK)
            {
                this.m_insInitial = insBoard.insInitial;
                this.m_insFinal = insBoard.insFinal;
                this.lblCurrentSetting.Text = string.Format("色　：{0}色\n幅　：{1}\n高さ：{2}", this.m_insInitial.intBase, this.m_insInitial.intWidth, this.m_insInitial.intHeight);
            }

            insBoard.Dispose();
        }

        /// <summary>
        /// 【テスト用】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnTest_Click(object sender, EventArgs e)
        {
            using(var insForm = new frmTest())
            {
                insForm.subInit(Convert.ToInt32(this.cmbWidth.SelectedItem), Convert.ToInt32(this.cmbHeight.SelectedItem), Convert.ToInt32(this.cmbColor.SelectedItem));
            
                insForm.ShowDialog();

            }
            
        }

        #endregion

        #region ●Enter/Leave

        /// <summary>
        /// Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_insXXX_Enter(object sender, EventArgs e)
        {
            string strName = ((Control)sender).Name;
            var insColor = System.Drawing.Color.MediumBlue;

            if (strName == this.cmbColor.Name) this.lblColors.ForeColor = insColor;
            else if (strName == this.cmbWidth.Name) this.lblWidth.ForeColor = insColor;
            else if (strName == this.cmbHeight.Name) this.lblHeight.ForeColor = insColor;
            else ((Control)sender).ForeColor = insColor;
        }

        /// <summary>
        /// Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_insXXX_Leave(object sender,EventArgs e)
        {
            string strName = ((Control)sender).Name;
            var insColor = System.Drawing.SystemColors.ControlText;
            if (strName == this.cmbColor.Name) this.lblColors.ForeColor = insColor;
            else if (strName == this.cmbWidth.Name) this.lblWidth.ForeColor = insColor;
            else if (strName == this.cmbHeight.Name) this.lblHeight.ForeColor = insColor;
            else ((Control)sender).ForeColor = insColor;
        }

        #endregion

    }
}
