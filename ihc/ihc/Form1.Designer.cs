namespace ihc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart11 = new LiveCharts.WinForms.CartesianChart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dodajBTN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.TemepraturaRB = new System.Windows.Forms.RadioButton();
            this.pritisakRB = new System.Windows.Forms.RadioButton();
            this.vidljivostRB = new System.Windows.Forms.RadioButton();
            this.vlaznostRB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(943, 246);
            this.dataGridView1.TabIndex = 1;
            // 
            // chart11
            // 
            this.chart11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart11.Location = new System.Drawing.Point(12, 339);
            this.chart11.Name = "chart11";
            this.chart11.Size = new System.Drawing.Size(940, 267);
            this.chart11.TabIndex = 2;
            this.chart11.Text = "cartesianChart1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Beograd",
            "Valjevo",
            "Leskovac",
            "Niš",
            "Novi Sad",
            "Subotica"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // dodajBTN
            // 
            this.dodajBTN.Location = new System.Drawing.Point(222, 11);
            this.dodajBTN.Name = "dodajBTN";
            this.dodajBTN.Size = new System.Drawing.Size(75, 23);
            this.dodajBTN.TabIndex = 8;
            this.dodajBTN.Text = "Dodaj";
            this.dodajBTN.UseVisualStyleBackColor = true;
            this.dodajBTN.Click += new System.EventHandler(this.dodajBTN_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Odaberite parametar koji želite da se prikaže u grafu :";
            // 
            // TemepraturaRB
            // 
            this.TemepraturaRB.AutoSize = true;
            this.TemepraturaRB.Checked = true;
            this.TemepraturaRB.Location = new System.Drawing.Point(275, 293);
            this.TemepraturaRB.Name = "TemepraturaRB";
            this.TemepraturaRB.Size = new System.Drawing.Size(85, 17);
            this.TemepraturaRB.TabIndex = 15;
            this.TemepraturaRB.TabStop = true;
            this.TemepraturaRB.Text = "Temepratura";
            this.TemepraturaRB.UseVisualStyleBackColor = true;
            this.TemepraturaRB.CheckedChanged += new System.EventHandler(this.TemepraturaRB_CheckedChanged);
            // 
            // pritisakRB
            // 
            this.pritisakRB.AutoSize = true;
            this.pritisakRB.Location = new System.Drawing.Point(366, 293);
            this.pritisakRB.Name = "pritisakRB";
            this.pritisakRB.Size = new System.Drawing.Size(105, 17);
            this.pritisakRB.TabIndex = 16;
            this.pritisakRB.Text = "Vazdušni Pritisak";
            this.pritisakRB.UseVisualStyleBackColor = true;
            this.pritisakRB.CheckedChanged += new System.EventHandler(this.pritisakRB_CheckedChanged);
            // 
            // vidljivostRB
            // 
            this.vidljivostRB.AutoSize = true;
            this.vidljivostRB.Location = new System.Drawing.Point(477, 293);
            this.vidljivostRB.Name = "vidljivostRB";
            this.vidljivostRB.Size = new System.Drawing.Size(66, 17);
            this.vidljivostRB.TabIndex = 17;
            this.vidljivostRB.Text = "Vidljivost";
            this.vidljivostRB.UseVisualStyleBackColor = true;
            this.vidljivostRB.CheckedChanged += new System.EventHandler(this.vidljivostRB_CheckedChanged);
            // 
            // vlaznostRB
            // 
            this.vlaznostRB.AutoSize = true;
            this.vlaznostRB.Location = new System.Drawing.Point(549, 293);
            this.vlaznostRB.Name = "vlaznostRB";
            this.vlaznostRB.Size = new System.Drawing.Size(110, 17);
            this.vlaznostRB.TabIndex = 18;
            this.vlaznostRB.Text = "Vlažnost Vazduha";
            this.vlaznostRB.UseVisualStyleBackColor = true;
            this.vlaznostRB.CheckedChanged += new System.EventHandler(this.vlaznostRB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Odaberite vremenski interval koji želite da se iscrta u grafu :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Za danas",
            "Sledećih 48h",
            "Za ovu nedelje"});
            this.comboBox2.Location = new System.Drawing.Point(304, 312);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 618);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart11);
            this.Controls.Add(this.vlaznostRB);
            this.Controls.Add(this.vidljivostRB);
            this.Controls.Add(this.pritisakRB);
            this.Controls.Add(this.TemepraturaRB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dodajBTN);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "Form1";
            this.Text = "Vremenska Prognoza";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private LiveCharts.WinForms.CartesianChart chart11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button dodajBTN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TemepraturaRB;
        private System.Windows.Forms.RadioButton pritisakRB;
        private System.Windows.Forms.RadioButton vidljivostRB;
        private System.Windows.Forms.RadioButton vlaznostRB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

