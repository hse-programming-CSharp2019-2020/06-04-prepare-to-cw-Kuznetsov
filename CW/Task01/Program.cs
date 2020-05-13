/*
    Дисциплина:     "Программирование"
    Группа:         196ПИ/1 (11 подгруппа)
    Студент:        Кузнецов Михаил Федорович
    Задача:         1
    Дата:           13.05.2020 17:36:46
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
            do
            {

                // Цикл повтора решения.
                Console.WriteLine("Для завершение программы нажмите клавишу 'Esc', или любую другую клавишу для продолжение.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
