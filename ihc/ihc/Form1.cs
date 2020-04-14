using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace ihc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 4;
            popuni(lokacija());
        }
        
        public void popuni(string lokacija, string vreme)
        {
            string url = @"https://api.darksky.net/forecast/7f06dd7200dc1fc07af4db4e94039491/" + lokacija + "/" + vreme;
            string rezultat = "error";

            try
            {
                using (var client = new WebClient())
                {
                    rezultat = client.DownloadString(url);
                }
            }
            catch { rezultat = "error";  }

            if(rezultat != "error")
            {

            }
            else
            {
                MessageBox.Show("Došlo je do greške sa komunikacijom sa serverom. Molimo vas da se proverite vašu konekciju sa internetom", "Greška");
            }
        }

        public void popuni(string lokacija)
        {
            string url = @"https://api.darksky.net/forecast/7f06dd7200dc1fc07af4db4e94039491/" + lokacija;
            string rezultat = "error";

            try
            {
                using (var client = new WebClient())
                {
                    rezultat = client.DownloadString(url);
                }
            }
            catch { rezultat = "error"; }

            if (rezultat != "error")
            {

            }
            else
            {
                MessageBox.Show("Došlo je do greške sa komunikacijom sa serverom. Molimo vas da se proverite vašu konekciju sa internetom", "Greška");
            }
        }

        public string lokacija()
        {
            string s;
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0://beograd
                        s = "44.795916,20.448781";
                        break;
                    case 1://valjevo
                        s = "44.272662,19.884443";
                        break;
                    case 2://leskovac
                        s = "42.994691,21.943203";
                        break;
                    case 3://nis
                        s = "43.316763,21.893982";
                        break;
                    case 4://novi sad
                        s = "45.265937,19.834985";
                        break;
                    case 5://subotica
                        s = "46.100456,19.663514";
                        break;
                    default:
                        s = "45.265937,19.834985";//novi sad
                        break;
                }
            }
            catch { s = "45.265937,19.834985"; }

            return s;
        }
    }
}
