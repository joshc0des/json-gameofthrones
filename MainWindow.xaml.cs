using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace JSON_P_GameOfThronesQuote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Quote> _Quotes = new List<Quote>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void genQuoteBTN_Click(object sender, RoutedEventArgs e)
        {
            txtBoxQuote.Clear();

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://api.gameofthronesquotes.xyz/v1/random").Result;

                Quote newQuote = JsonConvert.DeserializeObject<Quote>(json);

                txtBoxQuote.Text = newQuote.ToString();
                listBoxData.Items.Add(newQuote);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jsonOut = JsonConvert.SerializeObject(listBoxData.Items);

            File.WriteAllText($"C:\\Users\\joshu\\Downloads\\Games_Export.json", jsonOut);

            MessageBox.Show("Successfully saved export to downloads.");
        }
    }
}
