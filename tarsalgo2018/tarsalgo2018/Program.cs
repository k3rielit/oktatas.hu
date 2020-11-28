using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tarsalgo2018 {
    class Bejegyzes {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int Azonosito { get; set; }
        public string Irany { get; set; }
        public Bejegyzes (string sor) {
            Ora = Convert.ToInt32(sor.Split(' ')[0]);
            Perc = Convert.ToInt32(sor.Split(' ')[1]);
            Azonosito = Convert.ToInt32(sor.Split(' ')[2]);
            Irany = sor.Split(' ')[3];
        }
    }
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.Unicode;
            List<Bejegyzes> bejegyzesek = Beolvas();
            Feladatok(bejegyzesek);
            Console.ReadKey();
        }

        static void Feladatok(List<Bejegyzes> bejegyzesek) {
            // 2. feladat
            Console.WriteLine("2. feladat\nAz első belépő: {0}", bejegyzesek[0].Azonosito);
            Console.WriteLine("Az utolsó kilépő: {0}", bejegyzesek[bejegyzesek.FindLastIndex(s => s.Irany.Contains("ki"))].Azonosito);

            // 3. és 4. feladat egyben
            Console.Write("\n4. feladat\nA végén a társalgóban voltak:");
            // ToLookup/GroupBy: áthaladások száma azonosítónként
            var athaladasLookup = bejegyzesek.ToLookup(s => s.Azonosito).OrderBy(s => s.Key).ToList();
            StreamWriter wr = new StreamWriter("athaladas.txt");
            foreach(var item in athaladasLookup) {
                // Azonosító - áthaladások száma fájlba írás
                wr.WriteLine("{0} {1}",item.Key,item.Count());
                // Ha az utolsó iránya az azonosítónak be, akkor bent maradt
                if(item.ElementAt(item.Count() - 1).Irany == "be") {
                    Console.Write(" {0}",item.ElementAt(item.Count() - 1).Azonosito);
                }
            }
            wr.Close();

            // 5. feladat
            int[] emberek = { 0, 0, 0 }; // emberek száma, emberek száma rekord, a rekord indexe
            for (int a = 0; a < bejegyzesek.Count(); a++) {
                // emberek számának nyilvántartása az adott indexnél
                if (bejegyzesek[a].Irany == "be") {
                    emberek[0]++;
                }
                else {
                    emberek[0]--;
                }
                // ha nagyobb a jelenlegi rekordnál az emberek száma, frissíti a rekordot és az indexet
                if (emberek[0] > emberek[1]) {
                    emberek[1] = emberek[0];
                    emberek[2] = a;
                }
            }
            Console.WriteLine("\n\n5. feladat");
            Console.WriteLine("{0}:{1}-kor voltak a legtöbben a társalgóban.", bejegyzesek[emberek[2]].Ora, bejegyzesek[emberek[2]].Perc);

            // 6. feladat
            Console.Write("\n6. feladat\nAdja meg a személy azonosítóját! ");
            int azonosito6 = Convert.ToInt32(Console.ReadLine());

            // 7. és 8. feladat egyben
            Console.WriteLine("\n7. feladat");
            foreach (var item in athaladasLookup) {
                if(item.Key == azonosito6) {
                    bool sorTores = false;
                    int percek = 0;
                    // az áthaladások idejének kiírása (7. feladat) és a bent töltött idő tárolása majd a végeredmény kiírása (8. feladat)
                    foreach (var groupItem in item) {
                        if (!sorTores) {
                            Console.Write("{0}:{1}-", groupItem.Ora, groupItem.Perc);
                            percek += groupItem.Ora*60 + groupItem.Perc;
                            sorTores = !sorTores;
                        }
                        else {
                            Console.Write("{0}:{1}\n", groupItem.Ora, groupItem.Perc);
                            percek -= groupItem.Ora*60 + groupItem.Perc;
                            sorTores = !sorTores;
                        }
                    }
                    Console.WriteLine("\n\n8. feladat");
                    // bent maradt-e az illető
                    if(item.ElementAt(item.Count()-1).Irany == "be") {
                        percek -= 15*60; // 15:00 a megfigyelés vége
                        Console.WriteLine("A(z) {0}. személy {1} percet volt bent, a megfigyelés végén a társalgóban volt.",azonosito6,Math.Abs(percek));
                    }
                    else {
                        Console.WriteLine("A(z) {0}. személy {1} percet volt bent, a megfigyelés végén nem volt a társalgóban.",azonosito6,Math.Abs(percek));
                    }
                }
            }
        }

        static List<Bejegyzes> Beolvas() {
            List<Bejegyzes> bejegyzesek = new List<Bejegyzes>();
            StreamReader o = new StreamReader("ajto.txt");
            while(!o.EndOfStream) {
                bejegyzesek.Add(new Bejegyzes(o.ReadLine()));
            }
            o.Close();
            return bejegyzesek;
        }
    }
}
