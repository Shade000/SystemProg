using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static readonly object _locker = new object();
        private int _inc;

        private void Thread_1_Click(object sender, EventArgs e)
        {
            var timer = new System.Threading.Timer(ShowAll, null, dueTime: 0, period: 10000);
        }
        public void ShowAll(object state)
        {
            var process = Process.GetProcesses(".").Select(p => p).OrderBy(p => p.Id);
            lock (_locker)
            {
                using (FileStream fs = new FileStream("Processes.txt", FileMode.Append, FileAccess.Write))
                {
                    string sw = string.Empty;
                    int i = 0;
                    if (fs.CanWrite)
                    {
                        foreach (var item in process)
                        {
                            i++;
                            sw = string.Format("{0}. PId - {1} Name: {2}" + Environment.NewLine, i, item.Id.ToString(), item.ProcessName);
                            byte[] byteWr = Encoding.Unicode.GetBytes(sw);
                            fs.Write(byteWr, 0, byteWr.Length);
                        }
                    }
                }
            }
            MessageBox.Show("ShowAll");
        }

        private void Thread_2_Click(object sender, EventArgs e)
        {
            var timer2 = new System.Threading.Timer(Screens, null, dueTime: 0, period: 10000);
        }
        private void Screens(object state)
        {
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graph = Graphics.FromImage(bmp as Image);
            graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            bmp.Save("Screen/Screenshot" + ++_inc + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Screens");
        }
        private void Thread_3_Click(object sender, EventArgs e)
        {
            var timer3 = new System.Threading.Timer(ReadAndWrite, null, dueTime: 0, period: 10000);
        }

        private void ReadAndWrite(object state)
        {
            string[] counterL;
            lock (_locker)
            {
                counterL = File.ReadAllLines("Processes.txt");
                string[] counterS = Directory.GetFiles("Screen");
                using (FileStream fs = new FileStream("Counter.txt", FileMode.Append, FileAccess.Write))
                {
                    string st = string.Empty;
                    int i = 0;
                    if (fs.CanWrite)
                    {
                        i++;
                        st = string.Format("{0}. Lines - {1} Screens - {2}" + Environment.NewLine, i, counterL.Length, counterS.Length);
                        byte[] bytesWr = Encoding.Unicode.GetBytes(st);
                        fs.Write(bytesWr, 0, bytesWr.Length);
                    }
                }
            }
            MessageBox.Show("ReadAndWrite");
        }
    }
}
