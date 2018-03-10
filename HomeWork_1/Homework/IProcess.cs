using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    interface IProcess
    {
        void ShowAllProcess();
        void SelectProcess(int id);
        void StartProcess(string adressProcess);
        void StopProcess(int id);
        void ShowThreadInfo();
        void ShowModulsInfo(int id);
    }
}
