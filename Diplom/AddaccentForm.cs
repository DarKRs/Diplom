using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
   

    public partial class AddaccentForm : Form
    {
        Dictionary<string, string> WordAccentDictionary;
        MyDelegate d;
        public AddaccentForm(Dictionary<string, string> AccentDictionary, MyDelegate sender)
        {
            WordAccentDictionary = AccentDictionary;
            InitializeComponent();
            d = sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAccent_Click(object sender, EventArgs e)
        {
            var re = new Regex("'"); //Регулярное выражение ударения
            string word = WordBox.Text;
            string Accent = AccentBox.Text;
            if (word == "") {
                MessageBox.Show("Не найдено слово",
               "Введите слово", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (!Accent.Contains("\'") || Accent == "")
            {
                MessageBox.Show("Не найдено слова с ударением",
               "Введите слово с ударением", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if(word != re.Replace(Accent, ""))
            {
                MessageBox.Show("Слова не равны",
               "Введенные слова не равны", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            if (WordAccentDictionary.ContainsKey(word))
            {
                MessageBox.Show("Введенное слово уже есть в словаре",
               "Уже есть в словаре", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            try
            {
                d(word, Accent);
                WordBox.Text = "";
                AccentBox.Text = "";
                MessageBox.Show("Cлово было успешно добавлено в словарь ударений",
               "Слово добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,
                "Ошибка при добавлении в словарь", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }
    }
}
