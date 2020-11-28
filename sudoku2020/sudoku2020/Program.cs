using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku2020 {
    // 1. feladat: beillesztés
    class Feladvany {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor) {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol() {
            for (int i = 0; i < Kezdo.Length; i++) {
                if (Kezdo[i] == '0') {
                    Console.Write(".");
                }
                else {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1) {
                    Console.WriteLine();
                }
            }
        }
    }
    class Program {
        public static List<Feladvany> feladvanyok = new List<Feladvany>();
        public static int bekertSzam;
        static void Main(string[] args) {
            Beolvas();
            Feladat_4();
            Feladat_5_6_7();
            // vége
            Console.ReadKey();
        }
        
        static void Feladat_4() {
            // 4. feladat: egy szám bekérése 4-től 9-ig, majd megkeresni hány ekkora tábla lett beolvasva
            while (bekertSzam < 4 || bekertSzam > 9) {
                Console.Write("\n4. feladat: Kérem a feladvány méretét [4..9]: ");
                bekertSzam = Convert.ToInt32(Console.ReadLine());
            }
            int tablaSzam = 0;
            foreach(Feladvany sor in feladvanyok) {
                if(sor.Meret==bekertSzam) {
                    tablaSzam++;
                }
            }
            Console.WriteLine("{0}x{0} méretű feladványból {1} darab van tárolva",bekertSzam,tablaSzam);
        }

        static void Feladat_5_6_7() {
            // 5. feladat: a bekért méretű táblák közül kiválasztani egy véletlenszerűt
            List<Feladvany> bekertFeladvanyok = feladvanyok.Where(s=> s.Meret==bekertSzam).ToList();
            // Ez is jó: List<Feladvany> bekertFeladvanyok = (from s in feladvanyok where s.Meret==bekertSzam select s).ToList();
            Random r = new Random();
            int randomTabla = r.Next(0,bekertFeladvanyok.Count-1);
            Console.WriteLine("\n5. feladat: A kiválasztott feladvány\n{0}",bekertFeladvanyok[randomTabla].Kezdo);
            // 6. feladat: kitöltöttség számítása: nem nulla karakterek száma (hossz - 0 karakterek száma) / string hossza * 100
            // nem ad eredményt (0) ha mindkettő változó int, vagy ha egyben van elvégeze a számítás, ezért az egyik double
            double nullaSzam = bekertFeladvanyok[randomTabla].Kezdo.Count(s => s == '0');
            int hossz = bekertFeladvanyok[randomTabla].Kezdo.Count();
            Console.WriteLine("\n6. feladat: A feladvány kitöltöttsége: {0}%", (hossz-nullaSzam) / hossz * 100);
            // 7. feladat: a random kiválasztott feladat kirajzolása
            Console.WriteLine("\n7. feladat: A feladvány kirajzolva:");
            bekertFeladvanyok[randomTabla].Kirajzol();
            // 8. feladat: az összes ekkora tábla kiírása fájlba (bekertFeladvanyok listában már megvannak)
            StreamWriter wr = new StreamWriter("sudoku"+bekertSzam+".txt");
            foreach(Feladvany sor in bekertFeladvanyok) {
                wr.WriteLine(sor.Kezdo);
            }
            wr.Close();
            Console.WriteLine("\n8. feladat: sudoku{0}.txt állomány {1} darab feladvánnyal sikeresen létrehozva",bekertSzam,bekertFeladvanyok.Count());
        }

        static void Beolvas() {
            // 2. feladat: beolvasás
            int elemSzam = 0;
            foreach(string sor in File.ReadAllLines("feladvanyok.txt")) {
                feladvanyok.Add(new Feladvany(sor));
                elemSzam++;
            }
            // 3. feladat: beolvasott sorok száma
            Console.WriteLine("3. feladat: Beolvasva {0} feladvány",elemSzam);
        }
    }
}
