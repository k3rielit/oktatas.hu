using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace playfair2020 {
    class Program {
        public static PlayfairKodolo codeTable = new PlayfairKodolo("kulcstabla.txt");
        static void Main(string[] args) {
            Task6();
            Task8();
            Console.ReadKey();
        }

        static void Task6() {
            Console.Write("6. feladat - Kérek egy nagybetűt: ");
            char input = Convert.ToChar(Console.ReadLine().ToUpper());
            int[] indexes = { codeTable.SorIndex(input) , codeTable.OszlopIndex(input) }; // row,column
            string indexesLine = indexes[0]>=0 && indexes[1]>=0 ? $"A karakter sorának indexe: {indexes[0]}\nA karakter oszlopának indexe: {indexes[1]}" : "Invalid character!";
            Console.WriteLine(indexesLine);
        }

        static void Task8() {
            Console.Write("8. feladat - Kérek egy karakterpárt: ");
            Console.WriteLine($"Kódolva: {codeTable.KodolBetupar(Console.ReadLine())}");
        }
    }
}
