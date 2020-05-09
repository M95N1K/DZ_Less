using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Less4_2
{
    static class Arrays
    {
        public static int ColDiv3(int[] value)
        {
            int count = 0;
            for (int i = 0; i < value.Length - 1; i++)
            {
                if ((value[i] % 3 == 0) && (value[i + 1] % 3 != 0))
                    count++;
            }

            return count;
        }

        public static int[] ReadFromFile(string filePath , int maxElementCount = 20)
        {
            int[] result = new int[maxElementCount];
            int count = 0;

            StreamReader file = new StreamReader(filePath);
           

            while (!file.EndOfStream)
            {
                try
                {
                    string sLine = file.ReadLine();
                    result[count] = int.Parse(sLine);
                    count++;
                    if (count > maxElementCount) break;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                
            }

            return result;
        }
    }
}
