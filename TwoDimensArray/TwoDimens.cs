using System;
using System.IO;

namespace TwoDimensArray
{
    public class TwoDimens
    {
        int[,] twoDA;

        /// <summary>
        /// Максимальный элемент массива
        /// </summary>
        public int MaxElement
        {
            get { return Max(); }
        }

        /// <summary>
        /// Минимальный элемент массива
        /// </summary>
        public int MinElement
        {
            get { return Min(); }
        }

        /// <summary>
        ///     Конструктор заполняющий двумерный массив случайными числами от 0 до 1000
        /// </summary>
        /// <param name="row">Количество строк</param>
        /// <param name="column">Количество столбцов</param>
        public TwoDimens(int row, int column)
        {
            Random rnd = new Random();
            twoDA = new int[row, column];

            for (int colR = 0; colR < row; colR++)
            {
                for (int colC = 0; colC < column; colC++)
                {
                    twoDA[colR, colC] = rnd.Next(1000);
                }
            }
        }

        /// <summary>
        ///     Возвращает сумму элементов массива которые больше чем min, если min >= 0 
        /// </summary>
        /// <param name="min"> Если min не указан или меньше 0 возврящяет сумму всех элементов массива</param>
        public int SumElement(int min = -1)
        {
            if (min < 0)
                return Sum();
            else return SumIf(min);
        }

        /// <summary>
        ///     Возаращает позицию максимального элемента
        /// </summary>
        /// <param name="row">Возвращает номер строки максимального элемента</param>
        /// <param name="column">Возвращает номер столбца максимального элемента</param>
        public void NumMaxElement(ref int row, ref int column)
        {
            int max = twoDA[0, 0];
            for (int crow = 0; crow < (twoDA.Length / twoDA.GetLength(0)); crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    if (twoDA[crow, ccol] > max)
                    {
                        row = crow;
                        column = ccol;
                        max = twoDA[crow, ccol];
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает элементы массива в виде таблицы
        /// </summary>
        public override string ToString()
        {
            string result = "";
            for (int crow = 0; crow < (twoDA.Length / twoDA.GetLength(0)); crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    result += twoDA[crow, ccol] + "\t";
                }
                result += "\n";
            }
            return result;
        }

        /// <summary>
        /// Записывает массив в файл
        /// </summary>
        public void WriteToFile(string filePath)
        {
            StreamWriter file;
            try
            {
                file = new StreamWriter(filePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Проблемы при работе с файлами");
                throw;
            }

            for (int crow = 0; crow < (twoDA.Length / twoDA.GetLength(0)); crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    file.WriteLine(twoDA[crow, ccol]);
                }
            }
            file.Dispose();
        }

        /// <summary>
        /// Конструктор Заполняющий массив размерностью rowXcolumn из файла 
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="row">Количество строк</param>
        /// <param name="column">Количество столбцов</param>
        public TwoDimens(string filePath, int row, int column)
        {
            StreamReader file;
            twoDA = new int[row, column];

            try
            {
                file = new StreamReader(filePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Проблемы при работе с файлами");
                throw;
            }

            for (int crow = 0; crow < (twoDA.Length / twoDA.GetLength(0)); crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    if (!int.TryParse(file.ReadLine(), out twoDA[crow, ccol]))
                    {
                        //Console.WriteLine("Ошибка при заполнении массива");
                        throw new Exception("Ошибка при заполнении массива");
                    }

                }
            }
            file.Dispose();
        }

        #region Приватные методы

        private int Sum() //  Сумирует все элементы массива
        {
            int result = 0;
            int colrow = twoDA.Length / twoDA.GetLength(0);
            for (int crow = 0; crow < colrow; crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    result += twoDA[crow, ccol];
                }
            }
            return result;
        }

        private int SumIf(int min) //  Сумирует все элементы массива больше чем min
        {
            int result = 0;
            int colrow = twoDA.Length / twoDA.GetLength(0);
            for (int crow = 0; crow < colrow; crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    if (twoDA[crow, ccol] > min)
                        result += twoDA[crow, ccol];
                }
            }
            return result;
        }

        private int Max() //    Возвращает максимальный элемент массива
        {
            int result = twoDA[0, 0];
            int colrow = twoDA.Length / twoDA.GetLength(0);
            for (int crow = 0; crow < colrow; crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    if (twoDA[crow, ccol] > result)
                        result = twoDA[crow, ccol];
                }
            }
            return result;
        }

        private int Min() //    Возвращает минимальный элемент массива
        {
            int result = twoDA[0, 0];
            int colrow = twoDA.Length / twoDA.GetLength(0);
            for (int crow = 0; crow < colrow; crow++)
            {
                for (int ccol = 0; ccol < twoDA.GetLength(0); ccol++)
                {
                    if (twoDA[crow, ccol] < result)
                        result = twoDA[crow, ccol];
                }
            }
            return result;
        }

        #endregion
    }
}
