using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace vigenere2005 {
    class Program {
        public static string[,] kodtabla = new string[26,26]; // sor,oszlop
        public static string szoveg = "";
        public static string kszo = "";
        public static string kszoveg = "";
        static void Main(string[] args) {
            kodtablaBeolvas();
            nyiltSzoveg();
            Kulcsszo();
            KodolasElsoLepes();
            KodolasMasodikLepes();
            Console.ReadKey();
        }

        static void nyiltSzoveg() {
            while(szoveg.Length<1 || szoveg.Length>255) {
                Console.WriteLine("Írja be a nyílt szöveget (1-255 karakter hosszú):");
                szoveg = Atalakit(Console.ReadLine());
            }
            Console.WriteLine("Átalakított sor: "+szoveg);
        }

        static void Kulcsszo() {
            while(kszo.Length<1 || kszo.Length>5) {
                Console.WriteLine("Írja be a kulcsszót (1,5 karakter hosszú):");
                kszo = Atalakit(Console.ReadLine());
            }
            Console.WriteLine("Átalakított kulcsszó: "+kszo);
        }

        static void KodolasElsoLepes() {
            // amíg a kulcsszöveg rövidebb mint a szöveg, addig írja egymás mellé a kulcsszót
            while(kszoveg.Length<szoveg.Length) {
                kszoveg = kszoveg+kszo;
            }
            // lehet hogy túl fog lógni így a kulcsszöveg, emiatt ugyanolyan hosszúra kell vágni mint a szöveg
            kszoveg = kszoveg.Substring(0,szoveg.Length);
            Console.WriteLine("Kulcsszöveg: "+kszoveg);
        }

        static void KodolasMasodikLepes() {
            string kodoltszoveg = "";
            // alap ciklus, a nyílt szöveg karakterein megy végig
            for(int a=0; a<szoveg.Length; a++) {
                string sorKarakter = szoveg.Substring(a,1);
                string oszlopKarakter = kszoveg.Substring(a,1);
                int sorIndex = 0;
                int oszlopIndex = 0;
                // megkeresi a sorKarakter indexét
                for(sorIndex=0; sorIndex<=kodtabla.GetUpperBound(0); sorIndex++) {
                    if(kodtabla[sorIndex,0]==sorKarakter) {
                        break;
                    }
                }
                // megkeresi az oszlopKarakter indexét
                for (oszlopIndex=0; oszlopIndex<=kodtabla.GetUpperBound(1); oszlopIndex++) {
                    if (kodtabla[0,oszlopIndex] == oszlopKarakter) {
                        break;
                    }
                }
                // végül a két index metszeténél található karaktert hozzáadja a kódolt szöveghez
                kodoltszoveg = kodoltszoveg+kodtabla[sorIndex,oszlopIndex];
                // DEBUG: Console.WriteLine("Jelenlegi Substring-ek: {0} sor, {1} oszlop, Metszet: {2}, Folyamat: {3}", sorKarakter, oszlopKarakter,kodtabla[sorIndex,oszlopIndex],kodoltszoveg);
            }
            Console.WriteLine("Kódolt szöveg: "+kodoltszoveg);
            // mentés fájlba
            StreamWriter iro = new StreamWriter("kodolt.dat");
            iro.Write(kodoltszoveg);
            iro.Close();
        }

        static void kodtablaBeolvas() {
            StreamReader o = new StreamReader("Vtabla.dat");
            int sorIndex = 0;
            while(!o.EndOfStream) {
                string sor = o.ReadLine();
                for(int a=0; a<sor.Length; a++) {
                    kodtabla[sorIndex,a] = sor.Substring(a,1);
                }
                sorIndex++;
            }
            o.Close();
        }

        static string Atalakit(string nyers) {
            nyers = nyers.ToUpper();
            nyers = nyers.Replace(" ", null);
            nyers = nyers.Replace("!", null);
            nyers = nyers.Replace(",", null);
            nyers = nyers.Replace(";", null);
            nyers = nyers.Replace("?", null);
            nyers = nyers.Replace(".", null);
            nyers = nyers.Replace(":", null);
            nyers = nyers.Replace("-", null);
            nyers = nyers.Replace("_", null);
            nyers = nyers.Replace("*", null);
            nyers = nyers.Replace("#", null);
            nyers = nyers.Replace("&", null);
            nyers = nyers.Replace("(", null);
            nyers = nyers.Replace(")", null);
            nyers = nyers.Replace("/", null);
            nyers = nyers.Replace("Á", "A");
            nyers = nyers.Replace("É", "E");
            nyers = nyers.Replace("Í", "I");
            nyers = nyers.Replace("Ó", "O");
            nyers = nyers.Replace("Ö", "O");
            nyers = nyers.Replace("Ő", "O");
            nyers = nyers.Replace("Ú", "U");
            nyers = nyers.Replace("Ü", "U");
            nyers = nyers.Replace("Ű", "U");
            return nyers;
        }
    }
}

// Blaise de Vigenère
