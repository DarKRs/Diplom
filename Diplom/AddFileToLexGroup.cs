using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class AddFileToLexGroup : Form
    {
        Delegate2 d;
        LEXGROUP[] lex;
        public AddFileToLexGroup(LEXGROUP[] lexgroup, Delegate2 sender)
        {
            InitializeComponent();
            d = sender;
            lex = lexgroup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddOpen.ShowDialog();
                string path = AddOpen.FileName;
                string DestPath = System.IO.Directory.GetCurrentDirectory() + @"\BD\LexGroup\GLAG\";
                int number = new DirectoryInfo(DestPath).GetFiles().Length + 300;
                string numb = number.ToString();
                if (AddOpen.FileName != "") //если в окне была нажата кнопка "ОК"
                {

                    File.Copy(path, DestPath + "LEXGROUP." + numb);
                    d(DestPath, new DirectoryInfo(DestPath).GetFiles().Length);
                }
            }
            catch { }
            //Непонятно на что жалутся. Просто исключение не выскакивает!!!!!!!!
           /* catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Не удалось открыть файл", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
