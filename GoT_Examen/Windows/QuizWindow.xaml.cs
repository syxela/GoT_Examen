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

namespace GoT_Examen.Windows
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
            private string _buttonClicked;

            public QuizWindow(string buttonClicked)
            {
                InitializeComponent();
                _buttonClicked = buttonClicked;

              
                if (_buttonClicked == "Easy")
                {

                }
                else if (_buttonClicked == "Intermediate")
                {

                }
                else if (_buttonClicked == "Hard")
                {

                }
            }
        }


    }
