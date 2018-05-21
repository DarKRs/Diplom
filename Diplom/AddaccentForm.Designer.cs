namespace Diplom
{
    partial class AddaccentForm
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
            this.WordBox = new System.Windows.Forms.TextBox();
            this.AccentBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AddAccent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WordBox
            // 
            this.WordBox.Location = new System.Drawing.Point(12, 27);
            this.WordBox.Name = "WordBox";
            this.WordBox.Size = new System.Drawing.Size(260, 20);
            this.WordBox.TabIndex = 0;
            // 
            // AccentBox
            // 
            this.AccentBox.Location = new System.Drawing.Point(12, 78);
            this.AccentBox.Name = "AccentBox";
            this.AccentBox.Size = new System.Drawing.Size(260, 20);
            this.AccentBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Слово";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Слово с ударением";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 104);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(138, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "ВНИМАНИЕ!\nДобавляйте значок ударения (\') до буквы на которую это ударение падает." +
    "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddAccent
            // 
            this.AddAccent.Location = new System.Drawing.Point(168, 104);
            this.AddAccent.Name = "AddAccent";
            this.AddAccent.Size = new System.Drawing.Size(90, 38);
            this.AddAccent.TabIndex = 6;
            this.AddAccent.Text = "Добавить в словарь";
            this.AddAccent.UseVisualStyleBackColor = true;
            this.AddAccent.Click += new System.EventHandler(this.AddAccent_Click);
            // 
            // AddaccentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.AddAccent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AccentBox);
            this.Controls.Add(this.WordBox);
            this.Name = "AddaccentForm";
            this.Text = "Добавление в словарь ударений";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WordBox;
        private System.Windows.Forms.TextBox AccentBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddAccent;
    }
}