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
    public partial class MorphDictionary : Form
    {
        LEXGROUP[] lex;
        public MorphDictionary(LEXGROUP[] lexgroup)
        {
            lex = lexgroup;
            InitializeComponent();
            for (int i = 0; i < lex.Length; i++)
            {
                listBox1.Items.Add(lex[i].endstring);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            wordsBox.Text = "";
            // Get the currently selected item in the ListBox.
            string curItem = listBox1.SelectedItem.ToString();
            for (int i = 0; i < lex.Length; i++)
            {
                if (curItem == lex[i].endstring)
                {
                    for (int k = 0; k < lex[i].MassWords.Length; k++)
                    {
                        wordsBox.Text += lex[i].MassWords[k] + "\n";
                    }
                }
            }
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
