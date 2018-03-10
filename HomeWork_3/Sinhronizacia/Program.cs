using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sinhronizacia_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new List<int>();
            var r = new List<int>();

            var a = new Thread(() =>
            {
                for (int i = 1; i < 20; i++)
                {
                    Console.WriteLine("Поток A добавляет в список S число {0}", i);
                    s.Add(i);
                }
            });

            var b = new Thread(() =>
            {
                Console.WriteLine("Поток B извлекает из списка S последний элемент, возводит его в квадрат и помещает в список R");
                if (s.Count == 0)
                    Thread.Sleep(1000);
                r.Add(s.Last() * s.Last());
            });

            var c = new Thread(() =>
            {
                Console.WriteLine("Поток C извлекает из списка S последний элемент, делит его на 3 и помещает в список R");
                if (s.Count != 0)
                    r.Add(s.Last() / 3);
            });

            var d = new Thread(() =>
            {
                Console.WriteLine("Поток D извлекает из списка R последний элемент и печатает его");
                if (r.Count == 0)
                {
                    Console.WriteLine("В списке R нет элементов");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Последний элемент из списка R = {0}", r.Last());
            });
            new Thread(() =>
            {
                a.Start();
                b.Start();
                c.Start();
                d.Start();
            }).Start();
          
            Console.ReadKey();
        }
    }
}
