namespace Exploratorul_Spatiului
{
    partial class uc_curs_lessson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.miniHTMLTextBox1 = new DG.MiniHTMLTextBox.MiniHTMLTextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // miniHTMLTextBox1
            // 
            this.miniHTMLTextBox1.ActionBarRows = 0;
            this.miniHTMLTextBox1.ActionsCutCopyPasteRedoVisible = false;
            this.miniHTMLTextBox1.ActionsFontStyleVisible = false;
            this.miniHTMLTextBox1.ActionsFontVisible = false;
            this.miniHTMLTextBox1.ActionsHorizonalRuleVisible = false;
            this.miniHTMLTextBox1.ActionsIndentOutdentVisible = false;
            this.miniHTMLTextBox1.ActionsJustifyTextVisible = false;
            this.miniHTMLTextBox1.ActionsListsVisible = false;
            this.miniHTMLTextBox1.ActionsUndoRedoVisible = false;
            this.miniHTMLTextBox1.ActionsViewModeVisible = false;
            this.miniHTMLTextBox1.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.miniHTMLTextBox1.Location = new System.Drawing.Point(3, 66);
            this.miniHTMLTextBox1.Name = "miniHTMLTextBox1";
            this.miniHTMLTextBox1.Padding = new System.Windows.Forms.Padding(1);
            this.miniHTMLTextBox1.ReadOnly = true;
            this.miniHTMLTextBox1.Size = new System.Drawing.Size(1004, 594);
            this.miniHTMLTextBox1.TabIndex = 4;
            this.miniHTMLTextBox1.Text = null;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::Exploratorul_Spatiului.Properties.Resources.back;
            this.guna2Button2.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button2.Location = new System.Drawing.Point(3, 3);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(40, 40);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(33)))), ((int)(((byte)(44)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(49, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(958, 26);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uc_curs_lessson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(33)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.miniHTMLTextBox1);
            this.Controls.Add(this.guna2Button2);
            this.Name = "uc_curs_lessson";
            this.Size = new System.Drawing.Size(1034, 660);
            this.Load += new System.EventHandler(this.uc_curs_lessson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private DG.MiniHTMLTextBox.MiniHTMLTextBox miniHTMLTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
