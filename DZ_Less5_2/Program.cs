using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Less5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Соответствует концу строкового выражения или концу строки при многострочном поиске";

            //Message.DelWordsByEndSymb('у', ref s);

            WriteLine(Message.WordsMaxLength(s));

            ReadLine();
        }
    }
}
