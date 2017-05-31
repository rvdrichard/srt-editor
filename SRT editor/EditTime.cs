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
        struct Time
        {
            public int Hour;
            public int Minutes;
            public double Seconds;
        };

        private Time StartTimeIn, StopTimeIn, StartTimeOut, StopTimeOut;

        public void AddOffset (String[] text, double Seconds)
        {
            foreach (var line in text)  //check every line
            {
                if(GetTime(line))   //If time found
                {
                    AddTime(0, 0, Seconds);
                }

            }
            Console.WriteLine("done");
         }


        public bool GetTime (string text)
        // Time format 00:00:00,000 --> 00:00:00,00
        {
            if (text.Contains("-->")) //this line displays time
            {
                int index = text.IndexOf("-->");    //search for the "-->"
                string StartTime = text.Substring(0, index - 1);    //Get the entire start time
                string StopTime = text.Substring(index + 3);        //Get the entire stop time
                string[] time = StartTime.Split(':');               //Split the Start time (Hours, minutes, seconds)             
               
                StartTimeIn.Hour = int.Parse(time[0]);
                StartTimeIn.Minutes = int.Parse(time[1]);
                StartTimeIn.Seconds = double.Parse(time[2]);
                time = StopTime.Split(':');                         //Split the stop time (Hours, minutes, seconds)
                StopTimeIn.Hour = int.Parse(time[0]);
                StopTimeIn.Minutes = int.Parse(time[1]);
                StopTimeIn.Seconds= double.Parse(time[2]);
                return true;    //time found
            }
            else
            {
                return false;   //no time found
            }
        }


        public void AddTime (int Hours, int Minutes, double Seconds)
        {
            double TempSeconds = (double)(StartTimeIn.Hour * 3600) + (double)(StartTimeIn.Minutes * 60) + StartTimeIn.Seconds + Seconds;

            StartTimeOut.Hour = (int)(TempSeconds / 3600.0);
            StartTimeOut.Minutes = (int)(TempSeconds % 3600.0)/60;
            StartTimeOut.Seconds = TempSeconds - (double)(StartTimeOut.Hour * 3600) - (double)(StartTimeOut.Minutes * 60);

            TempSeconds = (double)(StopTimeIn.Hour * 3600) + (double)(StopTimeIn.Minutes * 60) + StopTimeIn.Seconds + Seconds;
            StopTimeOut.Hour = (int)(TempSeconds / 3600.0);
            StopTimeOut.Minutes = (int)(TempSeconds % 3600.0) / 60;
            StopTimeOut.Seconds = TempSeconds - (double)(StopTimeOut.Hour * 3600) - (double)(StopTimeOut.Minutes * 60);

        }

    }
}
