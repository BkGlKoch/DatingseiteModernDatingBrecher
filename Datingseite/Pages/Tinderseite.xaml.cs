﻿using System;
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
    /// Interaktionslogik für Tinderseite.xaml
    /// </summary>
    public partial class Tinderseite : Page
    {

    

        public Tinderseite()
        {
          
            InitializeComponent();

            TinderMethods.getNewTinder();

            updateData();

        }

        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A)
            {
                TinderMethods.getNewTinder();
                updateData();

            }
            else if(e.Key == Key.D)
            {
                TinderMethods.getNewTinder();
                updateData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hauptmenu hauptmenu = new Hauptmenu();
            NavigationService.Navigate(hauptmenu);
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {

            TinderMethods.getNewTinder();
            updateData();

        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {

            TinderMethods.getNewTinder();
            updateData();
        }


        private void updateData()
        {

            BitmapImage bitmap = GlobaleVariabeln.loadProfilBild(TinderMethods.tinderUserName);
            profilbildbox.Source = bitmap;

            textboxName.Text = TinderMethods.tinderFullName;
            textboxAge.Text = TinderMethods.tinderBirthday;
            textboxGender.Text = TinderMethods.tinderGender;
            textboxDescription.Text = TinderMethods.tinderDescription;
        }

        
    }
}
