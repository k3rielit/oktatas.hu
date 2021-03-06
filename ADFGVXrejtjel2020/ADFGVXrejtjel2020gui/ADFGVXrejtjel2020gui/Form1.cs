using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ADFGVXrejtjel2020gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string chars = "abcdefghijklmnopqrstuvwxyz123456789";
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            if(open.FileName!="") {
                listBox1.Items.Clear();
                using (StreamReader read = new StreamReader(open.OpenFile())) {
                    string[] lines = read.ReadToEnd().Replace('\n'.ToString(),"").Split('\r');
                    bool format = lines.Length==6;
                    for(int lc=0; lc<lines.Length; lc++) {
                        format = format && lines[lc].Length==6;
                        foreach(char ch in lines[lc].ToCharArray()) {
                            if(!chars.Contains(ch)) {
                                listBox1.Items.Add($"Hibás karakter ({ch}) van a mátrixban!");
                            }
                        }
                    }
                    foreach (char ch in chars) {
                        if(string.Join("",lines).Count(s => s==ch)!=1) {
                            listBox1.Items.Add($"A(z) {ch} karakter {string.Join("",lines).Count(s => s==ch)}x szerepel a mátrixban!");
                        }
                    }
                    if (!format) {listBox1.Items.Add("Hiba a mátrix méretében!");}
                    codeTable.Text = string.Join("\n",lines.Select(s => string.Join(" ",s.ToCharArray())));
                }
            }
        }
    }
}
