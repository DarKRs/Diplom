namespace Diplom
{
    partial class AddFileToLexGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFileToLexGroup));
            this.HelpedText = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.AddOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // HelpedText
            // 
            this.HelpedText.BackColor = System.Drawing.SystemColors.Control;
            this.HelpedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpedText.Location = new System.Drawing.Point(12, 12);
            this.HelpedText.Name = "HelpedText";
            this.HelpedText.ReadOnly = true;
            this.HelpedText.Size = new System.Drawing.Size(252, 186);
            this.HelpedText.TabIndex = 1;
            this.HelpedText.Text = resources.GetString("HelpedText.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(152, 224);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(112, 38);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Close";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddOpen
            // 
            this.AddOpen.FileName = "openFileDialog1";
            // 
            // AddFileToLexGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 274);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HelpedText);
            this.Name = "AddFileToLexGroup";
            this.Text = "Добавление файла к морфологическому словарю";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox HelpedText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.OpenFileDialog AddOpen;
    }
}