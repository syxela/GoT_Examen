using GoT_Examen.Klassen; // Voeg de namespace van de klassen toe
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

namespace GoT_Examen.Windows
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private string _buttonClicked;
        private string correctCharacterName; // Variabele om de naam van het correcte karakter bij te houden
        string apiUrl = "https://api.gameofthronesquotes.xyz/v1/random";
<<<<<<< Updated upstream
        string apiUrl2 = "https://thronesapi.com/api/v2/Characters"; // Tweede API-URL toegevoegd

=======
        string apiUrl2 = "https://thronesapi.com/api/v2/Characters/";
>>>>>>> Stashed changes
        public QuizWindow(string buttonClicked)
        {
            InitializeComponent();
            _buttonClicked = buttonClicked;

<<<<<<< Updated upstream
            if (_buttonClicked == "Easy" || _buttonClicked == "Intermediate" || _buttonClicked == "Hard") // Check of de knop is ingedrukt
=======

            if (_buttonClicked == "Easy")
            {
                GetQuote();
            }
            else if (_buttonClicked == "Intermediate")
            {
                GetQuote();
            }
            else if (_buttonClicked == "Hard")
>>>>>>> Stashed changes
            {
                GetQuote();
                GetCharacters(); // Roep de methode op om de afbeeldingen op te halen
            }
        }

        public async void GetQuote()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JsonDocument jsonResponse = JsonDocument.Parse(responseBody);

<<<<<<< Updated upstream
                    string quote = jsonResponse.RootElement.GetProperty("sentence").GetString();
                    correctCharacterName = jsonResponse.RootElement.GetProperty("character").GetProperty("name").GetString(); // Sla de naam van het correcte karakter op
=======
                string Quote = jsonResponse.RootElement.GetProperty("sentence").GetString();
                string Author = jsonResponse.RootElement.GetProperty("character").GetProperty("name").GetString();
>>>>>>> Stashed changes

                    // Voeg "Quote: " toe aan de opgehaalde citaatstring
                    quote = "Quote: " + quote;

                    txtQuote.Text = quote;
                }
                catch (HttpRequestException ex)
                {
                    // Fout bij het maken van de HTTP-request
                    txtQuote.Text = $"Fout bij het maken van de HTTP-request: {ex.Message}";
                }
                catch (JsonException ex)
                {
                    // Fout bij het deserialiseren van de JSON
                    txtQuote.Text = $"Fout bij het deserialiseren van de JSON: {ex.Message}";
                }
            }
        }

        private async void GetCharacters()
        {
            using (HttpClient client = new HttpClient())
            {
<<<<<<< Updated upstream
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl2);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialiseer de JSON-response naar een lijst van karakters voor de tweede API
                    List<CharacterImage> characters = JsonSerializer.Deserialize<List<CharacterImage>>(responseBody);

                    // Haal 4 willekeurige karakters op
                    Random random = new Random();
                    List<CharacterImage> randomCharacters = characters.OrderBy(c => random.Next()).Take(4).ToList();

                    // Vul de afbeeldingen in
                    List<Image> imageControls = new List<Image> { imgChar1, imgChar2, imgChar3, imgChar4 };
                    for (int i = 0; i < 4; i++)
                    {
                        string imageUrl = randomCharacters[i].ImageUrl;
                        imageControls[i].Source = new BitmapImage(new Uri(imageUrl));
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Fout bij het maken van de HTTP-request
                    MessageBox.Show($"Fout bij het maken van de HTTP-request: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    // Fout bij het deserialiseren van de JSON
                    MessageBox.Show($"Fout bij het deserialiseren van de JSON: {ex.Message}");
                }
=======
                HttpResponseMessage response = await client.GetAsync(apiUrl2);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();



>>>>>>> Stashed changes
            }
        }


    }
}
