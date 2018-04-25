using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class LEXGROUP
    {
        public string[] ends; //Массив окончаний лексической группы
        public string words; //Слова к которым эти окончания подходят

        //Удаление запятых в конце words
        public void DeleteCom() {
            if (words != null) { this.words = this.words.Remove(this.words.LastIndexOf(',')); };
        }

    }
}
