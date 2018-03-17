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
        string[] Words; //Главный массив исходных слов (уже разбитых)
        string[] WordsAccent; //Главный массив слов ударений (Формуриуется из БД при иницилизации)
        Dictionary<string, word> WORD = new Dictionary<string, word>();
        
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
            Dictionary<string, string> WordAccentDictionary = new Dictionary<string, string>();//Словарь слов с ударениями(Формуриуется из БД при иницилизации)
            file = ReplaceNR(file);
            WordsAccent = file.Split(new char[] { ' ', '\n' , '\r' , '!' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < WordsAccent.Length-1; i++)
            {
                if (WordAccentDictionary.ContainsKey(WordsAccent[i]))
                {
                    i++;
                    continue;
                }
                if(WordAccentDictionary.ContainsKey(WordsAccent[i] + " " + WordsAccent[i + 1]))
                {
                    i += 2;
                    continue;
                }
                if (WordsAccent[i] == WordsAccent[i + 1] && !WordAccentDictionary.ContainsKey(WordsAccent[i]))
                {
                    //////////Слово без ударения/////////////
                    WordAccentDictionary.Add(WordsAccent[i], WordsAccent[i + 1]);
                    i++;
                }
                else if (WordsAccent[i + 1].Contains('\'') && !WordAccentDictionary.ContainsKey(WordsAccent[i]))
                {
                    WordAccentDictionary.Add(WordsAccent[i], WordsAccent[i + 1]);
                    i++;
                }
                else
                {
                    ////////////////////////////Словочетание///////////////////////
                    WordAccentDictionary.Add(WordsAccent[i]+" " +  WordsAccent[i + 1], WordsAccent[i + 2] + " " + WordsAccent[i + 3]);
                    i += 2;
                }
                
            }
            /////////////////////////////////////////////////////
            reader.Close();
            fs.Close();
          /*  string text = "";
            foreach (KeyValuePair<string, string> keyValue in WordAccentDictionary)
            {

                text += keyValue.Key + " -- " + keyValue.Value + " \n";

            }
            Stix.Text += text + " \n";*/
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
            foreach (KeyValuePair<string, word> keyValue in WORD)
            {
                Stix.Text += keyValue.Key + " /// ";
                for (int i = 0; i < keyValue.Value.slogs.Length; i++)
                {
                    Stix.Text += " " + keyValue.Value.slogs[i];
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
            word[] wordDic = new word[Words.Length];
            for (int i=0; i < Words.Length; i++)
            {
                try
                {
                    wordDic[i] = new word();
                    wordDic[i].slogs = wordDic[i].FormateSlog(Words[i]);      
                    WORD.Add(Words[i], wordDic[i]);
                }
                catch (System.ArgumentException) { continue; }
            }
        }

        public void sa()
        {

        }

        public static string test(string word)
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
            return result;
        }


    }
}
