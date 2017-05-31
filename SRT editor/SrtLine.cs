using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRT_editor
{
    class SrtLine
    {
        private String linenumber;
        private String begintime;
        private String endtime;
        private String text;

        public string Linenumber { get => linenumber; set => linenumber = value; }
        public string Begintime { get => begintime; set => begintime = value; }
        public string Endtime { get => endtime; set => endtime = value; }
        public string Text { get => text; set => text = value; }
    }
}
