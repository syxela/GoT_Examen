using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace GoT_Examen.Windows
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private string _buttonClicked;
        string apiUrl = "https://api.gameofthronesquotes.xyz/v1/random";
        string apiUrl2 = "";
        public QuizWindow(string buttonClicked)
        {
            InitializeComponent();
            _buttonClicked = buttonClicked;


            if (_buttonClicked == "Easy")
            {
                GetQuote(); 
            }
            else if (_buttonClicked == "Intermediate")
            {
                GetQuote();
            }
            else if (_buttonClicked == "Hard")
            {
                GetQuote();
            }
        }

        private async void GetQuote()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                JsonDocument jsonResponse = JsonDocument.Parse(responseBody);

                string Quote = jsonResponse.RootElement.GetProperty("sentence").GetString();
                //string Author = jsonResponse.RootElement.GetProperty("name").GetString();

                txtQuote.Text = Quote;

            }

        }

        private async void GetCharacters()
        {

        }
    }
}


   
