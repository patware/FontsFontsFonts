using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FontsFontsFonts
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void showText()
        {
            string text = this.textboxTextToTest.Text;
            float fontSize = (float)this.numericFontSize.Value;
            
            showText(text);

        }
        private void showText(string text)
        {
            bool useFontName = text.Length==0;

            foreach (Label label in this.panelResult.Controls)
            {
                if (useFontName)
                    label.Text = label.Font.Name;
                else
                    label.Text = text;
            }
        }

        private void textboxTextToTest_TextChanged(object sender, EventArgs e)
        {
            showText();
        }

        private void numericFontSize_ValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            float size = (float)numericFontSize.Value;

            int y = 0;

            foreach (Label label in this.panelResult.Controls)
            {
                label.Font = new Font(label.Font.FontFamily,size);
                label.Location = new Point(0, y);
                y += label.Height;
            }

            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }


        private void listBoxStyle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            FontStyle style = FontStyle.Regular;

            if (e.Index != 0 && this.listBoxStyle.GetItemChecked(0)) style |= FontStyle.Bold;
            if (e.Index != 1 && this.listBoxStyle.GetItemChecked(1)) style |= FontStyle.Italic;
            if (e.Index != 2 && this.listBoxStyle.GetItemChecked(2)) style |= FontStyle.Strikeout;
            if (e.Index != 3 && this.listBoxStyle.GetItemChecked(3)) style |= FontStyle.Underline;

            if (e.NewValue == CheckState.Checked)
            {
                switch (e.Index)
                {
                    case 0:
                        style |= FontStyle.Bold;
                        break;
                    case 1:
                        style |= FontStyle.Italic;
                        break;
                    case 2:
                        style |= FontStyle.Strikeout;
                        break;
                    case 3:
                        style |= FontStyle.Underline;
                        break;
                }
            }
            
            foreach (Label label in this.panelResult.Controls)
            {
                if (label.Font.FontFamily.IsStyleAvailable(style))
                    label.Font = new Font(label.Font, style);
            }
            this.Cursor = Cursors.Default;
            this.Enabled = true;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int y = 0;
            Label label;
            int i=0;

            float emSize = this.panelResult.Font.Size;

            foreach (FontFamily fontFamilly in FontFamily.Families)
            {
                if (fontFamilly.IsStyleAvailable(FontStyle.Regular))
                {
                    i++;
                    Font font = new Font(fontFamilly,emSize);

                    label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(0,y);
                    label.Name = "font" + i.ToString();
                    label.TabIndex = 0;
                    label.Text = fontFamilly.Name;
                    label.Font = font;
                    label.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                        | AnchorStyles.Right)));
                    label.MouseMove += new MouseEventHandler(label_MouseMove);
                    label.Tag = fontFamilly.Name;
                    
                    this.panelResult.Controls.Add(label);
                    
                    y += label.Height;
                }
            }
        }

        void label_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;

            LabelHoverFont.Text = (string)label.Tag;

        }

		private void linkAlphabet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			StringBuilder sb = new StringBuilder(254);

			for (int i = 1; i < 254; i++)
			{
				sb.Append(char.ConvertFromUtf32(i));
			}
			this.textboxTextToTest.Text = sb.ToString();

		}
	}
}