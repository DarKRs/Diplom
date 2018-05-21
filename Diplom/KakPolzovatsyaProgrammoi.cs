using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class KakPolzovatsyaProgrammoi : Form
    {
        public KakPolzovatsyaProgrammoi()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = listBox1.SelectedItem.ToString();
            
            if (curItem == "Общее")
            {
                HelpedText.Text = "Общее \n\n Для того чтобы найти возможные стихотворные метры в тексте и/ или стихотворении вам следует написать текст и/ или стихотворный метр в текстовое окно слева(доступное для записи),так же вы можете открыть файл с расширением .txt для того что бы заполнить левое окно текстом из файла.После этого следует нажать на кнопку 'Найти стихи >>' и результат выполнения программы появится в правом текстовом окне.В качестве результата будет выведена информация о найденных ударениях и слогах для слов находящихся в тексте, далее будет выведены структуры и определения этих структур если были найдены совпадения.";
            }
            else if (curItem == "Морфологический словарь")
            {
                HelpedText.Text = "Морфологический словарь \n\n Морфологический словарь нужный для создания слов в производных формах глаголов состоит из окончаний и слов к которым эти окончания подходят. Вы можете просмотреть словарь во вкладке Словари->Морфологический словарь->Просмотр. \n Так же есть возможность добавить свой файл к морфологическому словарю. Программа сама преобразует файл под нужный вид.";
            }
            else if (curItem == "Словарь ударений")
            {
                HelpedText.Text = "Словарь ударений \n\n Словарь ударений нужный для формирования строки безударных и ударных слогов для последующего нахождения стихотворных размеров. Вы можете посмотреть слова и ударения к нему во вкладке Словари->Словарь ударений->Просмотр. \n Так же есть возможность добавить свое слово с ударением к словарю ударений. \n !Запомните значок ударения \"'\" всегда ставится перед буквой на которую падает, а не после!";
            }
            else
            {
                HelpedText.Text = "";
            }
        }
    }
}
