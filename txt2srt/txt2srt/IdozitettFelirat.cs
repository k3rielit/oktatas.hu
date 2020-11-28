using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace txt2srt {
    class IdozitettFelirat {

        // Construct
        public string Timing { get; set; }
        public string Subtitle { get; set;}

        // Set values
        public IdozitettFelirat (string timing, string sub) {
            Timing = timing;
            Subtitle = sub;
        }

        // Methods
        public int SzavakSzama() {
            string[] words = Subtitle.Split(' ');
            return words.Count();
        }
        public string SrtIdozites() {
            //   start[hours,minutes,seconds]   end[hours,minutes,seconds]
            // Timing 00:00 - 00:00 --> 0:start[1]:start[2] - 0:end[1]:end[2]   (start[0] and end[0] is 0 because there's no hour property in Timing)
            string[] start = { "0", Timing.Split(" - ")[0].Split(':')[0], Timing.Split(" - ")[0].Split(':')[1] };
            string[] end = { "0", Timing.Split(" - ")[1].Split(':')[0], Timing.Split(" - ")[1].Split(':')[1] };
            // if the minutes property is bigger then 60 (1 hour), then increment hours by 1, and decrement minutes by 60
            while(Convert.ToInt32(start[1])>60) {
                start[0] = (Convert.ToInt32(start[0]) + 1).ToString();
                start[1] = (Convert.ToInt32(start[1]) - 60).ToString();
            }
            while(Convert.ToInt32(end[1])>60) {
                end[0] = (Convert.ToInt32(end[0]) + 1).ToString();
                end[1] = (Convert.ToInt32(end[1]) - 60).ToString();
            }
            // fix format to be 2 digit in all 3 properties
            for(int a=0; a<2; a++) {
                start[a] = start[a].Length == 1 ? start[a] = "0"+start[a] : start[a];
                end[a] = end[a].Length == 1 ? end[a] = "0" + end[a] : end[a];
            }
            return ($"{start[0]}:{start[1]}:{start[2]} --> {end[0]}:{end[1]}:{end[2]}");
        }
    }
}
