using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Diplom
{
    public partial class SearchVerse : Form
    {
        int le123;
        string[] Words; //Главный массив исходных слов (уже разбитых)
        string[] WordsAccent; //Главный массив слов ударений (Формуриуется из БД при иницилизации)
        Dictionary<string, string[]> Slogs = new Dictionary<string, string[]>();
        public SearchVerse()
        {
            InitializeComponent();
            Initialization();
        }

        void Initialization()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\BD\";
            /////////////////////Загрузка словаря ударений////////////////////////
            string A = "Slovar_udareny.txt";
            FileStream fs = new FileStream(path + A, FileMode.Open);
            StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);
            string file = reader.ReadToEnd();
            file = ReplaceNR(file);
            WordsAccent = file.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            /////////////////////////////////////////////////////
            reader.Close();
            fs.Close();
            
            string[] ss = FormateSlog("Множество");
            

        }

        private void button2_Click(object sender, EventArgs e)//Найти стихи >>
        {
            if(SourseText.Text == "")
            {
                MessageBox.Show("Введите исходный текст пожалуйста!",
                    "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Sourse;
            Sourse = SourseText.Text;
            Words = Sourse.Split(' ');
            ////////////////////////////
            DictionarySlogs();
            foreach (KeyValuePair<string, string[]> keyValue in Slogs)
            {
                Stix.Text += keyValue.Key + " /// ";
                for(int i = 0; i < keyValue.Value.Length; i++)
                {
                    Stix.Text += " " + keyValue.Value[i];
                }
            }
            string sed = "";
        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            OpenSourseText.Filter = "Text(*.txt)|*.txt";
            OpenSourseText.ShowDialog();
            string path = OpenSourseText.FileName;
            if (OpenSourseText.FileName != "") //если в окне была нажата кнопка "ОК"
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);
                string file = reader.ReadToEnd();
                //////////////////////////////
                file = ReplaceNR(file);
                SourseText.Text = file;
            }
        }

              

        ////////Убирание новой строки и кареток \n & \r//////////////////
        private string ReplaceNR(string file)
        {
            var ReN = new Regex("\n");
            var ReR = new Regex("\r");
            file = ReN.Replace(file, "");
            file = ReR.Replace(file, "");
            return file;
        }

        /////////////////////Формирование словаря "слогов" (Разбиение по гласным)////////////////////////
        public void DictionarySlogs()
        {
            for (int i=0; i < Words.Length; i++)
            {
                try
                {
                    Slogs.Add(Words[i], FormateSlog(Words[i]));
                }
                catch (System.ArgumentException) { continue; }
            }
        }


        /////////////////////Формирование "слогов" (Разбиение по гласным)////////////////////////
        public static string[] FormateSlog(string word)
        {
            string[] glas = { "а", "у", "е", "ы", "о", "я", "и", "э", "ю" };
            List<int> glasIndexes = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                string symbol = word.Substring(i, 1);
                for (int j = 0; j < glas.Length; j++)
                {
                    if (symbol == glas[j])
                    {
                        glasIndexes.Add(i);
                        break;
                    }
                }
            }
            string result = string.Empty;
            for (int i = glasIndexes.Count - 1; i > 0; i--)
            {
                if (glasIndexes[i] - glasIndexes[i - 1] == 1)
                    continue;
                int n = glasIndexes[i] - glasIndexes[i - 1] - 1;
                result = "-" + word.Substring(glasIndexes[i - 1] + 1 + n / 2) + result;
                word = word.Remove(glasIndexes[i - 1] + 1 + n / 2);
            }
            result = word + result;
            string[] slogs = result.Split('-'); 
            return slogs;
        }

    }
}
