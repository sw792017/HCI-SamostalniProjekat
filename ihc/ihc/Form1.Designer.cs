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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.temepraturaCB = new System.Windows.Forms.CheckBox();
            this.pritisakCB = new System.Windows.Forms.CheckBox();
            this.vidljivostCB = new System.Windows.Forms.CheckBox();
            this.vlaznostCB = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dodajBTN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(677, 246);
            this.dataGridView1.TabIndex = 1;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(12, 318);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(677, 233);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // temepraturaCB
            // 
            this.temepraturaCB.AutoSize = true;
            this.temepraturaCB.Checked = true;
            this.temepraturaCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.temepraturaCB.Location = new System.Drawing.Point(275, 295);
            this.temepraturaCB.Name = "temepraturaCB";
            this.temepraturaCB.Size = new System.Drawing.Size(86, 17);
            this.temepraturaCB.TabIndex = 3;
            this.temepraturaCB.Text = "Temepratura";
            this.temepraturaCB.UseVisualStyleBackColor = true;
            // 
            // pritisakCB
            // 
            this.pritisakCB.AutoSize = true;
            this.pritisakCB.Location = new System.Drawing.Point(367, 295);
            this.pritisakCB.Name = "pritisakCB";
            this.pritisakCB.Size = new System.Drawing.Size(106, 17);
            this.pritisakCB.TabIndex = 4;
            this.pritisakCB.Text = "Vazdušni Pritisak";
            this.pritisakCB.UseVisualStyleBackColor = true;
            // 
            // vidljivostCB
            // 
            this.vidljivostCB.AutoSize = true;
            this.vidljivostCB.Location = new System.Drawing.Point(479, 295);
            this.vidljivostCB.Name = "vidljivostCB";
            this.vidljivostCB.Size = new System.Drawing.Size(67, 17);
            this.vidljivostCB.TabIndex = 5;
            this.vidljivostCB.Text = "Vidljivost";
            this.vidljivostCB.UseVisualStyleBackColor = true;
            // 
            // vlaznostCB
            // 
            this.vlaznostCB.AutoSize = true;
            this.vlaznostCB.Location = new System.Drawing.Point(552, 295);
            this.vlaznostCB.Name = "vlaznostCB";
            this.vlaznostCB.Size = new System.Drawing.Size(111, 17);
            this.vlaznostCB.TabIndex = 6;
            this.vlaznostCB.Text = "Vlažnost Vazduha";
            this.vlaznostCB.UseVisualStyleBackColor = true;
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
            this.comboBox1.Location = new System.Drawing.Point(15, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(298, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // dodajBTN
            // 
            this.dodajBTN.Location = new System.Drawing.Point(614, 11);
            this.dodajBTN.Name = "dodajBTN";
            this.dodajBTN.Size = new System.Drawing.Size(75, 24);
            this.dodajBTN.TabIndex = 8;
            this.dodajBTN.Text = "Dodaj";
            this.dodajBTN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Odaberite parametre koje želite da se prikažu u grafu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Od";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Do";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(343, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(492, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 563);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dodajBTN);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.vlaznostCB);
            this.Controls.Add(this.vidljivostCB);
            this.Controls.Add(this.pritisakCB);
            this.Controls.Add(this.temepraturaCB);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vremenska Prognoza";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.CheckBox temepraturaCB;
        private System.Windows.Forms.CheckBox pritisakCB;
        private System.Windows.Forms.CheckBox vidljivostCB;
        private System.Windows.Forms.CheckBox vlaznostCB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button dodajBTN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}

