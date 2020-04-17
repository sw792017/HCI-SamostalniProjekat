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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.TemepraturaRB = new System.Windows.Forms.RadioButton();
            this.pritisakRB = new System.Windows.Forms.RadioButton();
            this.vidljivostRB = new System.Windows.Forms.RadioButton();
            this.vlaznostRB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(943, 258);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(247, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Beograd";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(319, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(61, 17);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "Valjevo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(386, 8);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(73, 17);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Leskovac";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(465, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(41, 17);
            this.checkBox4.TabIndex = 24;
            this.checkBox4.Text = "Niš";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(512, 8);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(70, 17);
            this.checkBox5.TabIndex = 25;
            this.checkBox5.Text = "Novi Sad";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(588, 8);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(68, 17);
            this.checkBox6.TabIndex = 26;
            this.checkBox6.Text = "Subotica";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.GradSelectChange);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Odaberite gradove koje želite da da posmatrate :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 618);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart11);
            this.Controls.Add(this.vlaznostRB);
            this.Controls.Add(this.vidljivostRB);
            this.Controls.Add(this.pritisakRB);
            this.Controls.Add(this.TemepraturaRB);
            this.Controls.Add(this.label1);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TemepraturaRB;
        private System.Windows.Forms.RadioButton pritisakRB;
        private System.Windows.Forms.RadioButton vidljivostRB;
        private System.Windows.Forms.RadioButton vlaznostRB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label2;
    }
}

