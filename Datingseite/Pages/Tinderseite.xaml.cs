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
            
           
        }

        private void TheGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            theGrid.Focus();
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            
        }


    }
}