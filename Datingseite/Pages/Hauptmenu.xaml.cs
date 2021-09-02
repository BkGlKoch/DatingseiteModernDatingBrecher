using System;
using System.Collections.Generic;
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

namespace Datingseite.Pages
{
    /// <summary>
    /// Interaktionslogik für Hauptmenu.xaml
    /// </summary>
    public partial class Hauptmenu : Page
    {
        public Hauptmenu()
        {
            InitializeComponent();
            textBlockLoggeInAs.Text = "Eingeloggt als: "+ Environment.NewLine + GlobaleVariabeln.loggedInUser;

            
        }
    }
}
