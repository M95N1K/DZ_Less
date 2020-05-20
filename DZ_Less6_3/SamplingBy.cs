using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Less6_3
{
    public enum SamplingBy
    {
        Faculty = 0,
        Departament,
        Age,
        Course,
        Group,
        City
    }

    public static class HelpSampl
    {
        public static string SamplToString(this SamplingBy value)
        {
            switch (value)
            {
                case SamplingBy.Faculty:
                    return "Факультет";
                case SamplingBy.Departament:
                    return "Кафедра";
                case SamplingBy.Age:
                    return "Возраст";
                case SamplingBy.Course:
                    return "Курс";
                case SamplingBy.Group:
                    return "Группа";
                case SamplingBy.City:
                    return "Город";
                default:
                    return "";
            }
        }
    }
}
