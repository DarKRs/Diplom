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
        int qlex = 0; //Счётчик для LEXGROUP
        string[] Words; //Главный массив исходных слов (уже разбитых)
        string[] WordsAccent; //Главный массив слов ударений (Формуриуется из БД при иницилизации)
        LEXGROUP[] lexgroup;
        Dictionary<string, word> WordDictionary = new Dictionary<string, word>();
        Dictionary<string, string> WordAccentDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);//Словарь слов с ударениями(Формуриуется из БД при иницилизации)
        public SearchVerse()
        {
            InitializeComponent();
            Initialization();
        }

        void Initialization()
        {
            var re = new Regex("'");
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
                    WordAccentDictionary.Add(WordsAccent[i], "");
                    i++;
                }
                else if (WordsAccent[i + 1].Contains('\'') && WordsAccent[i] == re.Replace(WordsAccent[i + 1],"") && !WordAccentDictionary.ContainsKey(WordsAccent[i]))
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
            /////////////////////////////////////////////////////Чтение всех файлов//////////////////
            path = System.IO.Directory.GetCurrentDirectory() + @"\BD\LexGroup\GLAG\";
            int leng = new DirectoryInfo(path).GetFiles().Length; //Получает кол-во файлов в папке. 
            lexgroup = new LEXGROUP[854]; //Создание объектов LEXGROUP для удобной работы с ними
            ReadAllFiles(path, leng);
            //////////////////////////////////////////////////////////
            for (int i=0; i < lexgroup.Length; i++)
            {
                lexgroup[i].DeleteCom();
                if (lexgroup[i].words == null) { lexgroup[i].words = "test"; }
                try { lexgroup[i].MassWords = lexgroup[i].words.Split(','); } catch { continue; }
            }
        }

        private void ReadAllFiles(string path, int leng)
        {
            FileStream fs;
            StreamReader reader;
            string Lex = "LEXGROUP.";

            for (int l = 0; l < leng; l++)
            {
                string number = "";
                ///////////////////////////Прописываем номер файла///////////////////
                if (l == 0) { number = "000"; }
                if (l < 10 && l > 0) { number = l.ToString().PadLeft(3, '0'); }
                if (l < 100 && l > 9) { number = l.ToString().PadLeft(3, '0'); }
                if (l > 99) { number = l.ToString(); }
                /////////////////////////////Читаем файл и раскрываем скобки/////////////////////////////////////////
                try { fs = new FileStream(path + Lex + number, FileMode.Open);
                    reader = new StreamReader(fs, System.Text.Encoding.Default);
                    string file2 = reader.ReadToEnd();
                    string[] textOfFile = file2.Split(new char[] { '\n', '\r', }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < textOfFile.Length; i++)
                    {
                        if (textOfFile[i].Contains('{'))
                        {
                            
                            lexgroup[qlex] = new LEXGROUP();
                            lexgroup[qlex].ends = Skobki(textOfFile[i]);
                            qlex++;
                            continue;
                        }
                        lexgroup[qlex - 1].words += textOfFile[i] + ",";
                    }
                }
                catch { continue; }
            }
        }

        /// <summary>
        /// Раскрытие скобок
        /// </summary>
        /// <param name="s">Строка со скобками</param>
        /// <returns>Возвращает массив готовых окончаний (открытие скобок сделано)</returns>
        private string[] Skobki(string s)
        {
            int o = 0; //Счётчик для вставки раскрытых слов в конечный массив
            //Избавляемся от лишнего текста в конце. (+1 чтобы осталась скобка)
            string text = s.Remove(s.LastIndexOf('}'));
            text = text.Remove(text.IndexOf('{'),1);
            // text = Skobki1.Replace(text, " ");
            // text = Skobki2.Replace(text, " ");
            string[] mass = text.Split(',');
            string[] isxod = new string[mass.Length + 50]; //В получившийся массив нужно записать отсплитованные слова
            for (int i=0; i < mass.Length; i++)
            {
                if (mass[i].Contains('{'))
                {
                    string[] skoba01 = mass[i].Split('{');
                    string[] skobki = new string[mass.Length + 50];
                    int j = 0;
                    while (i < mass.Length)
                    {
                        i++;
                        if (mass[i].Contains('}'))
                        {
                            mass[i] = mass[i].Remove(mass[i].IndexOf('}'));
                            skobki[j] = mass[i];
                            break;
                        }
                        skobki[j] = mass[i];
                        j++;
                    }
                    isxod[o] = skoba01[0] + skoba01[1]; o++;
                    for(int l = 0; skobki[l] != null; l++)
                    {
                        isxod[o] = skoba01[0] + skobki[l]; o++;
                    }
                }
                isxod[o] = mass[i]; o++;
            }
            return isxod;
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
            for(int i=0; i < Words.Length; i++)
            {
                Stix.Text += Words[i] + " /// ";
                for(int k=0; k < WordDictionary[Words[i]].slogs.Length; k++)
                {
                    Stix.Text += " " + WordDictionary[Words[i]].slogs[k];
                }
                Stix.Text += "  /// " + WordDictionary[Words[i]].Accent + "\n";
            }
            Stix.Text += "\n \n";
            ///////////////////Поиск четырехстопного ямба в тексте////////////////////
            for (int i = 0; i < Words.Length - 3; i++)
            {
                string Yamb = Words[i] + " " + Words[i + 1] + " " + Words[i + 2] + " " + Words[i + 3];
                string[] Stope = Yamb.Split(' ');
                for (int qStope = 0; qStope < 4; qStope++) {
                    int NumberofAccent = WordDictionary[Stope[qStope]].AccentInSlogs();
                    string AccentSlog = WordDictionary[Stope[qStope]].Accent;
                    
                }
            }
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
            var ReG = new Regex("—");
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
            file = ReG.Replace(file, " ");
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
                    wordDic[i].slogs = wordDic[i].SlogSpliter(Words[i]);
                    try { wordDic[i].Accent = WordAccentDictionary[Words[i]]; } //Находит ударение по ключу....По слову
                    //Если такого ключа нет  проверяем на окончания. И опять ищем по ключу
                    catch
                    {
                        ////Работа с окончаниями
                        string abWord = AddAbout(Words[i],WordAccentDictionary);
                        try { wordDic[i].Accent = WordAccentDictionary[abWord]; }
                        catch { WordAccentDictionary.Add(Words[i], Words[i]); wordDic[i].Accent = WordAccentDictionary[Words[i]]; } //Добавление ЭТОГО же слова как слова с ударением т.к. некоторые слова безударные
                    }
                    WordDictionary.Add(Words[i], wordDic[i]);
                }
            }
        }

        /// <summary>
        /// Удаление окончания и добавление другого 
        /// </summary>
        /// <param name="word">Входяшее слово</param>
        /// <returns></returns>
        public string AddAbout(string word, Dictionary<string,string> AccentDictionary)
        {
            string NewWord = "";
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
                    if (!AccentDictionary.ContainsKey(word))
                    {
                        for (int j = 0; j < lexgroup.Length; j++)
                        {
                           for(int k=0;k < lexgroup[j].MassWords.Length; k++)
                            {
                                if(word == lexgroup[j].MassWords[k])
                                {
                                    for (int l = 0; l < lexgroup[j].ends.Length; l++)
                                    {
                                        NewWord = word + lexgroup[j].ends[l];
                                        if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
                                    }
                                }
                            }
                      }
                    }
                    break;
                }
            }
            return word;
        }
    }
}
