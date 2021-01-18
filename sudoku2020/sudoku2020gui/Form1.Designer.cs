namespace sudoku2020gui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Hossz = new System.Windows.Forms.Label();
            this.Meret = new System.Windows.Forms.TextBox();
            this.BTN_kivon = new System.Windows.Forms.Button();
            this.BTN_hozzaad = new System.Windows.Forms.Button();
            this.Kezdoallapot = new System.Windows.Forms.TextBox();
            this.BTN_ellenorzes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Új feladvány mérete:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kezdőállapot";
            // 
            // Hossz
            // 
            this.Hossz.AutoSize = true;
            this.Hossz.Location = new System.Drawing.Point(12, 101);
            this.Hossz.Name = "Hossz";
            this.Hossz.Size = new System.Drawing.Size(48, 13);
            this.Hossz.TabIndex = 2;
            this.Hossz.Text = "Hossz: 0";
            // 
            // Meret
            // 
            this.Meret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Meret.Location = new System.Drawing.Point(149, 6);
            this.Meret.Name = "Meret";
            this.Meret.ReadOnly = true;
            this.Meret.Size = new System.Drawing.Size(23, 20);
            this.Meret.TabIndex = 3;
            this.Meret.Text = "4";
            this.Meret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BTN_kivon
            // 
            this.BTN_kivon.Location = new System.Drawing.Point(121, 4);
            this.BTN_kivon.Name = "BTN_kivon";
            this.BTN_kivon.Size = new System.Drawing.Size(22, 23);
            this.BTN_kivon.TabIndex = 4;
            this.BTN_kivon.Text = "-";
            this.BTN_kivon.UseVisualStyleBackColor = true;
            this.BTN_kivon.Click += new System.EventHandler(this.BTN_kivon_Click);
            // 
            // BTN_hozzaad
            // 
            this.BTN_hozzaad.Location = new System.Drawing.Point(178, 5);
            this.BTN_hozzaad.Name = "BTN_hozzaad";
            this.BTN_hozzaad.Size = new System.Drawing.Size(22, 23);
            this.BTN_hozzaad.TabIndex = 5;
            this.BTN_hozzaad.Text = "+";
            this.BTN_hozzaad.UseVisualStyleBackColor = true;
            this.BTN_hozzaad.Click += new System.EventHandler(this.BTN_hozzaad_Click);
            // 
            // Kezdoallapot
            // 
            this.Kezdoallapot.Location = new System.Drawing.Point(15, 78);
            this.Kezdoallapot.Name = "Kezdoallapot";
            this.Kezdoallapot.Size = new System.Drawing.Size(497, 20);
            this.Kezdoallapot.TabIndex = 6;
            this.Kezdoallapot.TextChanged += new System.EventHandler(this.KezdoallapotChange);
            // 
            // BTN_ellenorzes
            // 
            this.BTN_ellenorzes.Location = new System.Drawing.Point(436, 105);
            this.BTN_ellenorzes.Name = "BTN_ellenorzes";
            this.BTN_ellenorzes.Size = new System.Drawing.Size(75, 23);
            this.BTN_ellenorzes.TabIndex = 7;
            this.BTN_ellenorzes.Text = "Ellenőrzés";
            this.BTN_ellenorzes.UseVisualStyleBackColor = true;
            this.BTN_ellenorzes.Click += new System.EventHandler(this.BTN_ellenorzes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 171);
            this.Controls.Add(this.BTN_ellenorzes);
            this.Controls.Add(this.Kezdoallapot);
            this.Controls.Add(this.BTN_hozzaad);
            this.Controls.Add(this.BTN_kivon);
            this.Controls.Add(this.Meret);
            this.Controls.Add(this.Hossz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sudoku-ellenőrző";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Hossz;
        private System.Windows.Forms.TextBox Meret;
        private System.Windows.Forms.Button BTN_kivon;
        private System.Windows.Forms.Button BTN_hozzaad;
        private System.Windows.Forms.TextBox Kezdoallapot;
        private System.Windows.Forms.Button BTN_ellenorzes;
    }
}

