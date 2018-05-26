namespace Diplom
{
    partial class KakPolzovatsyaProgrammoi
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
            this.HelpedText = new System.Windows.Forms.RichTextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // HelpedText
            // 
            this.HelpedText.BackColor = System.Drawing.SystemColors.Control;
            this.HelpedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpedText.Location = new System.Drawing.Point(165, 12);
            this.HelpedText.Name = "HelpedText";
            this.HelpedText.ReadOnly = true;
            this.HelpedText.Size = new System.Drawing.Size(405, 186);
            this.HelpedText.TabIndex = 0;
            this.HelpedText.Text = "";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(484, 204);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(86, 30);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Общее",
            "Морфологический словарь",
            "Словарь ударений",
            "Разное"});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(147, 186);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // KakPolzovatsyaProgrammoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 244);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.HelpedText);
            this.Name = "KakPolzovatsyaProgrammoi";
            this.Text = "Как пользоваться программой?";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox HelpedText;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ListBox listBox1;
    }
}