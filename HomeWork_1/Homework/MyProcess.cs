using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class MyProcess:IProcess
    {
        public void ShowAllProcess()
        {
            var process = Process.GetProcesses(".").Select(proc => proc).OrderBy(proc => proc.Id);
            int i = 0;
            foreach (var item in process)
            {
                i++;
                Console.WriteLine("{0}: PID {1} Name {2}", i, item.Id, item.ProcessName);
            }
            Console.ReadKey();
        }

        public void SelectProcess(int id)
        {
            try
            {
                var process = Process.GetProcessById(id);
                Console.WriteLine("1: PID {0} Name {1}", process.Id, process.ProcessName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ID");
            }
            Console.ReadKey();
        }

        public void ShowModulsInfo(int id)
        {
            try
            {
                var procces = Process.GetProcessById(id);
                var moduls = procces.Modules;

                foreach (ProcessModule modul in moduls)
                {
                    Console.WriteLine("Name - {0} MemorySize : {1}", modul.ModuleName, modul.ModuleMemorySize);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ID", ex.Message);
            }
            Console.ReadKey();
        }

        public void ShowThreadInfo()
        {
            string nameProc = GetProcessName();
            try
            {
                var proc = Process.GetProcessesByName(nameProc)[0];
                ProcessThreadCollection threads = proc.Threads;
                Console.WriteLine("Количество потоков для данного процесса = {0}", threads.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartProcess(string adressProcess)
        {
            try
            {
                Process.Start(adressProcess);
                Console.WriteLine("Start process");
            }
            catch (Exception)
            {
                Console.WriteLine("bad path");
            }
            Console.ReadKey();
        }

        public void StopProcess(int id)
        {
            try
            {
                Process procces = Process.GetProcessById(id);
                procces.Kill();
                Console.WriteLine("Process stoped");
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ID");
            }
            Console.ReadKey();
        }

        private static string GetProcessName()
        {
            Console.WriteLine("Введите название процесса");
            string nameProc = Console.ReadLine();
            return nameProc;
        }
    }
}
