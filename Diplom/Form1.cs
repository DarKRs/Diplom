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
        Dictionary<string, word> WordDictionary = new Dictionary<string, word>();
        Dictionary<string, string> WordAccentDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);//Словарь слов с ударениями(Формуриуется из БД при иницилизации)
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
           /* string ew = "ние";
            string we = "Окончание";
            we.EndsWith(ew);
            string text = "";
            foreach (KeyValuePair<string, string> keyValue in WordAccentDictionary)
            {

                text += keyValue.Key + " -- " + keyValue.Value + " \n";

            }
            Stix.Text += text + " \n";*/
        }

        private void button2_Click(object sender, EventArgs e)//Найти стихи >>
        {
            Stix.Clear();
            if(SourseText.Text == "")
            {
                MessageBox.Show("Введите исходный текст пожалуйста!",
                    "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Sourse;
            Sourse = SourseText.Text;
            Sourse = ReplaceNR(Sourse);
            Words = Sourse.Split(' ');
            Words = Words.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            ////////////////////////////
            DictionarySlogs();
            foreach (KeyValuePair<string, word> keyValue in WordDictionary)
            {
                Stix.Text += keyValue.Key + " /// ";
                for (int i = 0; i < keyValue.Value.slogs.Length; i++)
                {
                    Stix.Text += " " + keyValue.Value.slogs[i];
                }
                Stix.Text += " " + keyValue.Value.Accent + "\n";
            }
            string sed = "";
            word lol = new word();
            WordDictionary.Add("123", lol);
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
                SourseText.Text = file;
            }
        }

              

        ////////Обработка текста.Убирание новой строки и кареток \n & \r//////////////////
        private string ReplaceNR(string file)
        {
            var ReN = new Regex("\n");
            var ReR = new Regex("\r");
            var ReT = new Regex("\"");
            var ReY = new Regex("!");
            var ReU = new Regex("-");
            var ReI = new Regex(",");
            var ReO = new Regex(":");
            var ReP = new Regex("–");
            var ReA = new Regex(@"\(");
            var ReS = new Regex(@"\)");
            var ReD = new Regex(@"\?");
            var ReF = new Regex(";");
            var ReG = new Regex(".");
            file = ReN.Replace(file, " ");
            file = ReR.Replace(file, " ");
            file = ReT.Replace(file, " ");
            file = ReY.Replace(file, " ");
            file = ReU.Replace(file, " ");
            file = ReI.Replace(file, " ");
            file = ReO.Replace(file, " ");
            file = ReP.Replace(file, " ");
            file = ReA.Replace(file, " ");
            file = ReS.Replace(file, " ");
            file = ReD.Replace(file, " ");
            file = ReF.Replace(file, " ");
            file = ReG.Replace(file, "");
            return file;
        }

        /////////////////////Формирование словаря слов. Слогов и удаорений ////////////////////////
        public void DictionarySlogs()
        {
            word[] wordDic = new word[Words.Length];

            for (int i = 0; i < Words.Length; i++)
            {
                if (!WordDictionary.ContainsKey(Words[i]))
                {
                    wordDic[i] = new word();
                    wordDic[i].slogs = wordDic[i].FormateSlog(Words[i]);
                    try { wordDic[i].Accent = WordAccentDictionary[Words[i]]; } //Находит ударение по ключу....По слову
                    //Если такого ключа нет  проверяем на окончания. И опять ищем по ключу
                    catch
                    {
                        string abWord = about(Words[i]);
                        try { wordDic[i].Accent = WordAccentDictionary[abWord]; }
                        catch { WordAccentDictionary.Add(Words[i], Words[i]); wordDic[i].Accent = WordAccentDictionary[Words[i]]; } //Добавление ЭТОГО же слова как слова с ударением т.к. некоторые слова безударные
                        WordDictionary.Add(Words[i], wordDic[i]);
                    }
                }
            }
        }

        //Проверка на ококончание
        public static string about(string word)
        {
            //Массив окончаний
            string[] ThreeAbout = { "ать", "ять", "оть", "еть", "уть", "у", "ю", "ем", "ешь", "ете", "ет","ут","ют","ал","ял","ала","яла","али","яли","ул","ула","ули",
                "а","я","о","е","ь","ы","и","ая","яя","ое","ее","ой","ые","ие","ый","йй",
                "ам","ами","ас","aм","ax","ая","её","ей","ем","еми","емя","ex","ею","ёт","ёте","ёх","ёшь","ий","ие","им","ими","ит","ите","их","ишь","ию","м","ми",
                "мя","ов","ого","ое","оё","ой","ом","ому","ою","ум","умя","ут","ух","ую","шь"};
            for (int i = 0; i < ThreeAbout.Length; i++)
            {
                if (word.EndsWith(ThreeAbout[i]))
                {
                    word = word.Replace(ThreeAbout[i], "");
                    break;
                }
            }
                
            return word;
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
