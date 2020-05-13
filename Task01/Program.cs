/*
    Дисциплина:     "Программирование"
    Группа:         196ПИ/1 (11 подгруппа)
    Студент:        Кузнецов Михаил Федорович
    Задача:         1
    Дата:           13.05.2020 17:36:46
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWLibrary;
using System.Security;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// Считывает переменную типа int.
        /// </summary>
        /// <param name="x">Переменная, в которую необходимо считать значение.</param>
        /// <param name="pr">Условие, накладываемые на переменную.</param>
        /// <param name="outStr">Сообщение пользователю.</param>
        static void ReadInt(out int x, Predicate<int> pr, string outStr)
        {
            if (outStr != "")
                Console.WriteLine(outStr);
            while (!(int.TryParse(Console.ReadLine(), out x) && pr(x)))
            {
                Console.WriteLine("Ошибка ввода");
                if (outStr != "")
                    Console.WriteLine(outStr);
            }
        }

        static Random rnd = new Random();

        static string GenRus()
        {
            int count = rnd.Next(5, 10);
            string s = "";
            for (int i = 0; i < count; i++)
                s += (char)('а' + rnd.Next(32));
            return s;
        }

        static string GenEng()
        {
            int count = rnd.Next(5, 10);
            string s = "";
            for (int i = 0; i < count; i++)
                s += (char)('a' + rnd.Next(26));
            return s;
        }

        static void GenFile(int N)
        {
            string[] arr = new string[N];
            for (int i = 0; i < N; i++)
                arr[i] = GenRus() + ' ' + GenEng();
            try
            {
                File.WriteAllLines("../../../dictionary.txt", arr);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadFile(Dictionary dict)
        {
            try
            {
                string[] arr = File.ReadAllLines("../../../dictionary.txt");
                foreach (var pair in arr)
                {
                    var el = pair.Split();
                    dict.Add(el[0], el[1]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            ReadInt(out int N, (x) => x > 0, "Введите колличество строк");
            GenFile(N);
            Dictionary dict = new Dictionary();
            ReadFile(dict);
            WriteDict(dict);
            dict.MySerialize("out.bin");
            Console.WriteLine();
            Console.WriteLine("Сериализация");
            Console.WriteLine();
            Dictionary dict2 = Dictionary.MyDeserialize("out.bin");
            Console.WriteLine("Десериализация");
            Console.WriteLine();
            WriteDict(dict2);
            Console.ReadLine();
        }

        private static void WriteDict(Dictionary dict)
        {
            foreach (var pair in dict)
                Console.WriteLine(pair);
        }
    }
}
