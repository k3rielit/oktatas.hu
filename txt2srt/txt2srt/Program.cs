using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace txt2srt {
    class Program {
        static void Main(string[] args) {
            List<IdozitettFelirat> subtitles = Read();
            Task5(subtitles);
            Task7(subtitles);
            Task9(subtitles);
            Console.ReadKey();
        }

        static List<IdozitettFelirat> Read() {
            List<IdozitettFelirat> subtitles = new List<IdozitettFelirat>();
            string[] rows = File.ReadAllLines("feliratok.txt");
            for(int a=0; a<rows.Count(); a+=2) {
                subtitles.Add(new IdozitettFelirat(rows[a],rows[a+1]));
            }
            return subtitles;
        }

        static void Task5(List<IdozitettFelirat> subtitles) {
            Console.WriteLine($"5. feladat - Feliratok száma: {subtitles.Count()}");
        }

        static void Task7(List<IdozitettFelirat> subtitles) {
            var longestSub = subtitles.OrderByDescending(s => s.SzavakSzama());
            Console.WriteLine($"7. feladat - Legtöbb szóból álló felirat:\n{longestSub.First().Subtitle}");
        }

        static void Task9(List<IdozitettFelirat> subtitles) {
            using StreamWriter wr = new StreamWriter("felirat.srt");
            for(int a=0; a<subtitles.Count(); a++) {
                wr.WriteLine($"{a+1}\n{subtitles[a].SrtIdozites()}\n{subtitles[a].Subtitle}\n");
            }
        }
    }
}
