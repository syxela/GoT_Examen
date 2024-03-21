using GoT_Examen.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GoT_Examen.Windows
{
    public partial class QuizWindow : Window
    {
        private string _buttonClicked;
        private string correctCharacterName; // Variabele om de naam van het correcte karakter bij te houden
        string apiUrl = "https://api.gameofthronesquotes.xyz/v1/random";
        string apiUrl2 = "https://thronesapi.com/api/v2/Characters/";

        public QuizWindow(string buttonClicked)
        {
            InitializeComponent();
            _buttonClicked = buttonClicked;

            if (_buttonClicked == "Easy" || _buttonClicked == "Intermediate" || _buttonClicked == "Hard") // Check of de knop is ingedrukt
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
                    string quote = jsonResponse.RootElement.GetProperty("sentence").GetString();
                    correctCharacterName = jsonResponse.RootElement.GetProperty("character").GetProperty("name").GetString(); // Sla de naam van het correcte karakter op

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
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl2);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialiseer de JSON-response naar een lijst van karakters voor de tweede API
                    List<CharacterImage> characters = JsonSerializer.Deserialize<List<CharacterImage>>(responseBody);

                    // Zoek het juiste karakter op basis van correctCharacterName
                    CharacterImage correctCharacter = characters.FirstOrDefault(c => c.FullName == correctCharacterName);

                   if (correctCharacter != null)
                    {
                        // Stel de afbeelding in voor een van de Image controls in de XAML
                        imgChar1.Source = new BitmapImage(new Uri(correctCharacter.ImageUrl));
                    }
                    else
                    {
                        // Het juiste karakter niet gevonden
                        MessageBox.Show("Het juiste karakter niet gevonden.");
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
            }
        }


    }
}
