using System.Linq;

namespace Diplom
{
    public class LEXGROUP
    {
        public string[] ends; //Массив окончаний лексической группы
        public string endstring;
        public string words; //Слова к которым эти окончания подходят
        public string[] MassWords; //Массив слов

        //Удаление запятых в конце words
        public void DeleteCom() {
            if (words != null) { this.words = this.words.Remove(this.words.LastIndexOf(',')); };
        }

        public void CompareEnds()
        {
            
            if (ends != null)
            {
                ends = ends.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                for (int i=0; i < ends.Length; i++)
                {
                    endstring += ends[i] + ",";
                }
            }
        }
    }
}
