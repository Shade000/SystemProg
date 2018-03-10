using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** ПРОЦЕССЫ ***\n");
            string proc = Process();
            Menu(proc);
            if (proc != "X")
                Main();
        }
        static void Menu(string str)
        {
            var qqq = new MyProcess();
            switch (str)
            {
                case "X":
                    break;
                case "1":
                    qqq.ShowAllProcess();
                    break;
                case "2":
                    qqq.ShowAllProcess();
                    break;
                case "3":
                    qqq.StartProcess(@"F:\System Programming\1.txt");
                    break;
                case "4":
                    qqq.StopProcess(5100);
                    break;
                case "5":
                    qqq.ShowThreadInfo();
                    break;
                case "6":
                    qqq.ShowModulsInfo(0);
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }
        static string Process()
        {
            Console.WriteLine("Какую информацию нужно получить? \n" +
                " 1 - Список всех процессов\n 2 - Выбрать процесс по PID\n" +
                " 3 - Запуск процесса\n 4 - Останов процесса\n" +
                " 5 - Информация о потоках\n 6 - Информация о подключаемых модулях\n X - выход\n");
            Console.Write("Введите команду: ");
            string proc = Console.ReadLine();
            return proc;
        }
    }
}
