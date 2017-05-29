using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace SRT_editor
{
    public partial class Form1 : Form
    {

        private String filelocation;
        private String[] srt;

        public Form1()
        {
            InitializeComponent();
        }

        private void readFile()
        {
            srt = File.ReadAllLines(filelocation);
            String result = "";
            foreach(String srttext in srt)
            {
                result += srttext + "\n";
            }
            txtboxfrom.BeginInvoke(((Action)(() => txtboxfrom.Text = result)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "srt files | *.srt";
            DialogResult result = filedialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filelocation = filedialog.FileName;
                txtboxfrom.Clear();
                Thread work = new Thread(new ThreadStart(readFile));
                work.Start();
            }
        }

        private void AddTimeOffsetBtn_Click(object sender, EventArgs e)
        {
            EditTime EditTime = new EditTime();
            EditTime.AddOffset(srt);
        }
    }
}
