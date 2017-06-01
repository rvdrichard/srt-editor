using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRT_editor
{
    class SrtFile
    {
        public static void createSRT(List<SrtLine> lines, String path)
        {
            FileStream stream = File.Create(path);
            StreamWriter writer = new StreamWriter(stream);
            foreach (SrtLine srtline in lines)
            {
                writer.WriteLine(srtline.Linenumber);
                writer.WriteLine(srtline.Begintime + "--> " + srtline.Endtime);
                if (srtline.Text.Contains("//"))
                {
                    String[] linesarr = srtline.Text.Split(new String[] { "//" }, StringSplitOptions.None);
                    foreach (String line in linesarr)
                    {
                        writer.WriteLine(line);
                    }
                }
                else
                {
                    writer.WriteLine(srtline.Text);
                }
                writer.WriteLine();
            }
            writer.Flush();
            stream.Close();
        }
    }
}
