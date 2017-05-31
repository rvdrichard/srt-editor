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
        List<SrtLine> linestranslated;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            createEmptyRows();
        }

        private void createEmptyRows()
        {
            for (int i = 0; i < 10; i++)
            {
                string[] row = { "", "", "", "" };
                gridfirstsrt.Rows.Add(row);
            }
        }

        private void readFile()
        {
            srt = File.ReadAllLines(filelocation,Encoding.Default);
            String linenumber = "";
            String starttime = "";
            String endtime = "";
            String text = "";
            linestranslated = new List<SrtLine>();
            int linecount = 0;
            foreach(String srttext in srt)
            {
                if (srttext.Length > 0 && char.IsDigit(srttext[0]) && !srttext.Contains(":") && linecount == 0)
                {
                    linenumber = srttext;
                    linecount++;
                } else if (srttext.Length > 0 && char.IsDigit(srttext[0]) && srttext.Contains(":") && linecount == 1) {
                    String[] time = srttext.Split(new String[] { "--> " }, StringSplitOptions.None);
                    starttime = time[0];
                    endtime = time[1];
                    linecount++;
                } else if (!srttext.Equals("") && linecount == 2) {
                    text += srttext;
                    linecount++;
                } else if (!srttext.Equals("") && linecount == 3) {
                    text += "//";
                    text += srttext;
                    linecount++;
                }
                else if (srttext.Equals("")) {
                    // add new one
                    SrtLine srtline = new SrtLine();
                    srtline.Linenumber = linenumber;
                    srtline.Begintime = starttime;
                    srtline.Endtime = endtime;
                    srtline.Text = text;
                    linestranslated.Add(srtline);
                    // a new line will start
                    linecount = 0;
                    text = "";
                } 
            }
            fillListView(linestranslated);
            
            //txtboxfrom.BeginInvoke(((Action)(() => txtboxfrom.Text = result)));
        }

        private void fillListView(List<SrtLine> lines)
        {
            foreach(SrtLine srtline in lines)
            {
                string[] row = { srtline.Linenumber, srtline.Begintime, srtline.Endtime, srtline.Text };
                var listViewItem = new ListViewItem(row);
                gridfirstsrt.BeginInvoke(((Action)(() => gridfirstsrt.Rows.Add(row))));
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "srt files | *.srt";
            DialogResult result = filedialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filelocation = filedialog.FileName;
                gridfirstsrt.Rows.Clear();
                Thread work = new Thread(new ThreadStart(readFile));
                work.Start();
            }
        }

        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridtranslated.Rows.Clear();
            Thread translateitems = new Thread(new ThreadStart(translateItems));
            translateitems.Start();
        }

        private void translateItems()
        {
            Translate translate = new Translate(Language.nl, Language.en);
            foreach (SrtLine srttext in linestranslated)
            {
                String translatedtext = translate.getResult(srttext.Text);
                string[] row = { srttext.Linenumber, srttext.Begintime, srttext.Endtime, translatedtext };
                gridtranslated.BeginInvoke(((Action)(() => gridtranslated.Rows.Add(row))));
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "srt files | *.srt";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                filelocation = savefile.FileName;
                createSRT();
            }
        }

        private void createSRT()
        {
            FileStream stream = File.Create(filelocation);
            StreamWriter writer = new StreamWriter(stream);
            foreach(SrtLine srtline in linestranslated)
            {
                writer.WriteLine(srtline.Linenumber);
                writer.WriteLine(srtline.Begintime + "--> " + srtline.Endtime);
                if (srtline.Text.Contains("//"))
                {
                    String[] lines = srtline.Text.Split(new String[] { "//" }, StringSplitOptions.None);
                    foreach (String line in lines)
                    {
                        writer.WriteLine(line);
                    }
                } else {
                    writer.WriteLine(srtline.Text);
                }
                writer.WriteLine();
            }
            writer.Flush();
            stream.Close();
        }
    }
}
