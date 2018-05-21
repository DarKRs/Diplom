namespace Diplom
{
    partial class accentForm
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
            this.Dictionary = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Dictionary
            // 
            this.Dictionary.Location = new System.Drawing.Point(12, 12);
            this.Dictionary.Name = "Dictionary";
            this.Dictionary.Size = new System.Drawing.Size(323, 201);
            this.Dictionary.TabIndex = 0;
            this.Dictionary.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dictionary);
            this.Name = "accentForm";
            this.Text = "Словарь ударений";
            this.Load += new System.EventHandler(this.accentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Dictionary;
        private System.Windows.Forms.Button button1;
    }
}