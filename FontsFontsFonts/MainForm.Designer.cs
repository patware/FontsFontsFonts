namespace FontsFontsFonts
{
    partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.textboxTextToTest = new System.Windows.Forms.TextBox();
			this.listBoxStyle = new System.Windows.Forms.CheckedListBox();
			this.numericFontSize = new System.Windows.Forms.NumericUpDown();
			this.panelResult = new System.Windows.Forms.Panel();
			this.LabelHoverFont = new System.Windows.Forms.Label();
			this.linkAlphabet = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text to test";
			// 
			// textboxTextToTest
			// 
			this.textboxTextToTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textboxTextToTest.Location = new System.Drawing.Point(3, 23);
			this.textboxTextToTest.Name = "textboxTextToTest";
			this.textboxTextToTest.Size = new System.Drawing.Size(193, 20);
			this.textboxTextToTest.TabIndex = 1;
			this.textboxTextToTest.TextChanged += new System.EventHandler(this.textboxTextToTest_TextChanged);
			// 
			// listBoxStyle
			// 
			this.listBoxStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxStyle.FormattingEnabled = true;
			this.listBoxStyle.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Strikeout",
            "Underline"});
			this.listBoxStyle.Location = new System.Drawing.Point(3, 48);
			this.listBoxStyle.MultiColumn = true;
			this.listBoxStyle.Name = "listBoxStyle";
			this.listBoxStyle.Size = new System.Drawing.Size(254, 34);
			this.listBoxStyle.TabIndex = 2;
			this.listBoxStyle.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxStyle_ItemCheck);
			// 
			// numericFontSize
			// 
			this.numericFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericFontSize.Location = new System.Drawing.Point(202, 23);
			this.numericFontSize.Name = "numericFontSize";
			this.numericFontSize.Size = new System.Drawing.Size(55, 20);
			this.numericFontSize.TabIndex = 3;
			this.numericFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numericFontSize.ValueChanged += new System.EventHandler(this.numericFontSize_ValueChanged);
			// 
			// panelResult
			// 
			this.panelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelResult.AutoScroll = true;
			this.panelResult.Location = new System.Drawing.Point(3, 89);
			this.panelResult.Name = "panelResult";
			this.panelResult.Size = new System.Drawing.Size(253, 237);
			this.panelResult.TabIndex = 4;
			// 
			// LabelHoverFont
			// 
			this.LabelHoverFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LabelHoverFont.AutoSize = true;
			this.LabelHoverFont.Location = new System.Drawing.Point(6, 334);
			this.LabelHoverFont.Name = "LabelHoverFont";
			this.LabelHoverFont.Size = new System.Drawing.Size(245, 13);
			this.LabelHoverFont.TabIndex = 5;
			this.LabelHoverFont.Text = "Move mouse over a font name to find out what it is";
			// 
			// linkAlphabet
			// 
			this.linkAlphabet.AutoSize = true;
			this.linkAlphabet.Location = new System.Drawing.Point(80, 5);
			this.linkAlphabet.Name = "linkAlphabet";
			this.linkAlphabet.Size = new System.Drawing.Size(49, 13);
			this.linkAlphabet.TabIndex = 6;
			this.linkAlphabet.TabStop = true;
			this.linkAlphabet.Text = "Alphabet";
			this.linkAlphabet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAlphabet_LinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 355);
			this.Controls.Add(this.linkAlphabet);
			this.Controls.Add(this.LabelHoverFont);
			this.Controls.Add(this.panelResult);
			this.Controls.Add(this.numericFontSize);
			this.Controls.Add(this.listBoxStyle);
			this.Controls.Add(this.textboxTextToTest);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(268, 300);
			this.Name = "MainForm";
			this.Text = "FontsFontsFonts - by Patware";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxTextToTest;
        private System.Windows.Forms.CheckedListBox listBoxStyle;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label LabelHoverFont;
		private System.Windows.Forms.LinkLabel linkAlphabet;
    }
}

