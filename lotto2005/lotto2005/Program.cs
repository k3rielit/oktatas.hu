using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lotto2005 {
    class Program {
        public static int[,] lottoSzamok = new int[51,5];
        public static int[] lottoSzamok52het = new int[5];
        public static int bekertSzam = 0;
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Beolvas();
            ElsoMasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            HetedikFeladat();
            NyolcadikFeladat();
            KilencedikFeladat();
            Console.ReadKey();
        }

        static void ElsoMasodikFeladat() {
            // ideiglenes tömb a bekért számoknak a sorbarendezésig
            int[] het52bekert = new int[5];
            for(int a=0; a<5; a++) {
                Console.Write("{0}. szám: ",a+1);
                het52bekert[a] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Növekvő sorrendben:");
            byte het52Index = 0;
            // a legkisebbtől a legnagyobb létező számig teszteli az értékeket és ha talált egyezést/létező bekért számot berakja az index alapján a fő tömbbe amit utána 1-el növel
            for(int a=het52bekert.Min(); a<=het52bekert.Max(); a++) {
                if(het52bekert.Contains(a)) {
                    lottoSzamok52het[het52Index] = a;
                    Console.Write(" "+a);
                    het52Index++;
                }
            }
            Console.WriteLine();
        }

        static void HarmadikFeladat() {
            while(bekertSzam<1 || bekertSzam>51) {
                Console.Write("Szám (1 és 51 között): ");
                bekertSzam = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void NegyedikFeladat() {
            Console.Write("{0}. hét számai:",bekertSzam);
            for(int a=0; a<5; a++) {
                Console.Write(" "+lottoSzamok[bekertSzam,a]);
            }
            Console.WriteLine();
        }

        static void OtodikFeladat() {
            bool osszesKihuzott = true;
            HashSet<int> huzottSzamok = new HashSet<int>();
            foreach(int item in lottoSzamok) {
                huzottSzamok.Add(item);
            }
            for(int a=1; a<=90; a++) {
                if(!huzottSzamok.Contains(a)) {
                    osszesKihuzott = false;
                }
            }
            if(!osszesKihuzott) {
                Console.WriteLine("Van olyan szám amit nem húztak ki.");
            }
            else {
                Console.WriteLine("Nincs olyan szám amit nem húztak ki.");
            }
        }

        static void HatodikFeladat() {
            int paratlanSzamok = 0;
            foreach(int item in lottoSzamok) {
                if(item%2>0) {
                    paratlanSzamok++;
                }
            }
            Console.WriteLine("Ennyi páratlan számot húztak ki: "+paratlanSzamok);
        }

        static void HetedikFeladat() {
            StreamWriter iro = new StreamWriter("lotto52.ki");
            for(int a=0; a<lottoSzamok.GetUpperBound(0); a++) {
                iro.WriteLine("{0} {1} {2} {3} {4}",lottoSzamok[a,0],lottoSzamok[a,1],lottoSzamok[a,2],lottoSzamok[a,3],lottoSzamok[a,4]);
            }
            iro.Write("{0} {1} {2} {3} {4}",lottoSzamok52het[0],lottoSzamok52het[1],lottoSzamok52het[2],lottoSzamok52het[3],lottoSzamok52het[4]);
            iro.Close();
        }

        static void NyolcadikFeladat() {
            Console.WriteLine("Ennyiszer húzták ki az egyes lottószámokat (1-90):");
            Dictionary<int,int> lotto52SzamokMennyisege = new Dictionary<int,int>();
            StreamReader o = new StreamReader("lotto52.ki");
            while(!o.EndOfStream) {
                string[] sor = o.ReadLine().Split(' ');
                // Ha még nincs ilyen szám a szótárban, akkor hozzáadja 1-es értékkel mert most fordult elő először
                // Ha már van ilyen szám a szótárban akkor csak növeli az értékét 1-el
                foreach(string item in sor) {
                    if(!lotto52SzamokMennyisege.ContainsKey(Convert.ToInt32(item))) {
                        lotto52SzamokMennyisege.Add(Convert.ToInt32(item),1);
                    }
                    else {
                        lotto52SzamokMennyisege[Convert.ToInt32(item)] += 1;
                    }
                }
            }
            // ha létezik, azaz kihúzták a számot, akkor a mennyiséget kiírja, ha nem akkor 0-t ír ki
            for(int a=lotto52SzamokMennyisege.Keys.Min(); a<=lotto52SzamokMennyisege.Keys.Max(); a++) {
                if(lotto52SzamokMennyisege.ContainsKey(a)) {
                    Console.Write(lotto52SzamokMennyisege[a]+" ");
                }
                else {
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
            o.Close();
        }

        static void KilencedikFeladat() {
            Console.Write("Prímszámok amelyeket egyszer sem húztak ki:");
            List<int> primSzamok = new List<int>();
            // prímszámok generálása (opcionális) egy listába
            for(int a=2; a<=90; a++) {
                bool prim = true;
                for(int b=2; b<a; b++) {
                    if(a%b==0) {
                        prim = false;
                    }
                }
                if(prim) {
                    primSzamok.Add(a);
                }
            }
            // a kihúzott prímszámokat eltávolítja a listából
            foreach(int item in lottoSzamok) {
                if(primSzamok.Contains(item)) {
                    primSzamok.Remove(item);
                }
            }
            foreach(int item in lottoSzamok52het) {
                if(primSzamok.Contains(item)) {
                    primSzamok.Remove(item);
                }
            }
            // kiírja a megmaradt, azaz nem kihúzott prímszámokatt
            foreach(int item in primSzamok) {
                Console.Write(" "+item);
            }
        }

        public static void Beolvas() {
            StreamReader o = new StreamReader("lottosz.dat");
            int index = 0;
            while(!o.EndOfStream) {
                string[] sor = o.ReadLine().Split(' ');
                for(int a=0; a<5; a++) {
                    lottoSzamok[index,a] = Convert.ToInt32(sor[a]);
                }
                index++;
            }
            o.Close();
        }
    }
}
