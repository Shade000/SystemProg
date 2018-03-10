using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sinhronizacia_Task_2
{
    class Program
    {
        private static readonly object _locker_S = new object();
        private static readonly object _locker_R = new object();
        static void Main(string[] args)
        {
            var s = new List<int>();
            var r = new List<int>();

            var a = new Thread(() =>
            {
                while (true)
                {
                    lock (_locker_S)                        
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            Console.WriteLine("Поток A добавляет в список S число {0}", i);
                            s.Add(i);
                        }
                    }
                }
            });

            var b = new Thread(() =>
            {
                int x = 0;
                while (true)
                {
                    if (s.Count == 0)
                        Thread.Sleep(1000);
                    else
                    {
                        lock (_locker_S)
                        {
                            Thread.Sleep(1500);
                            lock (_locker_R)
                            {
                                Console.WriteLine("Поток B извлекает из списка S последний элемент, возводит его в квадрат и помещает в список R");
                                x = s.Last();
                                r.Add(x * x);
                            }
                        }
                    }
                }
            });

            //Взаимоблокировка
            //var b = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        int x = 0;
            //        lock (_locker_S)
            //        {
            //            if (s.Count == 0)
            //            {
            //                Thread.Sleep(1000);
            //            }
            //            x = s.Last();
            //            lock (_locker_R)
            //            {
            //                Console.WriteLine("Поток B извлекает из списка S последний элемент, возводит его в квадрат и помещает в список R");
            //                Thread.Sleep(3000);
            //                r.Add(x * x);
            //            }
            //        }
            //        lock (_locker_R)
            //        {
            //            lock (_locker_S)
            //            {
            //                Thread.Sleep(3000);
            //                Console.WriteLine("Последний элемент из списка S = {0}", s.Count);
            //            }
            //        }
            //    }     
            //});

            var c = new Thread(() =>
            {
                int x = 0;
                while (true)
                {
                    if (s.Count == 0)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        lock (_locker_R)
                        {
                            Thread.Sleep(1500);
                            lock (_locker_S)
                            {
                                Console.WriteLine("Поток C извлекает из списка S последний элемент, делит его на 3 и помещает в список R");
                                x = s.Last();
                                r.Add(x / 3);
                            }
                        }
                    }
                }
            });

            var d = new Thread(() =>
            {
                while (true)
                {
                    if (r.Count == 0)
                    {
                        Console.WriteLine("В списке R нет элементов");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        lock (_locker_R)
                        {
                            Console.WriteLine(r.Last());
                        }
                    }
                }
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
