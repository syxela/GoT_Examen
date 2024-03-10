using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoT_Examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtIntro.Text = "Welcome to the Game of Thrones Quote Challenge!\n\n" +
                "Immerse yourself in the world of Westeros as you test your knowledge of the iconic quotes from the hit TV series. In this game, you'll \n\n " +
                "be presented with quotes spoken by various characters from Game of Thrones. Your task is simple: guess which character said each quote!\n\n " +
                "\n\n Choose wisely from the options provided, and see if you can match the right character\n\n" +
                " to the right words. With each correct answer, you'll earn points and climb closer to the Iron Throne of knowledge." +
                "\n\n \n\nDo you have what it takes to decipher the words of kings, queens, knights, and schemers? Step into \n\n" +
                " the Game of Thrones Quote Challenge and prove your mastery of the Seven Kingdoms!";
        }

        private void btnHomeContinue_Click(object sender, RoutedEventArgs e)
        {
            Window2 SecondWindow = new Window2();
            this.Close();    
            SecondWindow.Show();
        }
    }
}