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
        string apiUrl = "https://api.gameofthronesquotes.xyz/v1/characters";
        string apiUrl2 = "https://thronesapi.com/api/v2/Characters/";
        public QuizWindow(string buttonClicked)
        {
            InitializeComponent();
            _buttonClicked = buttonClicked;
            if (_buttonClicked == "Easy" || _buttonClicked == "Intermediate" || _buttonClicked == "Hard") // Check of de knop is ingedrukt
            {
                GetQuote();
                // Roep de methode op om de afbeeldingen op te halen
            }
        }
        public async void GetQuote()
        {
            // Haal de lijst met personages en hun quotes op
            List<Character> characters = await GetCharactersWithQuotes();
            // Controleer of er personages zijn opgehaald
            if (characters != null && characters.Any())
            {
                // Kies een willekeurig personage uit de lijst
                Random random = new Random();
                Character randomCharacter = characters[random.Next(characters.Count)];
                // Kies een willekeurige quote uit de quotes van het gekozen personage
                string randomQuote = randomCharacter.quotes[random.Next(randomCharacter.quotes.Count)];
                // Toon de gekozen quote in de txtQuote
                txtQuote.Text = "Quote: " + randomQuote;
                correctCharacterName = randomCharacter.name;
                if(correctCharacterName == "\"Eddard \\\"Ned\\\" Stark\"")
                {
                    correctCharacterName = "\"Ned Stark\"";
                }
               
                GetCharacters(correctCharacterName);
            }
            else
            {
                // Geen personages gevonden
                txtQuote.Text = "Er zijn geen personages gevonden.";
            }
        }
        private async void GetCharacters(string correctChar)
        {
            // Haal de lijst met personages en hun quotes op
            List<Character> characters = await GetCharactersWithQuotes();
            if (characters != null && characters.Any())
            {
                
                Random random = new Random();
                // Kies willekeurig vier personages
                List<Character> selectedCharacters = new List<Character>();

                //Zorgen dat correcte character zeker in de lijst zit 
                selectedCharacters.Add(characters.Find(c => c.name == correctChar));

                for (int i = 0; i < 3; i++)
                {
                    Character randomCharacter = characters[random.Next(characters.Count)];
                    selectedCharacters.Add(randomCharacter);
                }
                // Haal de volledige namen van de personages op
                List<string> fullNames = await GetCharacterFullNames(selectedCharacters);
                // Maak een lijst met CharacterImage-objecten
                List<CharacterImage> characterImages = new List<CharacterImage>();
                foreach (var fullName in fullNames)
                {
                    string imageUrl = await GetCharacterImageUrl(fullName);
                    characterImages.Add(new CharacterImage { fullName = fullName, imageUrl = imageUrl });
                }

                // Wijs de afbeeldingen toe aan de Image-elementen
                imgChar1.Source = new BitmapImage(new Uri(characterImages[0].imageUrl));
                imgChar2.Source = new BitmapImage(new Uri(characterImages[1].imageUrl));
                imgChar3.Source = new BitmapImage(new Uri(characterImages[2].imageUrl));
                imgChar4.Source = new BitmapImage(new Uri(characterImages[3].imageUrl));


            }
        }

        private async Task<List<string>> GetCharacterFullNames(List<Character> characters)
        {
            List<string> fullNames = new List<string>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl2);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Deserialiseer de JSON-response naar een lijst van characters
                    List<CharacterImage> characterImages = JsonSerializer.Deserialize<List<CharacterImage>>(responseBody);

                    // Zoek de volledige naam voor elk personage uit de lijst van characters
                    while (fullNames.Count < 4)
                    {
                        foreach (var character in characters)
                        {
                            CharacterImage characterImage = characterImages.FirstOrDefault(c => c.fullName == character.name);
                            if (characterImage != null)
                            {
                                fullNames.Add(characterImage.fullName);
                            }
                        }
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
            return fullNames;
        }


        private async Task<string> GetCharacterImageUrl(string characterName)
        {
            string imageUrl = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl2);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Deserialiseer de JSON-response naar een lijst van characters
                    List<CharacterImage> characterImages = JsonSerializer.Deserialize<List<CharacterImage>>(responseBody);
                    // Zoek de juiste afbeelding op basis van de naam van het personage
                    var characterImage = characterImages.FirstOrDefault(c => c.fullName == characterName);
                    if (characterImage != null)
                    {
                        imageUrl = characterImage.imageUrl;
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
            return imageUrl;
        }
        public async Task<List<Character>> GetCharactersWithQuotes()
        {
            List<Character> characters = new List<Character>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Deserialiseer de JSON-response naar een lijst van characters
                    characters = JsonSerializer.Deserialize<List<Character>>(responseBody);
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
            return characters;
        }
    }
}