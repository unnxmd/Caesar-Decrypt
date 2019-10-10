using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Caesar_Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            char[,] mas = StringToMatrix(str);
            int size = Convert.ToInt32(Math.Sqrt(str.Length));
            //Console.WriteLine(MatrixToString(mas));
            List<int> l = new List<int>();
            List<string> results = new List<string>();
            String[] imp_combs = { "__", "_Ы", "ЁЯ", "ЁЬ", "ЁЭ", "ЪЖ", "ЭЁ", "ЪД", "ЦЁ", "УЬ", "ЩЧ", "ЧЙ",
            "ШЙ", "ШЗ", "ЫФ", "ЖЩ", "ЖШ", "ЖЦ", "ЫЪ", "ЫЭ", "ЫЮ", "ЫЬ", "ЖЙ", "ЫЫ", "ЖЪ",
            "ЖЫ", "ЪШ", "ПЙ", "ЪЩ", "ЗЩ", "ЪЧ", "ЪЦ", "ЪУ", "ЪФ", "ЪХ", "ЪЪ", "ЪЫ", "ЫО",
            "ЖЯ", "ЗЙ", "ЪЬ", "ЪЭ", "ЫА", "НЙ", "ЕЬ", "ЦЙ", "ЬЙ", "ЬЛ", "ЬР", "ПЪ", "ЕЫ",
            "ЕЪ", "ЬА", "ШЪ", "ЁЫ", "ЁЪ", "ЪТ", "ЩС", "ОЬ", "КЪ", "ОЫ", "ЩХ", "ЩЩ", "ЩЪ",
            "ЩЦ", "КЙ", "ОЪ", "ЦЩ", "ЛЪ", "МЙ", "ШЩ", "ЦЬ", "ЦЪ", "ЩЙ", "ЙЬ", "ЪГ", "ИЪ",
            "ЪБ", "ЪВ", "ЪИ", "ЪЙ", "ЪП", "ЪР", "ЪС", "ЪО", "ЪН", "ЪК", "ЪЛ", "ЪМ", "ИЫ",
            "ИЬ", "ЙУ", "ЩЭ", "ЙЫ", "ЙЪ", "ЩЫ", "ЩЮ", "ЩЯ", "ЪА", "МЪ", "ЙЙ", "ЙЖ", "ЬУ",
            "ГЙ", "ЭЪ", "УЪ", "АЬ", "ЧЪ", "ХЙ", "ТЙ", "ЧЩ", "РЪ", "ЮЪ", "ФЪ", "УЫ", "АЪ",
            "ЮЬ", "АЫ", "ЮЫ", "ЭЬ", "ЭЫ", "БЙ", "ЯЬ", "ЬЫ", "ЬЬ", "ЬЪ", "ЯЪ", "ЯЫ", "ХЩ",
            "ДЙ", "ФЙ" };

            for (int i = 1; i <= size; i++) l.Add(i);
            IEnumerable<List<int>> lst = AllCombinations(l, new List<int>());

            foreach (var b in lst)
            {
                int[] list = new int[size];
                int i = 0;
                foreach (var a in b)
                {
                    list[i] = a;
                    i++;
                }
                results.Add(MatrixToString(Rearrange(mas, list)));
            }
            Console.WriteLine("    До обработки: " + results.Count + " элементов");
            List<string> results_sorted = new List<string>();
            var pattern = @"(.)\1{2}";

            foreach (string res in results)
            {
                int i = 0;
                foreach (string impc in imp_combs)
                {
                    if (res.Contains(impc) || res.First() == '_' || res.Last() == '_' || Regex.IsMatch(res, pattern)) i++;
                }
                if (i == 0)
                {
                    results_sorted.Add(res);
                }
            }

            Console.WriteLine("    После обработки: " + results_sorted.Count + " элементов");
            Console.ReadLine();
            foreach (string res in results_sorted)
            {
                Console.WriteLine(res);
            }
            Console.WriteLine("-------------------------");
            Console.ReadLine();
            foreach (string res in results)
            {
                Console.WriteLine(res);
            }
            Console.ReadLine();
        }

        static char[,] Rearrange(char[,] charMs, int[] lst)
        {
            int size = Convert.ToInt32(Math.Sqrt(charMs.Length));
            char[,] mas = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = charMs[lst[i] - 1, j];
                }
            }
            return mas;
        }

        static char[,] StringToMatrix(string str)
        {
            int size = Convert.ToInt32(Math.Sqrt(str.Length));
            char[,] charMs = new char[size, size];
            char[] strng = str.ToCharArray();
            int c = 0;

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    charMs[i, j] = strng[c];
                    c++;
                }
            }

            return charMs;
        }

        static string MatrixToString(char[,] charMs)
        {
            string str = "";
            int size = Convert.ToInt32(Math.Sqrt(charMs.Length));
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    str += charMs[i, j];
                }
            }
            return str;
        }

        private static IEnumerable<List<int>> AllCombinations(List<int> arg, List<int> awithout)
        {
            if (arg.Count == 1)
            {
                var result = new List<List<int>>();
                result.Add(new List<int>());
                result[0].Add(arg[0]);
                return result;
            }
            else
            {
                var result = new List<List<int>>();

                foreach (var first in arg)
                {
                    var others = new List<int>(arg.Except(new int[1] { first }));
                    awithout.Add(first);
                    var other = new List<int>(others.Except(awithout));

                    var combinations = AllCombinations(other, awithout);
                    awithout.Remove(first);

                    foreach (var tail in combinations)
                    {
                        tail.Insert(0, first);
                        result.Add(tail);
                    }
                }
                return result;
            }
        }
    }
}
