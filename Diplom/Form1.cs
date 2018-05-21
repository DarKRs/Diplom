using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Diplom
{
    public partial class SearchVerse : Form
    {
        int qlex = 0; //Счётчик для LEXGROUP
        string[] Words; //Главный массив исходных слов (уже разбитых)
        string[] WordsAccent; //Главный массив слов ударений (Формуриуется из БД при иницилизации)
        LEXGROUP[] lexgroup; //Массив LEXGROUP хранящий в себе начало слов и их возможные окончания
        Dictionary<string, word> WordDictionary = new Dictionary<string, word>(); //Словарь объектов класса word. В котором хранятся ударения, слоги и т.д.
        Dictionary<string, string> WordAccentDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);//Словарь ударений(Формуриуется из БД при иницилизации)


        public SearchVerse()
        {
            InitializeComponent();
            Initialization();
        }

        void Initialization()
        {
            var re = new Regex("'"); //Регулярное выражение ударения
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
                if (WordAccentDictionary.ContainsKey(WordsAccent[i])) //Если уже есть такое слово в словаре то пропускаем
                {
                    i++;
                    continue;
                }
                if(WordAccentDictionary.ContainsKey(WordsAccent[i] + " " + WordsAccent[i + 1])) //Если уже есть такое словочетание
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
                //Если следуйщее слово содержит знак ударения И это слово совпадает со следуйщим если убрать знак ударения И его нет в словаре
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
            /////////////////////////////Чтение всех файлов для морфологического словаря//////////////////
            path = System.IO.Directory.GetCurrentDirectory() + @"\BD\LexGroup\GLAG\";
            int leng = new DirectoryInfo(path).GetFiles().Length; //Получает кол-во файлов в папке. 
            lexgroup = new LEXGROUP[new DirectoryInfo(path).GetFiles().Length * 5]; //Создание объектов LEXGROUP для удобной работы с ними
            ReadAllFiles(path, leng);
            //////////////////////////////////////////////////////////
         
        }

        /// <summary>
        /// Читает все файлы LEXGROUP из папки (path) и записывает их в массив lexgroup
        /// </summary>
        /// <param name="path">Путь до папки с файлами LEXGROUP</param>
        /// <param name="leng">Кол-во файлов в папке</param>
        public void ReadAllFiles(string path, int leng)
        {
            FileStream fs;
            StreamReader reader;
            string Lex = "LEXGROUP.";

            for (int l = 0; l < leng+300; l++)
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
                        if (textOfFile[i].Contains('{'))//Если строка содержит { значит это новый набор слов и окончаний для них
                        {
                            lexgroup[qlex] = new LEXGROUP();
                            lexgroup[qlex].ends = OpeningBrackets(textOfFile[i]); // С помощью функции Openingbrackets раскрываем скобки и записываем массив окончаний
                            qlex++;
                            continue;
                        }
                        lexgroup[qlex - 1].words += textOfFile[i] + ",";
                    }
                }
                catch { continue; } //Если по какой-то причине не удалось открыть файл продолжаем чтение других
            }
            for (int i = 0; i < lexgroup.Length; i++)
            {
                lexgroup[i].DeleteCom();
                lexgroup[i].CompareEnds();
                if (lexgroup[i].words == null) { lexgroup[i].words = "test"; }
                try { lexgroup[i].MassWords = lexgroup[i].words.Split(','); } catch { continue; }
            }
        }

        /// <summary>
        /// Раскрытие скобок
        /// </summary>
        /// <param name="s">Строка со скобками</param>
        /// <returns>Возвращает массив готовых окончаний (открытие скобок сделано)</returns>
        private string[] OpeningBrackets(string s)
        {
            int o = 0; //Счётчик для вставки раскрытых слов в конечный массив
            //Избавляемся от лишнего текста в конце. 
            string text = s.Remove(s.LastIndexOf('}'));
            text = text.Remove(text.IndexOf('{'),1);
            string[] mass = text.Split(','); //Разделяем всю строку по запятым для дальнейшего форматирования
            string[] isxod = new string[mass.Length + 50]; //Создание массива для конечного результата. Его длина равна длине разбитого по запятым массива +50
            for (int i=0; i < mass.Length; i++)
            {
                if (mass[i].Contains('{'))
                {
                    string[] skoba01 = mass[i].Split('{'); //Первое слово до внутренних скобок с которого могут начинатся другие окончания 
                    string[] skobki = new string[mass.Length + 10];
                    int j = 0;
                    while (i < mass.Length)
                    {
                        i++;
                        if (mass[i].Contains('}')) // Если встретился знак закрытия скобок
                        {
                            mass[i] = mass[i].Remove(mass[i].IndexOf('}')); //Убираем этот знак
                            skobki[j] = mass[i]; // Записываем в массив последнее из окончаний внутрених скобок и выходим из цикла
                            break;
                        }
                        skobki[j] = mass[i]; //Заполняем массив внутрених скобок
                        j++;
                    }
                    isxod[o] = skoba01[0] + skoba01[1]; o++; //Соеденяем первое окончание с окончанием во внутрених скобках
                    for(int l = 0; skobki[l] != null; l++)
                    {
                        isxod[o] = skoba01[0] + skobki[l]; o++; // Соеденинение последующих окончаний
                    }
                }
                isxod[o] = mass[i]; o++; // Записываем окончания в массив
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
            string[] phrase = Sourse.Split('\n');
            phrase = phrase.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            Sourse = ReplaceNR(Sourse);
           
            Words = Sourse.Split(' ');
            Words = Words.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            ////////////////////////////
            CreateDictionary(); // Формирование словаря объектов класса word.
            for (int i=0; i < Words.Length; i++)
            {
                Stix.Text += Words[i] + "\t /// ";
                for(int k=0; k < WordDictionary[Words[i]].slogs.Length; k++)
                {
                    Stix.Text += " " + WordDictionary[Words[i]].slogs[k];
                }
                Stix.Text += "\t  /// " + WordDictionary[Words[i]].Accent;
                Stix.Text += "\t  /// ";
                for (int k = 0; k < WordDictionary[Words[i]].Accentslogs.Length; k++)
                {
                    Stix.Text += " " + WordDictionary[Words[i]].Accentslogs[k];
                }
                Stix.Text += "\n";
            }
            Stix.Text += "\n \n";

            Stix.Text += "Найденная структура: \n";
            for (int i = 0; i < phrase.Length; i++) {
                Stix.Text += GenerateWordBY(phrase[i]) + "\t\t" + phrase[i];
                Stix.Text += "\n";
            }
            //StixMetr(BY);
        }

        private string StixMetr(string WordBY)
        {
            if (WordBY.Contains("БУБУБУБУ")) { return "Четырехстопный Ямб"; }
            return "";
            /* string[] Metr = WordBY.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             for(int i=0; i < Metr.Length - 3; i++)
             {
                 string Yamb = Metr[i] + " " + Metr[i + 1] + " " + Metr[i + 2] + " " + Metr[i + 3]; 
                 if (Yamb == "БУБУБУБУ") { return "Четырехстопный Ямб"; }
             }
             return "";*/
        }


        /// <summary>
        /// Построение строки по типу БУУБУБУБ (Б - Безударные, У - ударные)
        /// </summary>
        /// <returns>Возвращает строку ударных безударных и вариативных</returns>
        private string GenerateWordBY(string phrase)
        {
            phrase = ReplaceNR(phrase);
            string[] WordsInPrhase = phrase.Split(' ');
            WordsInPrhase = WordsInPrhase.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            string WordsBY = "";
            for (int i = 0; i < WordsInPrhase.Length; i++)
            {
                    //Перебор по слогам. Так как в разных словах разное кол-во то используем цикл
                    for (int j = 0; j < WordDictionary[WordsInPrhase[i]].slogs.Length; j++)
                    {
                        //Если для этого слова нет ударения. Делаем оба слова вариативными (В)
                        if (WordDictionary[WordsInPrhase[i]].Accent == "")
                        {
                            for (int k = 0; k < WordDictionary[WordsInPrhase[i]].slogs.Length; k++) { WordsBY += "В"; }
                            break;
                        }
                    try
                    {
                        if (WordDictionary[WordsInPrhase[i]].Accentslogs[j].Contains("'"))
                        {
                            WordsBY += "У";
                        }

                        if (!WordDictionary[WordsInPrhase[i]].Accentslogs[j].Contains("'"))
                        {
                            WordsBY += "Б";
                        }
                    }
                    catch { break; }
                    }
            }
            string Metr = StixMetr(WordsBY);
            if(Metr != "") { return WordsBY + "(" + Metr + ")"; }
            return WordsBY;
        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            OpenSourseText.Filter = "Text(*.txt)|*.txt";
            try
            {
                OpenSourseText.ShowDialog();
                string path = OpenSourseText.FileName;
                if (OpenSourseText.FileName != "") //если в окне была нажата кнопка "ОК"
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    StreamReader reader = new StreamReader(fs, System.Text.Encoding.UTF8);
                    string file = reader.ReadToEnd();
                    //////////////////////////////
                    SourseText.Text = file;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Не удалось открыть файл", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

              

        ////////Обработка текста.//////////////////
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
            var ReH = new Regex(@"\.");
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
            file = ReH.Replace(file, " ");
            return file;
        }

        /////////////////////Формирование словаря объектов класса word. Слогов и ударений ////////////////////////
        public void CreateDictionary()
        {
            word[] wordDic = new word[Words.Length]; //Массив объектов класса word для последующего занесения этих объектов в словарь   WordDictionary

            for (int i = 0; i < Words.Length; i++)
            {
                if (!WordDictionary.ContainsKey(Words[i]))
                {
                    wordDic[i] = new word(); 
                    wordDic[i].slogs = wordDic[i].SlogSpliter(Words[i]); //Записываем слоги для данного слова
                    try { wordDic[i].Accent = WordAccentDictionary[Words[i]]; } //Находит ударение по ключу....По слову
                    //Если такого ключа нет  проверяем на окончания. И опять ищем по ключу
                    catch
                    {
                        string oldWord = Words[i];
                        ////Работа с окончаниями
                        string newAccent = DelOneEnd(Words[i],WordAccentDictionary); //Сначало удаляем 1 букву в конце. (самых == самый)
                        if (WordAccentDictionary.ContainsKey(newAccent))
                        {
                            Verify(newAccent, oldWord);
                        }
                        if (!WordAccentDictionary.ContainsKey(newAccent))
                        {
                            newAccent = AddAbout(Words[i], WordAccentDictionary); //Удаляем по окончанию
                            if (WordAccentDictionary.ContainsKey(newAccent))
                            {
                                Verify(newAccent, oldWord);
                            }
                            if (!WordAccentDictionary.ContainsKey(newAccent))
                            {
                                for (int k = 1; k < Words[i].Length / 2 - 1; k++) //Удаляем несколько букв в конце (k)
                                {
                                    newAccent = DelEndAddAbout(Words[i], WordAccentDictionary, k);
                                    if (WordAccentDictionary.ContainsKey(newAccent))
                                    {
                                        Verify(newAccent, oldWord);
                                        break;
                                    }
                                }
                            }
                            if (!WordAccentDictionary.ContainsKey(newAccent))
                            {
                                WordAccentDictionary.Add(Words[i], ""); wordDic[i].Accent = ""; //Добавление ЭТОГО же слова как слова с ударением т.к. некоторые слова безударные
                            }
                        }
                        wordDic[i].Accent = WordAccentDictionary[newAccent];
                    }
                    wordDic[i].Accentslogs = wordDic[i].SlogSpliter(wordDic[i].Accent);
                    WordDictionary.Add(Words[i], wordDic[i]);
                }
            }
        }

        /// <summary>
        /// Удаление одной буквы из окончания и замена его на другую букву
        /// </summary>
        /// <param name="word"></param>
        /// <param name="AccentDictionary"></param>
        /// <returns></returns>
        private string DelOneEnd(string word, Dictionary<string, string> AccentDictionary)//Удаление одной буквы в слове и замена на другую
        {
            string NewWord = "";
            string[] ABC = {"а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я"};
            NewWord = word.Remove(word.Length - 1);
            if (!AccentDictionary.ContainsKey(NewWord))
            {
                string s = NewWord;
                for (int i=0; i< ABC.Length; i++)
                {
                    NewWord = s + ABC[i];
                    if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
                }
            }
            if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
            return word;
        }


        private string DelEndAddAbout(string word, Dictionary<string, string> AccentDictionary, int lenght=1)//Удаление нескольких букв в слове (от 1 до lenght) и проверка по морфологическому словарю
        {
            string NewWord = "";
            NewWord = word.Remove(word.Length - lenght);
            if (!AccentDictionary.ContainsKey(NewWord))
            {
                for (int j = 0; j < lexgroup.Length; j++)
                {
                    for (int k = 0; k < lexgroup[j].MassWords.Length; k++)
                    {
                        if (NewWord == lexgroup[j].MassWords[k])
                        {
                            string s = NewWord;
                            for (int l = 0; l < lexgroup[j].ends.Length; l++)
                            {
                                NewWord = s + lexgroup[j].ends[l];
                                if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
                            }
                        }
                    }
                }
            }
            if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
            return word;
        }

        /// <summary>
        /// Удаление окончания и добавление другого 
        /// </summary>
        /// <param name="word">Входяшее слово</param>
        /// <returns></returns>
        public string AddAbout(string word, Dictionary<string,string> AccentDictionary)//Удаление окончаний по словарю окончаний и замена окончания на другое из морфологического словаря
        {
            string NewWord = "";
            //Массив окончаний
            string[] ThreeAbout = { "ать", "ять", "оть", "еть", "уть", "у", "ю", "ем", "ешь", "ете", "ет","ут","ют","ал","ял","ала","яла","али","яли","ул","ула","ули",
                "а","я","о","е","ь","ы","и","ая","яя","ое","ее","ой","ые","ие","ый","йй",
                "ам","ами","ас","aм","ax","ая","её","ей","ем","еми","емя","ex","ею","ёт","ёте","ёх","ёшь","ий","ие","им","ими","ит","ите","их","ишь","ию","м","ми",
                "мя","ов","ого","ое","оё","ой","ом","ому","ою","ум","умя","ут","ух","ую","шь","ый"};
            for (int i = 0; i < ThreeAbout.Length; i++)
            {
                if (word.EndsWith(ThreeAbout[i]))
                {
                    NewWord = word.Replace(ThreeAbout[i], "");
                    if (!AccentDictionary.ContainsKey(NewWord))
                    {
                        for (int j = 0; j < lexgroup.Length; j++)
                        {
                           for(int k=0;k < lexgroup[j].MassWords.Length; k++)
                            {
                                if(NewWord == lexgroup[j].MassWords[k])
                                {
                                    for (int l = 0; l < lexgroup[j].ends.Length; l++)
                                    {
                                        NewWord = NewWord + lexgroup[j].ends[l];
                                        if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
                                    }
                                }
                            }
                      }
                    }
                    break;
                }
            }
            if (AccentDictionary.ContainsKey(NewWord)) { return NewWord; }
            return word;
        }

        /// <summary>
        /// Проверка и изменение слова для добавления его в словарь
        /// </summary>
        /// <param name="newAccent"></param>
        /// <param name="oldWord"></param>
        public void Verify(string newAccent, string oldWord)
        {
            //Получение номера слога где находится ударение
            int NumberSlogAccent = AccentInSlogs(SlogSpliter(WordAccentDictionary[newAccent]));
            if (NumberSlogAccent <= SlogSpliter(oldWord).Length) //Если ударение не выходит за рамки
            {
                string[] NewAccentWord = WordAccentDictionary[newAccent].Split('\'');
                string PartOldWord = oldWord.Remove(0,NewAccentWord[0].Length);
                NewAccentWord[0] += "'";
                NewAccentWord[0] += PartOldWord;
                AddAccentToDictionary(oldWord, NewAccentWord[0]);
            }
               
        }

        public void AddAccentToDictionary(string word, string Accent)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\BD\" + "Slovar_udareny.txt";
            string text = "!" + word + " " + Accent;
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Seek(0, SeekOrigin.End);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
            }
            
        }

        public string[] SlogSpliter(string word)
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

        public int AccentInSlogs(string[] wordslog)
        {
            for(int i=0; i<wordslog.Length;i++)
            {
                if (wordslog[i].Contains("'"))
                {
                    return i;
                }
            }
            return 256;
        }

        //Помощь
        private void какПользоватьсяПрограммойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KakPolzovatsyaProgrammoi Helped = new KakPolzovatsyaProgrammoi();
            Helped.Owner = this;
            Helped.Show();
        }

        //Об Авторе
        private void AboutAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Owner = this;
            author.Show();
        }

        //Окончания
        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndDictionary ends = new EndDictionary();
            ends.Owner = this;
            ends.Show();
        }

        private void просмотрToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            accentForm accentForm = new accentForm(WordAccentDictionary);
            accentForm.Owner = this;
            accentForm.Show();
        }
        
        private void добавитьФайлLEXGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Использование делегата для возможности использования функции из дочерней формы AddAccent
            AddaccentForm AddaccentForm = new AddaccentForm(WordAccentDictionary, new MyDelegate(AddAccentToDictionary));
            AddaccentForm.Owner = this;
            AddaccentForm.Show();
        }

        private void просмотрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MorphDictionary Morph = new MorphDictionary(lexgroup);
            Morph.Owner = this;
            Morph.Show();
        }

        private void добавитьУдарениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlex = 0;
            AddFileToLexGroup AddtoMorph = new AddFileToLexGroup(lexgroup, new Delegate2(ReadAllFiles));
            AddtoMorph.Owner = this;
            AddtoMorph.Show();
        }
    }
}
