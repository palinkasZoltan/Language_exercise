// <copyright file="LE_Homepage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for LE_Homepage.xaml
    /// </summary>
    public partial class LE_Homepage : UserControl
    {
        public LE_Homepage()
        {
            InitializeComponent();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
