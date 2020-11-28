using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace cbradio {
    class Program {
        public static List<Adas> adasok = new List<Adas>();
        static void Main(string[] args) {
            // 2.
            foreach(string line in File.ReadAllLines("cb.txt").Where(s => s!= "Ora;Perc;AdasDb;Nev")) {
                adasok.Add(new Adas(line.Split(';')));
            }
            // 3.
            Console.Write($"3. feladat: Bejegyzések száma: {adasok.Count} db\n");
            // 4.
            Console.Write(adasok.Where(s => s.Quantity==4).Count()>0 ? "4. feladat: Volt négy adást indító sofőr.\n" : "4. feladat: Nem volt négy adást indító sofőr.\n");
            // 5.
            Console.Write("5. feladat: Kérek egy nevet: ");
            string input = Console.ReadLine();
            Console.Write(adasok.Where(s => s.Name==input).Count()>0 ? $"   {input} {adasok.Where(s => s.Name==input).Count()}x használta a rádiót.\n" : $"   Nincs ilyen nevű sofőr!\n");
            // 7.
            using (StreamWriter wr = new StreamWriter("cb2.txt")) {
                wr.WriteLine("Kezdes;Nev;AdasDb");
                foreach(Adas item in adasok) {
                    wr.WriteLine($"{item.AtszamolPercre()};{item.Name};{item.Quantity}");
                }
            }
            // 8.
            Console.Write($"8. feladat: sofőrök száma: {adasok.GroupBy(s => s.Name).Count()}db\n");
            // 9.
            var highestCount = adasok.GroupBy(s => s.Name).OrderBy(s => s.Sum(s => s.Quantity)).Last();
            Console.Write($"9. feladat: legtöbb adást indító sofőr:\n   Név: {highestCount.Key}\n   Adások száma: {highestCount.Sum(s => s.Quantity)} alkalom\n");
            // end
            Console.ReadKey();
        }
    }

    class Adas {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public Adas(string[] elements) {
            Hour = Convert.ToInt32(elements[0]);
            Minutes = Convert.ToInt32(elements[1]);
            Quantity = Convert.ToInt32(elements[2]);
            Name = elements[3];
        }
        public int AtszamolPercre() => Hour*60+Minutes;
    }
}
