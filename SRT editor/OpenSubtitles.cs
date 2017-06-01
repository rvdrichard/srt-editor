using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SRT_editor
{
    class OpenSubtitles
    {
        public OpenSubtitles()
        {

            using (var wc = new WebClient())
            {
                wc.DownloadFile("http://osdownloader.org/nl/osdownloader.subtitles-download/subtitles/5", @"C:\Users\asus\Downloads\t.zip");
            }
        }
    }
}
