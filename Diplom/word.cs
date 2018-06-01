using System.Collections.Generic;

namespace Diplom
{
    class word
    {
        public string[] slogs;
        public string Accent;
        public string[] Accentslogs;


        /////////////////////Формирование "слогов" (Разбиение по гласным)////////////////////////
        public string[] SlogSpliter(string word)
        {
            string[] glas = { "а", "у", "е", "ё", "о", "я", "и", "э", "ю" };
            word = word.ToLower();

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
                //if (glasIndexes[i] - glasIndexes[i - 1] == 1)
                //    continue;
                string symbol = word.Substring(glasIndexes[i] - 1, 1);
                if (symbol == "ь" || symbol == "ъ")
                {
                    int n = glasIndexes[i] - glasIndexes[i - 1] - 1;
                    result = "-" + word.Substring(glasIndexes[i]) + result;
                    word = word.Remove(glasIndexes[i]);
                }
                else
                {
                    int n = glasIndexes[i] - glasIndexes[i - 1] - 1;
                    int ind = glasIndexes[i - 1] + 1 + n / 2;
                    symbol = word.Substring(ind, 1);
                    if (symbol == "ь" || symbol == "ъ") ind++;

                    result = "-" + word.Substring(ind) + result;
                    word = word.Remove(ind);
                }

            }
            result = word + result;
            string[] slogs = result.Split('-');
            return slogs;
        }

    }
}
