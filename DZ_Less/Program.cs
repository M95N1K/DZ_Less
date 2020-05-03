using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClass;

namespace DZ_Less2_1
{
    class Program
    {
        static int MinX(int a=3, int b=7, int c=5)
        {
            if (a < b)
                b = a;
            if (b < c)
                c = b;
            return c;
        }
        static void Main(string[] args)
        {
            Cons.Print(MinX());
        }
    }
}
