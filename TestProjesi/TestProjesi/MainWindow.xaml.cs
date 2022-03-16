using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TestProjesi
{
  
    public partial class MainWindow : Window
    {
        private Api api;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btsend_server(object sender, RoutedEventArgs e)
        {
           
            if (new Regex("[^0-9]+").IsMatch(txt_Bracelet_Size.Text))
            {
                MessageBox.Show("User Input Is Not An Integer");
            }
            else if (Convert.ToInt32(txt_Bracelet_Size.Text) > 5 || Convert.ToInt32(txt_Bracelet_Size.Text) < 1)
            {
                MessageBox.Show("User Input Must Be Between 1 And 5");
            }
            else 
            {
                HttpWebResponse responce = (HttpWebResponse)WebRequest.Create("http://kutez.com/testapi/get_diameter.php?size=" + txt_Bracelet_Size.Text).GetResponse();
                if (responce.StatusDescription != "OK")
                {
                    MessageBox.Show("Server Error");
                }
                else
                {
                    api = JsonConvert.DeserializeObject<Api>(new StreamReader(responce.GetResponseStream()).ReadToEnd());
                    lbl_big_diameter.Content = api.bigdiameter;
                    lbl_small_diameter.Content = api.smalldiameter;

                    int elips_a = Convert.ToInt32(lbl_big_diameter.Content) / 2; 
                    int elips_b = Convert.ToInt32(lbl_small_diameter.Content) / 2;
                    double cevre = (Math.PI * 2) * Math.Sqrt(((elips_a * elips_a) + (elips_b * elips_b)) / 2);
                    lbl_perimeterResult.Content = cevre.ToString("F2");
                }
            }
        
        }

    }
}
