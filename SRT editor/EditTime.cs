using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SRT_editor
{
    class EditTime
    {
        public bool AddOffset (string[] text)
        // Time format 00:00:00,000 --> 00:00:00,00
        {
            foreach (var line in text)  //check every line
            { 
                if (line.Contains("-->")) //this line displays time
                {
                    int index = line.IndexOf("-->");
                    string StartTime = line.Substring(0, index - 1);
                    Console.Write("StartTime: ");
                    Console.WriteLine(StartTime);
                    string StopTime = line.Substring(index + 3);
                    Console.Write("StopTime: ");
                    Console.WriteLine(StopTime);
                    string[] time = StartTime.Split(':');
                    Console.WriteLine("Start - Hour : {0}, min : {1}, Sec : {2}", time[0], time[1], time[2]);
                    time = StopTime.Split(':');
                    Console.WriteLine("Stop - Hour : {0}, min : {1}, Sec : {2}", time[0], time[1], time[2]);
                }
            }
            return false;
        }
    }
}
