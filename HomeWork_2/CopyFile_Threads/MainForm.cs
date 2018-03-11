using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CopyFile_Threads
{
    public partial class MainForm : Form
    {
         private string nameFile;
         public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                tbFrom.Text = open.FileName;
                nameFile = open.SafeFileName;
            }
        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbWhere.Text = fbd.SelectedPath;
            }
        }
        
        private void tbWhere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCopy_Click(sender, e);
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                pbCopy.Value = 0;
                new Thread(Copy).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Copy()
        {
            if (!string.IsNullOrEmpty(tbWhere.Text) && !string.IsNullOrEmpty(tbFrom.Text))
            {
                byte[] buffer = new byte[4096];
                using (FileStream streamRead = new FileStream(tbFrom.Text, FileMode.Open, FileAccess.Read))
                {
                    double fileLength = streamRead.Length;
                    using (FileStream streamWrite = new FileStream(string.Format("{0}\\{1}", tbWhere.Text, nameFile), FileMode.Create, FileAccess.Write))
                    {
                        var max = (int)Math.Ceiling((double)streamRead.Length / 4096);
                        while (true)
                        {
                            if (streamWrite.Length == streamRead.Length)
                                break;
                            var ReadLength = streamRead.Read(buffer, 0, buffer.Length);
                            streamWrite.Write(buffer, 0, ReadLength);
                            Invoke(new Action<int>(GetProgress), max);
                        }
                    }
                }
            }
        }
        private void GetProgress(int max)
        {
            if (pbCopy.Value == 0)
                pbCopy.Maximum = max;
            ++pbCopy.Value;
            if (pbCopy.Value == pbCopy.Maximum)
                MessageBox.Show("Копирование успешно завершено", "Скопировано", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
