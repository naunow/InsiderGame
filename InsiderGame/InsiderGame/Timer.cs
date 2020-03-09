using System;
using System.Collections.Generic;
using System.Text;

namespace InsiderGame
{

    public class Timer
    {
        public TimeSpan TimeSpan { get; set; }

        //public string Time { get; set; }


        private string minutes;
        public string Minutes
        {
            get {   return TimeSpan.Minutes.ToString("00"); }
            set { minutes = value; }
        }

        private string seconds;
        public string Seconds
        {
            get { return TimeSpan.Seconds.ToString("00"); }
            set { seconds = value; }
        }


        //public string Minutes { get; set; }
        //public string Seconds { get; set; }

    }

}
