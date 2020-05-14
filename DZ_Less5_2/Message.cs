using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Less5_2
{
    static class Message
    {
        static char[] separators = new char[] { ',', ' ', '.', '/', '\\', '!', ':', ';', '?', '<', '>', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '[', ']', '{', '}', '"', '\'', '|' ,'\n'};
        /// <summary>
        /// Возвращает слова длина которых менее maxSymbol
        /// </summary>
        /// <param name="inputText">Входной текст</param>
        /// <param name="maxSymbol">Максимальная длина выбираемых слов</param>
        /// <returns></returns>
        public static string WordsMaxSymbols(string inputText, int maxSymbol)
        {
            string result = "";
            
            string[] arrWord = inputText.Split(separators);

            foreach (string item in arrWord)
            {
                if (item.Length < maxSymbol)
                    result += ' ' + item;
            }
            return result;
        }

        /// <summary>
        /// Удаляет слова которые заканчиваются на bySymbol
        /// </summary>
        /// <param name="bySymbol">Символ по которому удалябтся слова</param>
        /// <param name="text">Текст в котором надо удалить слова</param>
        public static void DelWordsByEndSymb(char bySymbol , ref string text)
        {
            List<string> tmpstring = new List<string>();
            int position = 0;
            int start = 0;
            do
            {
                position = text.IndexOfAny(separators,start);
                if (position >=0)
                {
                    string tmp = text.Substring(start, position - start + 1).Trim();
                    if ((tmp[tmp.Length - 1] != bySymbol))
                        tmpstring.Add(tmp);
                    tmpstring.Add(text.Substring(position, 1));
                    start = position + 1;
                }
            } while (position > 0);

            text = "";
            foreach (string tmp in tmpstring)
            {
                text += tmp;
            }
        }

        /// <summary>
        /// Возвращает самое длинное слово
        /// </summary>
        /// <param name="text">Входящий текст</param>
        /// <returns>Слово</returns>
        public static string WordMaxLength(string text)
        {
            string[] arrWords = text.Split(separators);
            string result = arrWords[0];

            for (int num = 1; num < arrWords.Length; num++)
            {
                if (result.Length < arrWords[num].Length)
                    result = arrWords[num];
            }
            return result;
        }

        /// <summary>
        /// Возвращает слова максимальной длины использовался StringBuilder
        /// </summary>
        /// <param name="text">Входящий текст</param>
        /// <returns>Слова</returns>
        public static string WordsMaxLength(string text)
        {
            StringBuilder result = new StringBuilder();
            string[] arrWords = text.Split(separators);
            int maxLength = WordMaxLength(text).Length;

            foreach (string word in arrWords)
            {
                if (word.Length == maxLength)
                {
                    result.Append(word);
                    result.Append(" ");
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Возвращает частоту вхождения слов из words в тексте text
        /// </summary>
        /// <param name="words">Массив слов которых надо подсчитать</param>
        /// <param name="text">Текст в котором нужно подсчитать</param>
        /// <returns></returns>
        public static Dictionary<string, int> WordFrequency(string[] words, string text)
        {
            string[] arrWord = text.Split(separators);
            Dictionary<string, int> result = new Dictionary<string, int>();
            
            for (int i = 0; i < words.Length; i++)
            {
                result.Add(words[i].ToUpper(), 0);
            }

            for (int i = 0; i < arrWord.Length; i++)
            {
                if (result.ContainsKey(arrWord[i].ToUpper()))
                    result[arrWord[i].ToUpper()]++;
            }
            return result;
        }

        /// <summary>
        /// Возвращает WordFrequency (Dictionary<string , int>) в виде таблицы Key - Value
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string DictToString(this Dictionary<string , int> dict)
        {
            string result = "";

            foreach (KeyValuePair<string , int> item in dict)
            {
                result += string.Format("{0} - {1} \n", item.Key,item.Value );
            }
            
            return result;
        }
    }
}
