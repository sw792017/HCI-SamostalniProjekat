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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace ihc
{
    public partial class Form1 : Form
    {
        List<string> lista = new List<string>();
        List<string> listaXL = new List<string>();
        List<string> dani = new List<string>{ "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" };
        List<int> prikaziGrad = new List<int> { 4 };
        string sada = "";
        int index = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            /*checkedComboBox1.Items.Add("Beograd", false);
            checkedComboBox1.Items.Add("Valjevo", false);
            checkedComboBox1.Items.Add("Leskovac", false);
            checkedComboBox1.Items.Add("Niš", false);
            checkedComboBox1.Items.Add("Novi Sad", true);
            checkedComboBox1.Items.Add("Subotica", false);*/

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
            
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
            popuni(lokacija(4));
            napraviGraf();
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
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 myTimestamp = (Int32)((DateTime.UtcNow.Subtract(DateTime.Now)).TotalSeconds /*+ DateTime.Now.Hour* 3600 + DateTime.Now.Minute* 60*/);
            Int32 sekundi = unixTimestamp - myTimestamp - 7200;
            
            string url = @"https://api.darksky.net/forecast/7f06dd7200dc1fc07af4db4e94039491/" + lokacija + "," + sekundi;
            string rezultat = "error";
            bool hajde = true;
            if (imamPodatke(lokacija) == -1)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        rezultat = client.DownloadString(url);
                    }
                }
                catch { rezultat = "error"; MessageBox.Show("Došlo je do greške sa komunikacijom sa serverom. Molimo vas da se proverite vašu konekciju sa internetom", "Greška"); return; }
            }
            else
            {
                rezultat = lista.ElementAt(imamPodatke(lokacija));
                hajde = false;
            }
            if (rezultat != "error")
            {
                //////////////////////////////////////////////////////////////////////////////////////////

                var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);
                if (sada == "")
                    sada = Jvreme.daily.data[0].time;
                //MessageBox.Show(sada.ToString());
                double temperatura = (Convert.ToDouble(Jvreme.hourly.data[DateTime.Now.Hour].temperature) - 32) / 1.8;
                double temperaturaV = (Convert.ToDouble(Jvreme.daily.data[0].temperatureHigh) - 32) / 1.8;
                double temperaturaN = (Convert.ToDouble(Jvreme.daily.data[0].temperatureLow) - 32) / 1.8;
                string opis = Jvreme.daily.data[0].icon;
                string grad = Jvreme.latitude;
                dataGridView1.Rows.Add(
                    lokacijaUnazad2(grad),
                    prevedi(opis),
                    UnixTimeStampToDateTime(Convert.ToDouble(Jvreme.hourly.data[DateTime.Now.Hour].time)),
                    Math.Round(temperatura, 2) + "℃",
                    Math.Round(temperaturaV, 2) + "℃",
                    Math.Round(temperaturaN, 2) + "℃",
                    Jvreme.hourly.data[DateTime.Now.Hour].pressure + " mbar",
                    Jvreme.hourly.data[DateTime.Now.Hour].visibility + " km",
                    (Convert.ToDouble(Jvreme.hourly.data[DateTime.Now.Hour].humidity) * 100) + "%");
                //////////////////////////////////////////////////////////////////////////////////////////
                lista.Add(rezultat);
                Console.WriteLine(sada);
                //comboBox1.Items.Remove(comboBox1.Text);
                if (hajde)
                {
                    url = @"https://api.darksky.net/forecast/7f06dd7200dc1fc07af4db4e94039491/" + lokacija;
                    using (var client = new WebClient())
                    {
                        rezultat = client.DownloadString(url);
                    }
                    listaXL.Add(rezultat);
                }
                nacrtaj();
            }
            else
            {
                MessageBox.Show("Došlo je do greške sa komunikacijom sa serverom. Molimo vas da se proverite vašu konekciju sa internetom", "Greška");
            }
        }

        public string lokacija(int i)
        {
            string s;
            try
            {
                switch (i)
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
                    default://nikada nece upasti
                        s = "45.265937,19.834985";//novi sad
                        break;
                }
            }
            catch { s = "45.265937,19.834985"; }

            return s;
        }
        public string lokacijaUnazad(string l)
        {
            string s;
            try
            {
                switch (l)
                {
                    case "44.795916"://beograd
                        s = "u Beogradu";
                        break;
                    case "44.013767"://veljevo
                        s = "u Valjevu";
                        break;
                    case "42.994691"://leskovac
                        s = "u Leskovcu";
                        break;
                    case "43.316763"://nis
                        s = "u Nišu";
                        break;
                    case "45.265937"://novi sad
                        s = "u Novom Sadu";
                        break;
                    case "46.100456"://subotica
                        s = "u Subotici";
                        break;
                    default://nikada nece upasti
                        s = "";
                        break;
                }
            }
            catch { s = "45.265937,19.834985"; }

            return s;
        }

        public string lokacijaUnazad2(string l)
        {
            string s;
            try
            {
                switch (l)
                {
                    case "44.795916"://beograd
                        s = "Beograd";
                        break;
                    case "44.013767"://veljevo
                        s = "Valjevo";
                        break;
                    case "42.994691"://leskovac
                        s = "Leskovac";
                        break;
                    case "43.316763"://nis
                        s = "Niš";
                        break;
                    case "45.265937"://novi sad
                        s = "Novi Sad";
                        break;
                    case "46.100456"://subotica
                        s = "Subotica";
                        break;
                    default://nikada nece upasti
                        s = "";
                        break;
                }
            }
            catch { s = "45.265937,19.834985"; }

            return s;
        }

        private void pritisakRB_CheckedChanged(object sender, EventArgs e)
        {
            nacrtaj();
        }
        private void TemepraturaRB_CheckedChanged(object sender, EventArgs e)
        {
            nacrtaj();
        }
        private void vidljivostRB_CheckedChanged(object sender, EventArgs e)
        {
            nacrtaj();
        }
        private void vlaznostRB_CheckedChanged(object sender, EventArgs e)
        {
            nacrtaj();
        }

        private void napraviGraf() {
            if (lista.Count == 0)
                return;
            var rezultat = lista[0];
            var jObject = JObject.Parse(rezultat);

            var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);
            string grad = Jvreme.latitude;
            grad = lokacijaUnazad(grad);
            chart11.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Temperatura " + grad, LabelFormatter = value => value.ToString() + "℃" });
            chart11.LegendLocation = LiveCharts.LegendLocation.Right;

            nacrtaj();
        }

        public string dan(int i)
        {
            string s = "";
            switch(index){
                case 1:
                    s= "Danas u ";
                    break;
                case 2:
                    s = "Sutra u ";
                    break;
                case 3:
                    s = "Prekosutra u ";
                    break;
            }
            if (i == 23 || i == 23+24)
                ++index;
            Console.WriteLine("id = " + i + ", index = " + index);
            return s;
        }

        public int danOffset()
        {
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Monday":
                    return 0;
                case "Tuesday":
                    return 1;
                case "Wednesday":
                    return 2;
                case "Thursday":
                    return 3;
                case "Friday":
                    return 4;
                case "Saturday":
                    return 5;
                case "Sunday":
                    return 6;
                default:
                    return 0;
            }
        }

        private void nacrtaj()
        {
            List<string> iscrtano = new List<string>();
            string parametar;
            foreach(var u in chart11.AxisY)
            {
                chart11.AxisY.Remove(u);
            }
            foreach (var u in chart11.AxisX)
            {
                chart11.AxisX.Remove(u);
            }
            //chart11.AxisY.RemoveAt(0);
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    chart11.AxisX.Add(new LiveCharts.Wpf.Axis { Title = "Sati", Labels = new[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "23:59" } });
                    break;
                case 1:
                    int br = DateTime.Now.Hour;
                    index = 1;
                    chart11.AxisX.Add(new LiveCharts.Wpf.Axis { Title = "Sati", Labels = new[] { dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", dan(br) + ((br++) % 24).ToString("00") + ":00", } });
                        break;
                default:
                    int offset = danOffset();
                    chart11.AxisX.Add(new LiveCharts.Wpf.Axis { Title = "Dan", Labels = new[] { "Danas("+dani[(offset+0)%7]+")", dani[(offset+1) % 7], dani[(offset+2) % 7], dani[(offset+3) % 7], dani[(offset+4) % 7], dani[(offset+5) % 7], dani[(offset+6) % 7] } });
                    break;
            }
            if (vidljivostRB.Checked)
            {
                chart11.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Vidljivost", LabelFormatter = value => value.ToString() + "km" });
                parametar = "v";
            }
            else if (vlaznostRB.Checked)
            {
                chart11.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Vlažnost Vazduha", LabelFormatter = value => (value*100).ToString() + "%" });
                parametar = "l";
            }
            else if (pritisakRB.Checked)
            {
                chart11.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Pritisak", LabelFormatter = value => value.ToString() + "mbar" });
                parametar = "p";
            }
            else
            {
                chart11.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Temperatura", LabelFormatter = value => value.ToString() + "℃" });
                parametar = "t";
            }
            chart11.Series.Clear();

            if (comboBox2.SelectedIndex == 0)
            {
                foreach (string rezultat in lista)
                {
                    var jObject = JObject.Parse(rezultat);

                    var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);
                    string l = Jvreme.latitude;
                    if (iscrtano.Contains(l) || odbaceno(l))
                        continue;
                    else if (parametar == "t")//temperatura
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> temperatura = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            temperatura.Add(Math.Round(((Convert.ToDouble(Jvreme.hourly.data[i].temperature) - 32) / 1.8), 2));
                        chart11.Series.Add(new LineSeries() { Title = "Temperatura " + grad, Values = temperatura });
                    }

                    else if (parametar == "p")//pritisak
                    {

                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> pritisak = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            pritisak.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].pressure), 1));
                        chart11.Series.Add(new LineSeries() { Title = "Pritisak " + grad, Values = pritisak });
                    }

                    else if (parametar == "v")//vidljivost
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            vidljivost.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].visibility), 0));
                        chart11.Series.Add(new LineSeries() { Title = "Vidljivost " + grad, Values = vidljivost });
                    }

                    else if (parametar == "l")//vlaznost vazduha
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            vidljivost.Add(Convert.ToDouble(Jvreme.hourly.data[i].humidity));
                        chart11.Series.Add(new LineSeries() { Title = "Vlažnost Vazduha " + grad, Values = vidljivost });
                    }
                    iscrtano.Add(l);
                }
            }
            else
            {
                foreach (string rezultat in listaXL)
                {
                    var jObject = JObject.Parse(rezultat);

                    var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);
                    string l = Jvreme.latitude;
                    //Console.WriteLine("/////////////////////////////////");
                    //Console.WriteLine(Jvreme.daily);
                    //Console.WriteLine("/////////////////////////////////");
                    if (iscrtano.Contains(l) || odbaceno(l))
                        continue;
                    else if (parametar == "t")//temperatura
                    {
                        if (comboBox2.SelectedIndex == 1)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> temperatura = new ChartValues<double>();
                            for (int i = 0; i < 48; ++i)
                                temperatura.Add(Math.Round(((Convert.ToDouble(Jvreme.hourly.data[i].temperature) - 32) / 1.8), 2));
                            chart11.Series.Add(new LineSeries() { Title = "Temperatura " + grad, Values = temperatura });
                        }
                        else if (comboBox2.SelectedIndex == 2)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> temperatura = new ChartValues<double>();
                            for (int i = 0; i < 7; ++i)
                                temperatura.Add(Math.Round(((Convert.ToDouble((Jvreme.daily.data[i].temperatureLow + Jvreme.daily.data[i].temperatureHigh) / 2) - 32) / 1.8), 2));
                            chart11.Series.Add(new LineSeries() { Title = "Temperatura " + grad, Values = temperatura });
                        }

                    }

                    else if (parametar == "p")//pritisak
                    {
                        if (comboBox2.SelectedIndex == 1)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> pritisak = new ChartValues<double>();
                            for (int i = 0; i < 48; ++i)
                                pritisak.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].pressure), 1));
                            chart11.Series.Add(new LineSeries() { Title = "Pritisak " + grad, Values = pritisak });
                        }
                        else if (comboBox2.SelectedIndex == 2)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> pritisak = new ChartValues<double>();
                            for (int i = 0; i < 7; ++i)
                                pritisak.Add(Math.Round(Convert.ToDouble(Jvreme.daily.data[i].pressure), 1));
                            chart11.Series.Add(new LineSeries() { Title = "Pritisak " + grad, Values = pritisak });
                        }
                    }

                    else if (parametar == "v")//vidljivost
                    {
                        if (comboBox2.SelectedIndex == 1)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> vidljivost = new ChartValues<double>();
                            for (int i = 0; i < 48; ++i)
                                vidljivost.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].visibility), 0));
                            chart11.Series.Add(new LineSeries() { Title = "Vidljivost " + grad, Values = vidljivost });
                        }
                        else if (comboBox2.SelectedIndex == 2)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> vidljivost = new ChartValues<double>();
                            for (int i = 0; i < 7; ++i)
                                vidljivost.Add(Math.Round(Convert.ToDouble(Jvreme.daily.data[i].visibility), 0));
                            chart11.Series.Add(new LineSeries() { Title = "Vidljivost " + grad, Values = vidljivost });
                        }
                    }

                    else if (parametar == "l")//vlaznost vazduha
                    {
                        if (comboBox2.SelectedIndex == 1)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> vidljivost = new ChartValues<double>();
                            for (int i = 0; i < 24; ++i)
                                vidljivost.Add(Convert.ToDouble(Jvreme.hourly.data[i].humidity));
                            chart11.Series.Add(new LineSeries() { Title = "Vlažnost Vazduha " + grad, Values = vidljivost });
                        }
                        else if (comboBox2.SelectedIndex == 2)
                        {
                            string grad = Jvreme.latitude;
                            grad = lokacijaUnazad(grad);
                            ChartValues<double> vidljivost = new ChartValues<double>();
                            for (int i = 0; i < 7; ++i)
                                vidljivost.Add(Convert.ToDouble(Jvreme.daily.data[i].humidity));
                            chart11.Series.Add(new LineSeries() { Title = "Vlažnost Vazduha " + grad, Values = vidljivost });
                        }
                    }
                    iscrtano.Add(l);
                }
            }

            /*foreach(string rezultat in lista)
            {
                var jObject = JObject.Parse(rezultat);
                
                var Jvreme = JsonConvert.DeserializeObject<dynamic>(rezultat);
                string l = Jvreme.latitude;
                string dan = Jvreme.daily.data[0].time;
                if (sada != dan)
                    continue;
                else if (iscrtano.Contains(l))
                    continue;
                else if (parametar == "t")//temperatura
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> temperatura = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            temperatura.Add(Math.Round(((Convert.ToDouble(Jvreme.hourly.data[i].temperature) - 32) / 1.8), 2));
                        chart11.Series.Add(new LineSeries() { Title = "Temperatura " + grad, Values = temperatura });
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> temperatura = new ChartValues<double>();
                        for (int i = 0; i < 7; ++i)
                            temperatura.Add(Math.Round(((Convert.ToDouble((Jvreme.daily.data[i].temperatureLow + Jvreme.daily.data[i].temperatureHigh)/2) - 32) / 1.8), 2));
                        chart11.Series.Add(new LineSeries() { Title = "Temperatura " + grad, Values = temperatura });
                    }

                }

                else if (parametar == "p")//pritisak
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> pritisak = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            pritisak.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].pressure), 1));
                        chart11.Series.Add(new LineSeries() { Title = "Pritisak " + grad, Values = pritisak });
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> pritisak = new ChartValues<double>();
                        for (int i = 0; i < 7; ++i)
                            pritisak.Add(Math.Round(Convert.ToDouble(Jvreme.daily.data[i].pressure), 1));
                        chart11.Series.Add(new LineSeries() { Title = "Pritisak " + grad, Values = pritisak });
                    }
                }

                else if (parametar == "v")//vidljivost
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            vidljivost.Add(Math.Round(Convert.ToDouble(Jvreme.hourly.data[i].visibility), 0));
                        chart11.Series.Add(new LineSeries() { Title = "Vidljivost " + grad, Values = vidljivost });
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 7; ++i)
                            vidljivost.Add(Math.Round(Convert.ToDouble(Jvreme.daily.data[i].visibility), 0));
                        chart11.Series.Add(new LineSeries() { Title = "Vidljivost " + grad, Values = vidljivost });
                    }
                }

                else if (parametar == "l")//vlaznost vazduha
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 24; ++i)
                            vidljivost.Add(Convert.ToDouble(Jvreme.hourly.data[i].humidity));
                        chart11.Series.Add(new LineSeries() { Title = "Vlažnost Vazduha " + grad, Values = vidljivost });
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        string grad = Jvreme.latitude;
                        grad = lokacijaUnazad(grad);
                        ChartValues<double> vidljivost = new ChartValues<double>();
                        for (int i = 0; i < 7; ++i)
                            vidljivost.Add(Convert.ToDouble(Jvreme.daily.data[i].humidity));
                        chart11.Series.Add(new LineSeries() { Title = "Vlažnost Vazduha " + grad, Values = vidljivost });
                    }
                }
                iscrtano.Add(l);
            }*/
        }

        public bool odbaceno(string l)
        {
            string s;
            try
            {
                switch (l)
                {
                    case "44.795916"://beograd
                        return !prikaziGrad.Contains(0);
                    case "44.013767"://veljevo
                        return !prikaziGrad.Contains(1);
                    case "42.994691"://leskovac
                        return !prikaziGrad.Contains(2);
                    case "43.316763"://nis
                        return !prikaziGrad.Contains(3);
                    case "45.265937"://novi sad
                        return !prikaziGrad.Contains(4);
                    case "46.100456"://subotica
                        return !prikaziGrad.Contains(5);
                    default://nikada nece upasti
                        s = "";
                        break;
                }
            }
            catch { return false; }
            return false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            nacrtaj();
        }

        public int imamPodatke(string lokacija)
        {
            for (int i = 0; i < lista.Count; ++i)
            {
                var Jvreme = JsonConvert.DeserializeObject<dynamic>(lista.ElementAt(i));
                string ss = Jvreme.latitude;
                if (lokacija.Contains(ss))
                {
                    return i;
                }
            }
            return -1;
        }

        private void GradSelectChange(object sender, EventArgs e)
        {
            List<Object> lista = new List<object> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            for (int i = 0; i < lista.Count; ++i)
            {
                CheckBox c = (CheckBox)lista[i];
                if (c.Checked)
                {
                    if (!prikaziGrad.Contains(i)) prikaziGrad.Add(i);
                }
                else
                    if (prikaziGrad.Contains(i)) prikaziGrad.Remove(i);
            }
            do
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dataGridView1.Rows.Count > 1);

            foreach (int i in prikaziGrad)
            {
                popuni(lokacija(i));
            }
        }
    }
}
