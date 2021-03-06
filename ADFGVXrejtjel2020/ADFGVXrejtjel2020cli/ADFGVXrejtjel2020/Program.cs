using System;
using System.Linq;
using System.IO;

namespace ADFGVXrejtjel2020 {
    class Program {
        static void Main(string[] args) {
            // 2.
            Console.Write("2. feladat:\n\tKérem a kulcsot: [HOLD]: ");
            string kulcs = Console.ReadLine().ToUpper();
            Console.Write("\tKérem az üzenetet [szeretem a csokit]: ");
            string uzenet = Console.ReadLine().ToLower();
            // 4.
            ADFGVXrejtjel rejtjel = new ADFGVXrejtjel("kodtabla.txt",uzenet.Length>0 ? uzenet : "szeretem a csokit", kulcs.Length>0 ? kulcs : "HOLD");
            // 5.
            Console.Write($"5. feladat: Az átalakított üzenet: {rejtjel.AtalakitottUzenet()}\n");
            // 6.
            Console.Write($"6. feladat: s->{rejtjel.Betupar('s')} x->{rejtjel.Betupar('x')}\n");
            // 7.
            Console.Write($"7. feladat: A kódszöveg: {rejtjel.Kodszoveg()}\n");
            // 8.
            Console.Write($"8. feladat: A kódolt üzenet: {rejtjel.KodoltUzenet()}\n");
            Console.ReadKey();
        }
    }
    class ADFGVXrejtjel {
        private char[,] Kodtabla;
        private string Uzenet;
        private string Kulcs;

        public string AtalakitottUzenet() {
            // 5. feladat:
            return Uzenet.Replace(" ","")+(new String('x', Uzenet.Replace(" ", "").Length % Kulcs.Length == 0 ? 0 : Kulcs.Length - (Uzenet.Replace(" ", "").Length % Kulcs.Length)));
        }

        public string Betupar(char k) {
            // 6.
            string[] adfgvx = {"A","D","F","G","V","X"};
            for(int sorIndex=0; sorIndex<=5; sorIndex++) {
                for(int oszlopIndex = 0; oszlopIndex<=5; oszlopIndex++) {
                    if(Kodtabla[sorIndex,oszlopIndex]==k) {
                        return adfgvx[sorIndex]+adfgvx[oszlopIndex];
                    }
                }
            }
            return "hiba";
        }

        public string Kodszoveg() {
            // 7. feladat:
            return string.Join("",AtalakitottUzenet().Select(s => Betupar(s)));
        }

        public string KodoltUzenet() {
            string kodszoveg = Kodszoveg();
            int sorokSzama = kodszoveg.Length / Kulcs.Length;
            int oszlopokSzama = Kulcs.Length;
            char[,] m = new char[sorokSzama, oszlopokSzama];
            int index = 0;
            for (int sor = 0; sor < sorokSzama; sor++) {
                for (int oszlop = 0; oszlop < oszlopokSzama; oszlop++) {
                    m[sor, oszlop] = kodszoveg[index++];
                }
            }
            string kodoltUzenet = "";
            for (char ch = 'A'; ch <= 'Z'; ch++) {
                int oszlopIndex = Kulcs.IndexOf(ch);
                if (oszlopIndex != -1) {
                    for (int sorIndex = 0; sorIndex < sorokSzama; sorIndex++) {
                        kodoltUzenet += m[sorIndex, oszlopIndex];
                    }
                }
            }
            return kodoltUzenet;
        }

        public ADFGVXrejtjel(string kodtablaFile, string uzenet, string kulcs) {
            Uzenet = uzenet;
            Kulcs = kulcs;
            Kodtabla = new char[6, 6];
            int sorIndex = 0;
            foreach (var sor in System.IO.File.ReadAllLines(kodtablaFile)) {
                for (int oszlopIndex = 0; oszlopIndex < sor.Length; oszlopIndex++) {
                    Kodtabla[sorIndex, oszlopIndex] = sor[oszlopIndex];
                }
                sorIndex++;
            }
        }
    }
}





/*

ADFGVXrejtjel.AtalakitottUzenet() algoritmus teszt

Console.WriteLine(" UZ: Üzenet hossz | KU: Kulcs hossz | %: Üzenet hossz % Kulcs hossz (maradék) | jó: ideális üzenet hossz | meg: kellő extra 'x'-es száma");
for(int uz = 10; uz<=20; uz++) {
    for(int ku = 4; ku<=10; ku++) {
        string uzen = new String('U', uz);
        string kul = new string('K',ku);
        string kodolt = uzen.Replace(" ", "") + (new String('x', uzen.Replace(" ", "").Length % kul.Length == 0 ? 0 : kul.Length - (uzen.Replace(" ", "").Length % kul.Length)));
        Console.WriteLine($"| UZ: {uz} | KU: {ku} | %: {uz%ku} | jó: {uz+(uz%ku==0?0:ku-(uz%ku))} | meg: {(uz%ku==0?0:ku-(uz%ku))} | {kodolt} | TÉNYLEG JÓ? {(kodolt.Length%ku==0?"igen" : "nem")}");
    }
}

*/
