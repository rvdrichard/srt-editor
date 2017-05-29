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

        private void btntranslate_Click(object sender, EventArgs e)
        {
            Translate translate = new Translate(Language.nl, Language.en);
            String[] translated = new String[srt.Length];
            for(int i = 0;i < srt.Length;i++) { 
                if(srt[i].Equals("") || char.IsDigit(srt[i][0]))
                {
                    translated[i] = srt[i];
                } else
                {
                    translated[i] = translate.getResult(srt[i]);
                }
            }

            String result = "";
            foreach (String srttext in translated)
            {
                result += srttext + "\n";
            }
            txtboxfrom.BeginInvoke(((Action)(() => txtboxto.Text = result)));
            Console.WriteLine(translate.getResult("Hallo meneer beer"));
        }
    }
}
