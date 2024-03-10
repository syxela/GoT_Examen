using GoT_Examen.Windows;
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
using System.Windows.Shapes;

namespace GoT_Examen
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            txtChoice.Text = "Below you find the different difficulty levels of this quiz.\n\n"+
                "Please click on a button to enter the quiz.";
            
        }

        private void btnEasy_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow EasyWindow = new QuizWindow();
            this.Close();
            EasyWindow.Show();
        }
    }

}
