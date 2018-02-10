namespace Diplom
{
    partial class SearchVerse
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourseText = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourseText
            // 
            this.SourseText.Location = new System.Drawing.Point(12, 31);
            this.SourseText.Name = "SourseText";
            this.SourseText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SourseText.Size = new System.Drawing.Size(277, 326);
            this.SourseText.TabIndex = 0;
            this.SourseText.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть текст";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Найти стихи >>";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(402, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(300, 326);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HELPToolStripMenuItem
            // 
            this.HELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAutorToolStripMenuItem});
            this.HELPToolStripMenuItem.Name = "HELPToolStripMenuItem";
            this.HELPToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.HELPToolStripMenuItem.Text = "Помощь";
            // 
            // AboutAutorToolStripMenuItem
            // 
            this.AboutAutorToolStripMenuItem.Name = "AboutAutorToolStripMenuItem";
            this.AboutAutorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AboutAutorToolStripMenuItem.Text = "Об авторе";
            // 
            // SearchVerse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 369);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SourseText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SearchVerse";
            this.Text = "Поиск стихотворных форм";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SourseText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAutorToolStripMenuItem;
    }
}

