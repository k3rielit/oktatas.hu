using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace playfair2020 {
    class PlayfairKodolo {
        public char[,] Table { get; set; }

        public PlayfairKodolo (string source) {
            char[,] table = new char[5,5];
            byte lineCount = 0;
            // read each line
            foreach (string row in File.ReadAllLines(source)) {
                // fill current line with the read row
                for(byte a=0; a<row.Length; a++) {
                    table[lineCount,a] = Convert.ToChar(row.Substring(a,1));
                }
                lineCount++;
            }
            Table = table;
        }

        public int SorIndex(char input) {
            for (byte x=0; x<=Table.GetUpperBound(0); x++) {
                for (byte y=0; y<=Table.GetUpperBound(1); y++) {
                    if(Table[x,y]==input) {return x;}
                }
            }
            return -1;
        }

        public int OszlopIndex(char input) {
            for (byte x=0; x<=Table.GetUpperBound(0); x++) {
                for (byte y=0; y<=Table.GetUpperBound(1); y++) {
                    if (Table[x,y]==input) {return y;}
                }
            }
            return -1;
        }

        public string KodolBetupar(string rawInput) { // input[ char1 , char2 ]
            char[] input = rawInput.ToCharArray();
            int[] char1 = { SorIndex(input[0]) , OszlopIndex(input[0]) };
            int[] char2 = { SorIndex(input[1]) , OszlopIndex(input[1]) };
            if ( char1[0]>=0 && char1[1]>=0 && char2[0]>=0 && char2[1]>=0 ) {
                // (a.) if char1 row == char2 row --> push their column indexes to the right by 1 (if oout of bounds, reset to 0)
                switch(char1[0] == char2[0]) {
                    case true : 
                        switch(char1[1]) {
                            case 4: char1[1] = 0; break;
                            default: char1[1] += 1; break;
                        } // reset columns to 0 when index is 4 (maximum table column index), or increment column by 1 by default
                        switch (char2[1]) {
                            case 4: char2[1] = 0; break;
                            default: char2[1] += 1; break;
                        }
                        return $"{Table[char1[0] , char1[1]]}{Table[char2[0] , char2[1]]}";
                    default:
                        // (b.) if char1 column == char2 column --> push their row indexes down by 1 (if out of bounds, reset to 0)
                        switch (char1[1] == char2[1]) {
                            case true:
                                switch(char1[0]) {
                                    case 4: char1[0] = 0; break;
                                    default: char1[0] += 1; break;
                                } // reset rows to 0 when index is 4 (maximum is 4), or increment by 1 by default
                                switch (char2[0]) {
                                    case 4: char2[0] = 0; break;
                                    default: char2[0] += 1; break;
                                }
                                return $"{Table[char1[0] , char1[1]]}{Table[char2[0] , char2[1]]}";
                            default:
                                // (c.) last option: switch column indexes between the two characters
                                int char1ColumnIndex = char1[1]; // need to cache char1 column
                                char1[1] = char2[1]; // char1 column = char2 column
                                char2[1] = char1ColumnIndex; // char2 column = char1 column
                                return $"{Table[char1[0], char1[1]]}{Table[char2[0], char2[1]]}";
                        }
                }
            }
            else {return "Invalid character pair!"; }
        }
    }
}
