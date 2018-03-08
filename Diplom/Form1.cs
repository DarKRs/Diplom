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
            WordsAccent = file.Split(' ');
            WordsAccent = WordsAccent.Where(x => x != "").ToArray();
            /////////////////////////////////////////////////////
            reader.Close();
            fs.Close();
            /////////////////////Загрузка словаря слогов////////////////////////
            string A = "Slovar_udareny.txt";
            FileStream fs = new FileStream(path + A, FileMode.Open);
            StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);
            string file = reader.ReadToEnd();
            file = ReplaceNR(file);
            WordsAccent = file.Split(' ');
            WordsAccent = WordsAccent.Where(x => x != "").ToArray();

        }

        private void button2_Click(object sender, EventArgs e)//Найти стихи >>
        {
            string Sourse;
            Sourse = SourseText.Text;
            Words = Sourse.Split(' ');
            ////////////////////////////

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

        private string ReplaceNR(string file)//Убирание новой строки и кареток \n & \r
        {
            var ReN = new Regex("\n");
            var ReR = new Regex("\r");
            file = ReN.Replace(file, "");
            file = ReR.Replace(file, "");
            return file;
        }

    }
}
