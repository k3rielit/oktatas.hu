namespace playfair2020gui
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
            this.TBX_input = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBX_input
            // 
            this.TBX_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBX_input.Location = new System.Drawing.Point(12, 37);
            this.TBX_input.Multiline = true;
            this.TBX_input.Name = "TBX_input";
            this.TBX_input.Size = new System.Drawing.Size(776, 385);
            this.TBX_input.TabIndex = 0;
            this.TBX_input.Text = "HI DE TH EG OL DI NT HE TR EX ES TU MP";
            this.TBX_input.TextChanged += new System.EventHandler(this.TBX_input_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Green;
            this.label.Location = new System.Drawing.Point(19, 12);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(103, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Előkészített szöveg:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.TBX_input);
            this.Name = "Form1";
            this.Text = "playfairGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBX_input;
        private System.Windows.Forms.Label label;
    }
}

