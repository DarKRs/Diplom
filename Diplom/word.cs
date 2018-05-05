using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    class word
    {
        public string[] slogs;
        public string Accent;


        /////////////////////Формирование "слогов" (Разбиение по гласным)////////////////////////
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

        /// <summary>
        /// Возвращает на каком месте в слове стоит ударение.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int AccentInSlogs()
        {
            string word = this.Accent;
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
            for(int i=0; i <slogs.Length; i++)
            {
                if (slogs[i].Contains("'"))
                {
                    return i;
                }
            }
            return 256;
        }
    }
}
