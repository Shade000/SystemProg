using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_4
{
    public partial class MainForm : Form
    {
        private string nameFolder;
        private Progress<int> progress;
        private List<string> _list_paths;
        private List<Task> tasksLst = new List<Task>();
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        public MainForm()
        {
            InitializeComponent();
            _list_paths = new List<string>();
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        private void btnFrom1_Click(object sender, EventArgs e)
        {
            tbFrom.Text = string.Empty;
            _list_paths.Clear();
            var open = new OpenFileDialog();
            open.Filter = "All files (*.*)|*.*";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                tbFrom.Text += open.FileName;
                _list_paths.AddRange(open.FileNames);
            }
        }
        private void btnFrom2_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                tbWhere.Text = open.SelectedPath;
                nameFolder = Path.GetFileName(open.SelectedPath);
                _list_paths.AddRange(Directory.GetFiles(open.SelectedPath));
            }
        }
        private void btnWhere_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                tbWhere.Text = open.SelectedPath;
            }
        }
        private void tbWhere_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCopy_Click(sender, e);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            CancellationCopy();
        }
        private void CancellationCopy()
        {
            foreach (var item in _list_paths)
            {
                File.Delete(string.Format("{0}\\{1}", tbWhere.Text, Path.GetFileName(item)));
            }
            pbCopy.Value = 0;
            MessageBox.Show("Копирование отменено", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            pbCopy.Value = 0;
            pbCopy.Maximum = 0;
            progress = new Progress<int>(i => { pbCopy.Maximum += i; pbCopy.Value += i; });

            if (nameFolder != null)
            {
                nameFolder = string.Format("{0}\\{1}", tbWhere.Text, nameFolder);
                Directory.CreateDirectory(nameFolder);
            }
            else
                nameFolder = tbWhere.Text;

            foreach (var item in _list_paths)
            {
                Task.Run(() => Copy(progress, item));
            }
        }

        private void Copy(IProgress<int> progress, string path)
        {
            if (!string.IsNullOrEmpty(tbWhere.Text) && !string.IsNullOrEmpty(tbFrom.Text))
            {
                byte[] buffer = new byte[4096];
                using (FileStream streamRead = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream streamWrite = new FileStream(string.Format("{0}\\{1}", nameFolder, Path.GetFileName(path)), FileMode.Create, FileAccess.Write))
                    {
                        var max = (int)Math.Ceiling((double)streamRead.Length / 4096);
                        while (true)
                        {
                            if (streamWrite.Length == streamRead.Length)
                                break;
                            var ReadLength = streamRead.Read(buffer, 0, buffer.Length);
                            streamWrite.Write(buffer, 0, ReadLength);
                            progress.Report(1);
                        }
                        token.ThrowIfCancellationRequested();
                    }
                }
            }
        }

        
    }
}
