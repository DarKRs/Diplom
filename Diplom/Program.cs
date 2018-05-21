using System;
using System.Windows.Forms;

namespace Diplom
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SearchVerse());
        }
    }
    public delegate void Delegate2(string path, int leng);
    /// <summary>
    /// Делегат заменяющий функцию AddAccentToDictionary в дочерних формах
    /// </summary>
    /// <param name="data">Слово</param>
    /// <param name="data2">Слово с ударением</param>
    public delegate void MyDelegate(string word, string Accent);

    
}
