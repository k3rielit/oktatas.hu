using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playfair2020gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void TBX_input_TextChanged(object sender, EventArgs e) {
            label.ForeColor = Color.Green;
            // magenta error (same characters in a pair) (f)
            foreach (string item in TBX_input.Text.Trim().Split(' ')) {
                if(item.ToCharArray().Distinct().Count() < 2) {
                    label.ForeColor = Color.Magenta;
                    break;
                }
            }
            // blue error (lowercase letters) (e)
            label.ForeColor = TBX_input.Text.Any(char.IsLower) ? Color.Blue : label.ForeColor;
            // red error (character pair length != 2) (d)
            label.ForeColor = TBX_input.Text.Split(' ').Where(s => s.Length!=2).Count() > 0 ? Color.Red : label.ForeColor;
        }
    }
}