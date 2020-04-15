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
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;

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

            ////////////////////////////////////////////
            dataGridView1.ColumnCount = 9;

            dataGridView1.Columns[0].Name = "Lokacija";
            dataGridView1.Columns[1].Name = "Opis";
            dataGridView1.Columns[2].Name = "Vreme merenja";
            dataGridView1.Columns[3].Name = "Trenutna temperatura";
            dataGridView1.Columns[4].Name = "Najviša temeperatura";
            dataGridView1.Columns[5].Name = "Najniža temperatura";
            dataGridView1.Columns[6].Name = "Vazdušni pritisak";
            dataGridView1.Columns[7].Name = "Vidljivost";
            dataGridView1.Columns[8].Name = "Vlažnost vazduha";
            ////////////////////////////////////////////
            popuni(lokacija());
        }
        
        public void popuni(string lokacija, string vreme)
        {
            //TODO:
        }

        public static String UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString("dd/MM/yyyy H:mm");
        }

        public string prevedi(string tekst)
        {
            switch (tekst){
                case "clear-day":
                    return "Vedro";
                case "clear-night":
                    return "Vedro";
                case "cloudy":
                    return "Oblačno";
                case "fog":
                    return "Maglovito";
                case "partly-cloudy-day":
                    return "Umereno Oblačno";
                case "partly-cloudy-night":
                    return "Umereno Oblačno";
                case "rain":
                    return "Kišovito";
                case "sleet":
                    return "Susnežica";
                case "snow":
                    return "Sneg";
                case "wind":
                    return "Vetrovito";
                default:
                    return "Vedro";
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
                //////////////////////////////////////////////////////////////////////////////////////////
                var jObject = JObject.Parse(rezultat);

                var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);

                double temperatura = (Convert.ToDouble(Jvreme.currently.temperature) - 32 ) / 1.8;
                double temperaturaV = (Convert.ToDouble(Jvreme.daily.data[0].temperatureHigh) - 32) / 1.8;
                double temperaturaN = (Convert.ToDouble(Jvreme.daily.data[0].temperatureLow) - 32) / 1.8;
                string opis = Jvreme.daily.data[0].icon;
                dataGridView1.Rows.Add(comboBox1.Text, prevedi(opis), UnixTimeStampToDateTime(Convert.ToDouble(Jvreme.daily.data[0].time)), Math.Round(temperatura, 2) + "℃", Math.Round(temperaturaV, 2) + "℃", Math.Round(temperaturaN, 2) + "℃", Jvreme.currently.pressure, Jvreme.currently.visibility, (Convert.ToDouble(Jvreme.currently.humidity)*100) + "%");
                //////////////////////////////////////////////////////////////////////////////////////////
                //lista.Add(comboBox1.Text);
                //comboBox1.Items.Remove(comboBox1.Text);
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
                    case 1://kragujevac
                        s = "44.013767, 20.912735";
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

        private void dodajBTN_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 2)
                popuni(lokacija());
        }
    }
}
