
namespace prjReversingPuzzleSolver.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWidth = new System.Windows.Forms.Label();
            this.cmbWidth = new System.Windows.Forms.ComboBox();
            this.cmbHeight = new System.Windows.Forms.ComboBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.lblColors = new System.Windows.Forms.Label();
            this.lblCurrentSetting_Ex = new System.Windows.Forms.Label();
            this.lblCurrentSetting = new System.Windows.Forms.Label();
            this.btnBoardSetting = new System.Windows.Forms.Button();
            this.lblReverseType = new System.Windows.Forms.Label();
            this.radReverse_UDLR = new System.Windows.Forms.RadioButton();
            this.radReverse_3by3 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWidth.Location = new System.Drawing.Point(12, 59);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(109, 19);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "盤面の幅：";
            // 
            // cmbWidth
            // 
            this.cmbWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWidth.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbWidth.FormattingEnabled = true;
            this.cmbWidth.Location = new System.Drawing.Point(147, 56);
            this.cmbWidth.Name = "cmbWidth";
            this.cmbWidth.Size = new System.Drawing.Size(105, 27);
            this.cmbWidth.TabIndex = 1;
            // 
            // cmbHeight
            // 
            this.cmbHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeight.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbHeight.FormattingEnabled = true;
            this.cmbHeight.Location = new System.Drawing.Point(147, 89);
            this.cmbHeight.Name = "cmbHeight";
            this.cmbHeight.Size = new System.Drawing.Size(105, 27);
            this.cmbHeight.TabIndex = 3;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHeight.Location = new System.Drawing.Point(12, 92);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(129, 19);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "盤面の高さ：";
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(147, 23);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(105, 27);
            this.cmbColor.TabIndex = 5;
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblColors.Location = new System.Drawing.Point(12, 26);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(69, 19);
            this.lblColors.TabIndex = 4;
            this.lblColors.Text = "色数：";
            // 
            // lblCurrentSetting_Ex
            // 
            this.lblCurrentSetting_Ex.AutoSize = true;
            this.lblCurrentSetting_Ex.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCurrentSetting_Ex.Location = new System.Drawing.Point(14, 129);
            this.lblCurrentSetting_Ex.Name = "lblCurrentSetting_Ex";
            this.lblCurrentSetting_Ex.Size = new System.Drawing.Size(129, 19);
            this.lblCurrentSetting_Ex.TabIndex = 6;
            this.lblCurrentSetting_Ex.Text = "現在の設定：";
            // 
            // lblCurrentSetting
            // 
            this.lblCurrentSetting.AutoSize = true;
            this.lblCurrentSetting.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCurrentSetting.Location = new System.Drawing.Point(143, 129);
            this.lblCurrentSetting.Name = "lblCurrentSetting";
            this.lblCurrentSetting.Size = new System.Drawing.Size(129, 57);
            this.lblCurrentSetting.TabIndex = 7;
            this.lblCurrentSetting.Text = "色　：－－色\r\n幅　：－－\r\n高さ：－－";
            // 
            // btnBoardSetting
            // 
            this.btnBoardSetting.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBoardSetting.Location = new System.Drawing.Point(102, 189);
            this.btnBoardSetting.Name = "btnBoardSetting";
            this.btnBoardSetting.Size = new System.Drawing.Size(128, 46);
            this.btnBoardSetting.TabIndex = 8;
            this.btnBoardSetting.Text = "盤面の設定へ";
            this.btnBoardSetting.UseVisualStyleBackColor = true;
            this.btnBoardSetting.Click += new System.EventHandler(this.m_btnBoardSetting_Click);
            // 
            // lblReverseType
            // 
            this.lblReverseType.AutoSize = true;
            this.lblReverseType.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblReverseType.Location = new System.Drawing.Point(14, 248);
            this.lblReverseType.Name = "lblReverseType";
            this.lblReverseType.Size = new System.Drawing.Size(109, 19);
            this.lblReverseType.TabIndex = 9;
            this.lblReverseType.Text = "反転種別：";
            // 
            // radReverse_UDLR
            // 
            this.radReverse_UDLR.AutoSize = true;
            this.radReverse_UDLR.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radReverse_UDLR.Location = new System.Drawing.Point(147, 246);
            this.radReverse_UDLR.Name = "radReverse_UDLR";
            this.radReverse_UDLR.Size = new System.Drawing.Size(107, 23);
            this.radReverse_UDLR.TabIndex = 10;
            this.radReverse_UDLR.TabStop = true;
            this.radReverse_UDLR.Text = "上下左右";
            this.radReverse_UDLR.UseVisualStyleBackColor = true;
            // 
            // radReverse_3by3
            // 
            this.radReverse_3by3.AutoSize = true;
            this.radReverse_3by3.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radReverse_3by3.Location = new System.Drawing.Point(260, 246);
            this.radReverse_3by3.Name = "radReverse_3by3";
            this.radReverse_3by3.Size = new System.Drawing.Size(67, 23);
            this.radReverse_3by3.TabIndex = 11;
            this.radReverse_3by3.TabStop = true;
            this.radReverse_3by3.Text = "3×3";
            this.radReverse_3by3.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStart.Location = new System.Drawing.Point(66, 285);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 46);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.m_btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(171, 285);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 46);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(249, 204);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 341);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.radReverse_3by3);
            this.Controls.Add(this.radReverse_UDLR);
            this.Controls.Add(this.lblReverseType);
            this.Controls.Add(this.btnBoardSetting);
            this.Controls.Add(this.lblCurrentSetting);
            this.Controls.Add(this.lblCurrentSetting_Ex);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.lblColors);
            this.Controls.Add(this.cmbHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.cmbWidth);
            this.Controls.Add(this.lblWidth);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReversingPuzzleSolver";
            this.Load += new System.EventHandler(this.m_frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.ComboBox cmbWidth;
        private System.Windows.Forms.ComboBox cmbHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.Label lblCurrentSetting_Ex;
        private System.Windows.Forms.Label lblCurrentSetting;
        private System.Windows.Forms.Button btnBoardSetting;
        private System.Windows.Forms.Label lblReverseType;
        private System.Windows.Forms.RadioButton radReverse_UDLR;
        private System.Windows.Forms.RadioButton radReverse_3by3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTest;
    }
}

