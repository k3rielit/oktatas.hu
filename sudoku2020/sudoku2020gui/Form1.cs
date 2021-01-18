using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku2020gui {
    public partial class Form1 : Form {
        public int meret = 4;
        public Form1() {
            InitializeComponent();
        }

        private void BTN_kivon_Click(object sender, EventArgs e) {
            meret -= meret==4 ? 0 : 1;
            Meret.Text = meret.ToString();
        }
        
        private void BTN_hozzaad_Click(object sender, EventArgs e) {
            meret += meret==9 ? 0 : 1;
            Meret.Text = meret.ToString();
        }

        private void KezdoallapotChange(object sender, EventArgs e) {
            Hossz.Text = $"Hossz: {Kezdoallapot.TextLength}";
        }

        private void BTN_ellenorzes_Click(object sender, EventArgs e) {
            MessageBox.Show(meret == Math.Sqrt(Kezdoallapot.TextLength) ? "A feladvány megfelelő hosszúságú!" : (Math.Sqrt(Kezdoallapot.TextLength) > meret ? $"A feladvány hosszú, törlendő {Kezdoallapot.TextLength-meret*meret} számjegy!" : $"A feladvány rövid: kell még {meret*meret-Kezdoallapot.TextLength} számjegy!"));
        }
    }
}
