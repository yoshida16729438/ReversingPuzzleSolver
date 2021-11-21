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
    /// 【盤面設定】
    /// </summary>
    public partial class frmBoard : Form
    {
        #region ●Properties

        /// <summary>
        /// 【開始時点の状態】
        /// </summary>
        public Classes.clsIntArray insInitial
        {
            get;set;
        }

        /// <summary>
        /// 【終了時点の状態】
        /// </summary>
        public Classes.clsIntArray insFinal
        {
            get;set;
        }

        /// <summary>
        /// 【反転モード】
        /// </summary>
        public Enum_TurnMode enmTurnMode
        {
            get;set;
        }

        /// <summary>
        /// 【画面表示用途】
        /// </summary>
        public Enum_Use enmUse
        {
            get;set;
        }

        #endregion

        #region ●Enum

        /// <summary>
        /// 【表示用途】
        /// </summary>
        public enum Enum_Use
        {
            /// <summary>
            /// 【設定】
            /// </summary>
            Set,

            /// <summary>
            /// 【結果】
            /// </summary>
            Result
        }

        #endregion

        #region ●初期化

        /// <summary>
        /// 【New】
        /// </summary>
        public frmBoard()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 【Load】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_frmBoard_Load(object sender, EventArgs e)
        {
            //未設定対策
            if (this.insInitial is null) return;

            this.uclBoard_Left.subInit(this.insInitial.intWidth, this.insInitial.intHeight, this.insInitial.intBase);
            this.uclBoard_Right.subInit(this.insFinal.intWidth, this.insFinal.intHeight, this.insFinal.intBase);

            this.uclBoard_Left.enmTurnMode = this.enmTurnMode;
            this.uclBoard_Right.enmTurnMode = this.enmTurnMode;

            this.Size = new Size(this.Width - this.pnlBoard.Width + this.uclBoard_Left.Width * 2 + 20, this.Height - this.pnlBoard.Height + this.uclBoard_Left.Height+20);
            this.MinimumSize = this.Size;
            this.CenterToParent();
            this.uclBoard_Right.Location =new Point( this.uclBoard_Left.Location.X + this.uclBoard_Left.Width+10,this.uclBoard_Left.Location.Y);

            this.uclBoard_Left.subShowData(this.insInitial);
            this.uclBoard_Right.subShowData(this.insFinal);

            if (this.enmUse == Enum_Use.Result)
            {
                this.uclBoard_Left.Enabled = false;
                this.Text = "結果";
                this.btnOK.Visible = false;
                this.btnCancel.Text = "閉じる";
            }
        }

        #endregion

        #region ●Button

        /// <summary>
        /// 【OK】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            this.insInitial = this.uclBoard_Left.insGetData();
            this.insFinal = this.uclBoard_Right.insGetData();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        /// <summary>
        /// 【FormClosing】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_frmBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.enmUse== Enum_Use.Set && this.DialogResult != DialogResult.OK)
            {
                if (!Classes.clsUtils.blnShowMsgBox("編集が保存されません。取り消してよろしいですか？", Classes.clsUtils.Enum_MsgBoxStyle.Question))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
