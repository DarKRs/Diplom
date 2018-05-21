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
            this.OpenText = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Stix = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.словариToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.морфологическийСловарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлLEXGROUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словарьУдаренийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьУдарениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какПользоватьсяПрограммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSourseText = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourseText
            // 
            this.SourseText.Location = new System.Drawing.Point(12, 31);
            this.SourseText.Name = "SourseText";
            this.SourseText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SourseText.Size = new System.Drawing.Size(277, 370);
            this.SourseText.TabIndex = 0;
            this.SourseText.Text = "";
            // 
            // OpenText
            // 
            this.OpenText.Location = new System.Drawing.Point(295, 45);
            this.OpenText.Name = "OpenText";
            this.OpenText.Size = new System.Drawing.Size(101, 33);
            this.OpenText.TabIndex = 1;
            this.OpenText.Text = "Открыть текст";
            this.OpenText.UseVisualStyleBackColor = true;
            this.OpenText.Click += new System.EventHandler(this.OpenText_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Найти стихи >>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Stix
            // 
            this.Stix.Location = new System.Drawing.Point(402, 31);
            this.Stix.Name = "Stix";
            this.Stix.ReadOnly = true;
            this.Stix.Size = new System.Drawing.Size(469, 370);
            this.Stix.TabIndex = 3;
            this.Stix.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.словариToolStripMenuItem,
            this.HELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // словариToolStripMenuItem
            // 
            this.словариToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.морфологическийСловарьToolStripMenuItem,
            this.словарьУдаренийToolStripMenuItem,
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem});
            this.словариToolStripMenuItem.Name = "словариToolStripMenuItem";
            this.словариToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.словариToolStripMenuItem.Text = "Словари";
            // 
            // морфологическийСловарьToolStripMenuItem
            // 
            this.морфологическийСловарьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem2,
            this.добавитьФайлLEXGROUPToolStripMenuItem});
            this.морфологическийСловарьToolStripMenuItem.Name = "морфологическийСловарьToolStripMenuItem";
            this.морфологическийСловарьToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.морфологическийСловарьToolStripMenuItem.Text = "Словарь ударений";
            // 
            // просмотрToolStripMenuItem2
            // 
            this.просмотрToolStripMenuItem2.Name = "просмотрToolStripMenuItem2";
            this.просмотрToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.просмотрToolStripMenuItem2.Text = "Просмотр";
            this.просмотрToolStripMenuItem2.Click += new System.EventHandler(this.просмотрToolStripMenuItem2_Click);
            // 
            // добавитьФайлLEXGROUPToolStripMenuItem
            // 
            this.добавитьФайлLEXGROUPToolStripMenuItem.Name = "добавитьФайлLEXGROUPToolStripMenuItem";
            this.добавитьФайлLEXGROUPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьФайлLEXGROUPToolStripMenuItem.Text = "Добавить ударение";
            this.добавитьФайлLEXGROUPToolStripMenuItem.Click += new System.EventHandler(this.добавитьФайлLEXGROUPToolStripMenuItem_Click);
            // 
            // словарьУдаренийToolStripMenuItem
            // 
            this.словарьУдаренийToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem1,
            this.добавитьУдарениеToolStripMenuItem});
            this.словарьУдаренийToolStripMenuItem.Name = "словарьУдаренийToolStripMenuItem";
            this.словарьУдаренийToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.словарьУдаренийToolStripMenuItem.Text = "Морфологический словарь";
            // 
            // просмотрToolStripMenuItem1
            // 
            this.просмотрToolStripMenuItem1.Name = "просмотрToolStripMenuItem1";
            this.просмотрToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.просмотрToolStripMenuItem1.Text = "Просмотр";
            this.просмотрToolStripMenuItem1.Click += new System.EventHandler(this.просмотрToolStripMenuItem1_Click);
            // 
            // добавитьУдарениеToolStripMenuItem
            // 
            this.добавитьУдарениеToolStripMenuItem.Name = "добавитьУдарениеToolStripMenuItem";
            this.добавитьУдарениеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.добавитьУдарениеToolStripMenuItem.Text = "Добавить файл";
            this.добавитьУдарениеToolStripMenuItem.Click += new System.EventHandler(this.добавитьУдарениеToolStripMenuItem_Click);
            // 
            // словарьОкончанийРусскогоЯзыкаToolStripMenuItem
            // 
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem});
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem.Name = "словарьОкончанийРусскогоЯзыкаToolStripMenuItem";
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.словарьОкончанийРусскогоЯзыкаToolStripMenuItem.Text = "Словарь окончаний русского языка";
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            this.просмотрToolStripMenuItem.Click += new System.EventHandler(this.просмотрToolStripMenuItem_Click);
            // 
            // HELPToolStripMenuItem
            // 
            this.HELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.какПользоватьсяПрограммойToolStripMenuItem,
            this.AboutAutorToolStripMenuItem});
            this.HELPToolStripMenuItem.Name = "HELPToolStripMenuItem";
            this.HELPToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.HELPToolStripMenuItem.Text = "Помощь";
            // 
            // какПользоватьсяПрограммойToolStripMenuItem
            // 
            this.какПользоватьсяПрограммойToolStripMenuItem.Name = "какПользоватьсяПрограммойToolStripMenuItem";
            this.какПользоватьсяПрограммойToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.какПользоватьсяПрограммойToolStripMenuItem.Text = "Как пользоваться программой?";
            this.какПользоватьсяПрограммойToolStripMenuItem.Click += new System.EventHandler(this.какПользоватьсяПрограммойToolStripMenuItem_Click);
            // 
            // AboutAutorToolStripMenuItem
            // 
            this.AboutAutorToolStripMenuItem.Name = "AboutAutorToolStripMenuItem";
            this.AboutAutorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.AboutAutorToolStripMenuItem.Text = "Об авторе";
            this.AboutAutorToolStripMenuItem.Click += new System.EventHandler(this.AboutAutorToolStripMenuItem_Click);
            // 
            // OpenSourseText
            // 
            this.OpenSourseText.FileName = "openFileDialog1";
            // 
            // SearchVerse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 413);
            this.Controls.Add(this.Stix);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OpenText);
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
        private System.Windows.Forms.Button OpenText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox Stix;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAutorToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenSourseText;
        private System.Windows.Forms.ToolStripMenuItem какПользоватьсяПрограммойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem морфологическийСловарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлLEXGROUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словарьУдаренийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьУдарениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem словарьОкончанийРусскогоЯзыкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
    }
}

