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
            this.LBL_hossz = new System.Windows.Forms.Label();
            this.TBX_ujFeladvany = new System.Windows.Forms.TextBox();
            this.BTN_kivon = new System.Windows.Forms.Button();
            this.BTN_hozzaad = new System.Windows.Forms.Button();
            this.TBX_kezdoAllapot = new System.Windows.Forms.TextBox();
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
            // LBL_hossz
            // 
            this.LBL_hossz.AutoSize = true;
            this.LBL_hossz.Location = new System.Drawing.Point(12, 101);
            this.LBL_hossz.Name = "LBL_hossz";
            this.LBL_hossz.Size = new System.Drawing.Size(48, 13);
            this.LBL_hossz.TabIndex = 2;
            this.LBL_hossz.Text = "Hossz: 0";
            // 
            // TBX_ujFeladvany
            // 
            this.TBX_ujFeladvany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBX_ujFeladvany.Location = new System.Drawing.Point(149, 6);
            this.TBX_ujFeladvany.Name = "TBX_ujFeladvany";
            this.TBX_ujFeladvany.ReadOnly = true;
            this.TBX_ujFeladvany.Size = new System.Drawing.Size(23, 20);
            this.TBX_ujFeladvany.TabIndex = 3;
            this.TBX_ujFeladvany.Text = "4";
            this.TBX_ujFeladvany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // TBX_kezdoAllapot
            // 
            this.TBX_kezdoAllapot.Location = new System.Drawing.Point(15, 78);
            this.TBX_kezdoAllapot.Name = "TBX_kezdoAllapot";
            this.TBX_kezdoAllapot.Size = new System.Drawing.Size(497, 20);
            this.TBX_kezdoAllapot.TabIndex = 6;
            this.TBX_kezdoAllapot.TextChanged += new System.EventHandler(this.TBX_kezdoAllapot_TextChanged);
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
            this.Controls.Add(this.TBX_kezdoAllapot);
            this.Controls.Add(this.BTN_hozzaad);
            this.Controls.Add(this.BTN_kivon);
            this.Controls.Add(this.TBX_ujFeladvany);
            this.Controls.Add(this.LBL_hossz);
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
        private System.Windows.Forms.Label LBL_hossz;
        private System.Windows.Forms.TextBox TBX_ujFeladvany;
        private System.Windows.Forms.Button BTN_kivon;
        private System.Windows.Forms.Button BTN_hozzaad;
        private System.Windows.Forms.TextBox TBX_kezdoAllapot;
        private System.Windows.Forms.Button BTN_ellenorzes;
    }
}

