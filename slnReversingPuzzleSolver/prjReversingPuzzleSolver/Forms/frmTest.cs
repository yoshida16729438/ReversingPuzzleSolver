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
    /// 【テスト用フォーム】
    /// </summary>
    public partial class frmTest : Form
    {

        /// <summary>
        /// 【New】
        /// </summary>
        public frmTest()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 【初期化】
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void subInit(int width, int height, int color)
        {
            //ucl初期化
            this.uclBoard.subInit(width, height, color);

            //サイズ設定
            this.pnlBoard.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.pnlBoard.Size = new Size(this.uclBoard.Width + 10, this.uclBoard.Height + 6);
            this.Size = new Size(Math.Max(this.pnlBoard.Width + 40, 250), 130 + this.pnlBoard.Height);
            this.pnlBoard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            this.MinimumSize = this.Size;
            this.CenterToParent();

            //ラジオボタンイベント設定
            this.radNormal.CheckedChanged += this.m_radXXX_CheckedChanged;
            this.radCross.CheckedChanged += this.m_radXXX_CheckedChanged;
            this.rad3by3.CheckedChanged += this.m_radXXX_CheckedChanged;

            this.radNormal.Checked = true;
        }

        /// <summary>
        /// 【CheckedChanged】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_radXXX_CheckedChanged(object sender,EventArgs e)
        {
            if (this.radNormal.Checked) this.uclBoard.enmTurnMode = Enum_TurnMode.Self;
            if (this.radCross.Checked) this.uclBoard.enmTurnMode = Enum_TurnMode.Cross;
            if (this.rad3by3.Checked) this.uclBoard.enmTurnMode = Enum_TurnMode.Square;
        }
    }
}
