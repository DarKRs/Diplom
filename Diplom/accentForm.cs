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
    public partial class accentForm : Form
    {
        public accentForm(Dictionary<string, string> WordAccentDictionary)
        {
            InitializeComponent();
            ShowIterator<string,string>(WordAccentDictionary);
        }

        void ShowIterator<K, V>(Dictionary<K, V> myList)
        {
            if (myList == null)
                return;

            string s = "";

            foreach (KeyValuePair<K, V> kvp in myList)
                s += string.Format("{0} \t  {1}",
                    kvp.Key, kvp.Value) + Environment.NewLine;

            Dictionary.Text += s;
        }

        private void accentForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
