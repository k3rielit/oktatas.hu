using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace footgolf2018 {
    class Program {
        public static List<Person> ppl = new List<Person>();
        static void Main(string[] args)  {
            // 2. reading the file
            foreach(string line in File.ReadAllLines("fob2016.txt")) {
                ppl.Add(new Person(line.Split(';')));
            }
            // 3.
            Console.Write($"3. feladat: Versenyzők száma: {ppl.Count()}\n");
            // 4.
            Console.Write($"4. feladat: A női versenyzők aránya: {Convert.ToDouble(ppl.Where(s => s.Category == "Noi").Count()) / ppl.Count() * 100:F2}%\n");
            // 6. 
            Person bestWoman = ppl.Where(s => s.Category=="Noi").OrderBy(s => s.TotalScore()).Last();
            Console.Write($"6. feladat: A bajnok női versenyző\n\tNév: {bestWoman.Name}\n\tEgyesület: {bestWoman.Team}\n\tÖsszpont: {bestWoman.TotalScore()}\n");
            // 7.
            File.WriteAllText("osszpontFF.txt",string.Join("",ppl.Where(s => s.Category=="Felnott ferfi").SelectMany(s => $"{s.Name};{s.TotalScore()}\n").ToList()));
            // 8.
            Console.WriteLine($"8. feladat: Egyesület statisztika\n{string.Join("",ppl.GroupBy(s => s.Team).Where(s => s.Key!="n.a." && s.Count()>2).SelectMany(s => $"\t{s.Key} - {s.Count()} fő\n"))}");
            // End
            Console.ReadKey();
        }
    }

    public class Person {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
        public int[] Scores { get; set; }
        public Person(string[] line) {
            Name = line[0];
            Category = line[1];
            Team = line[2];
            Scores = new int[] { int.Parse(line[3]), int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6]), int.Parse(line[7]), int.Parse(line[8]), int.Parse(line[9]), int.Parse(line[10]) }.OrderBy(s => s).ToArray();
        }
        public int TotalScore() => Scores.Sum() - (Scores[0]>0 ? Scores[0]-10 : Scores[0]) - (Scores[1]>0 ? Scores[1]-10 : Scores[1]);
    }
}
