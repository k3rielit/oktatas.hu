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
        public Form1() {
            InitializeComponent();
        }

        private void BTN_kivon_Click(object sender, EventArgs e) {
            if(Convert.ToInt32(TBX_ujFeladvany.Text) != 4) {
                TBX_ujFeladvany.Text = (Convert.ToInt32(TBX_ujFeladvany.Text) - 1).ToString();
            }
        }

        private void BTN_hozzaad_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(TBX_ujFeladvany.Text) != 9){
                TBX_ujFeladvany.Text = (Convert.ToInt32(TBX_ujFeladvany.Text) + 1).ToString();
            }
        }

        private void TBX_kezdoAllapot_TextChanged(object sender, EventArgs e) {
            LBL_hossz.Text = "Hossz: "+TBX_kezdoAllapot.TextLength;
        }

        private void BTN_ellenorzes_Click(object sender, EventArgs e) {
            if(Convert.ToInt32(TBX_ujFeladvany.Text)==TBX_kezdoAllapot.TextLength) {
                MessageBox.Show("A feladvány megfelelő hosszúságú!");
            }
            else {
                MessageBox.Show("A feladvány hosszú: törlendő " + Convert.ToString(TBX_kezdoAllapot.TextLength - Convert.ToInt32(TBX_ujFeladvany.Text)) + " számjegy!");
            }
        }
    }
}
