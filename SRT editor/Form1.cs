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
        // file location from save dialog or open dialog
        private String filelocation;
        // the language of the srt file origin
        private Language lngfrom;
        // the language that the srt 
        private Language lngto;
        // list with srt line objects [ not translated ]
        private List<SrtLine> srtlines;
        // list with srt line objects [ translated ]
        private List<SrtLine> translatedlines;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            createEmptyRows();
            fillComboBox();
        }

        private void fillComboBox()
        {
            comboboxto.DataSource = Enum.GetValues(typeof(Language));
            comboboxfrom.DataSource = Enum.GetValues(typeof(Language));
        }

        private void createEmptyRows()
        {
            for (int i = 0; i < 10; i++)
            {
                // create 10 empty rows just for visual looks.
                string[] row = { "", "", "", "" };
                gridfirstsrt.Rows.Add(row);
                gridtranslated.Rows.Add(row);
            }
        }

        private void readFile()
        {
            String[] srt = File.ReadAllLines(filelocation,Encoding.Default);
            String linenumber = "";
            String starttime = "";
            String endtime = "";
            String text = "";
            srtlines = new List<SrtLine>();
            int linecount = 0;
            // loop through srt file and split them up
            // srt format
            // 1
            // 00:00:00,016-- > 00:00:02,195
            // hey how are you
            // good - example

            foreach (String srttext in srt)
            {
                // if linecount is 0 then it means it has to be the line number.
                if (srttext.Length > 0 && char.IsDigit(srttext[0]) && !srttext.Contains(":") && linecount == 0)
                {
                    linenumber = srttext;
                    linecount++;
                // if the linecount = 1 then it means it is the time and then split the time in begin time and end time
                } else if (srttext.Length > 0 && char.IsDigit(srttext[0]) && srttext.Contains(":") && linecount == 1) {
                    String[] time = srttext.Split(new String[] { " --> " }, StringSplitOptions.None);
                    starttime = time[0];
                    endtime = time[1];
                    linecount++;
                // if the line count = 2 or 3 sometimes it can have multiple lines then it should be the text
                } else if (!srttext.Equals("") && linecount == 2) {
                    text += srttext;
                    linecount++;
                // add extra // to show the user that this is supposed to come on a new line
                } else if (!srttext.Equals("") && linecount == 3) {
                    text += "//";
                    text += srttext;
                    linecount++;
                // finally if a empty line was found a srt line object can be created
                } else if (srttext.Equals("") && linecount > 2) {
                    // add new one
                    SrtLine srtline = new SrtLine();
                    srtline.Linenumber = linenumber;
                    srtline.Begintime = starttime;
                    srtline.Endtime = endtime;
                    srtline.Text = text;
                    srtlines.Add(srtline);
                    // a new line will start
                    linecount = 0;
                    text = "";
                } 
            }
            fillListView(srtlines);
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
                lblmoviename.Text = filedialog.SafeFileName;
                lblmoviename.Visible = true;
                gridfirstsrt.Rows.Clear();
                Thread work = new Thread(new ThreadStart(readFile));
                work.Start();
            }
        }

        private void translateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startTranslate();
        }

        private void startTranslate()
        {
            gridtranslated.Rows.Clear();
            translatedlines = new List<SrtLine>();
            lngfrom = (Language)comboboxfrom.SelectedItem;
            lngto = (Language)comboboxto.SelectedItem;
            Thread translateitems = new Thread(new ThreadStart(translateItems));
            translateitems.Start();
        }

        private void translateItems()
        {
            Translate translate = new Translate(lngfrom, lngto);
            progresstranslated.BeginInvoke(((Action)(() => { progresstranslated.Value = 0; progresstranslated.Maximum = srtlines.Count; })));
            foreach (SrtLine srttext in srtlines)
            {
                String translatedtext = translate.getResult(srttext.Text);
                string[] row = { srttext.Linenumber, srttext.Begintime, srttext.Endtime, translatedtext };
                SrtLine translatedline = new SrtLine() { Linenumber = srttext.Linenumber, Begintime = srttext.Begintime, Endtime = srttext.Endtime, Text = translatedtext };
                translatedlines.Add(translatedline);
                gridtranslated.BeginInvoke(((Action)(() => gridtranslated.Rows.Add(row))));
                progresstranslated.BeginInvoke(((Action)(() => { progresstranslated.Step = 1; progresstranslated.PerformStep(); })));
                lblline.BeginInvoke(((Action)(() => { lblline.Text = "Line: " + progresstranslated.Value; })));
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            saveSrt();
        }

        private void saveSrt()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "srt files | *.srt";
            DialogResult result = savefile.ShowDialog();
            if (result == DialogResult.OK)
            {
                filelocation = savefile.FileName;
                List<SrtLine> gridviewlines = new List<SrtLine>();
                foreach (DataGridViewRow row in gridtranslated.Rows)
                {
                    String line = (String)row.Cells[0].Value;
                    String begin = (String)row.Cells[1].Value;
                    String end = (String)row.Cells[2].Value;
                    String text = (String)row.Cells[3].Value;
                    if (line != null)
                        gridviewlines.Add(new SrtLine() { Linenumber = line, Begintime = begin, Endtime = end, Text = text });
                }
                SrtFile.createSRT(gridviewlines, filelocation);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSrt();
        }

        private void sRTDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSubtitles opensubs = new OpenSubtitles();
        }
    }
}
