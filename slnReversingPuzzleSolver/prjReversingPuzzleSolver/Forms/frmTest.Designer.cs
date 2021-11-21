
namespace prjReversingPuzzleSolver.Forms
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radNormal = new System.Windows.Forms.RadioButton();
            this.radCross = new System.Windows.Forms.RadioButton();
            this.rad3by3 = new System.Windows.Forms.RadioButton();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.uclBoard = new prjReversingPuzzleSolver.Forms.uclBoard();
            this.pnlBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // radNormal
            // 
            this.radNormal.AutoSize = true;
            this.radNormal.Location = new System.Drawing.Point(15, 21);
            this.radNormal.Name = "radNormal";
            this.radNormal.Size = new System.Drawing.Size(47, 16);
            this.radNormal.TabIndex = 0;
            this.radNormal.TabStop = true;
            this.radNormal.Text = "通常";
            this.radNormal.UseVisualStyleBackColor = true;
            // 
            // radCross
            // 
            this.radCross.AutoSize = true;
            this.radCross.Location = new System.Drawing.Point(94, 21);
            this.radCross.Name = "radCross";
            this.radCross.Size = new System.Drawing.Size(47, 16);
            this.radCross.TabIndex = 1;
            this.radCross.TabStop = true;
            this.radCross.Text = "十字";
            this.radCross.UseVisualStyleBackColor = true;
            // 
            // rad3by3
            // 
            this.rad3by3.AutoSize = true;
            this.rad3by3.Location = new System.Drawing.Point(165, 21);
            this.rad3by3.Name = "rad3by3";
            this.rad3by3.Size = new System.Drawing.Size(47, 16);
            this.rad3by3.TabIndex = 2;
            this.rad3by3.TabStop = true;
            this.rad3by3.Text = "3×3";
            this.rad3by3.UseVisualStyleBackColor = true;
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoard.Controls.Add(this.uclBoard);
            this.pnlBoard.Location = new System.Drawing.Point(12, 43);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(776, 362);
            this.pnlBoard.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(700, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // uclBoard
            // 
            this.uclBoard.enmTurnMode = prjReversingPuzzleSolver.Forms.Enum_TurnMode.Self;
            this.uclBoard.Location = new System.Drawing.Point(3, 3);
            this.uclBoard.Name = "uclBoard";
            this.uclBoard.Size = new System.Drawing.Size(150, 150);
            this.uclBoard.TabIndex = 3;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.rad3by3);
            this.Controls.Add(this.radCross);
            this.Controls.Add(this.radNormal);
            this.MinimizeBox = false;
            this.Name = "frmTest";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "テスト用画面";
            this.pnlBoard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radNormal;
        private System.Windows.Forms.RadioButton radCross;
        private System.Windows.Forms.RadioButton rad3by3;
        private uclBoard uclBoard;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnClose;
    }
}