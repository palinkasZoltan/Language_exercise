// <copyright file="LE_Settings.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using Language_exercise.BL;
    using Language_exercise.BL.BL.Model;

    /// <summary>
    /// Interaction logic for LE_Settings.xaml.
    /// </summary>
    public partial class LE_Settings : UserControl
    {
        private ExerciseSettings settings;

        private SettingsLogic sl = new SettingsLogic();

        public LE_Settings()
        {
            this.InitializeComponent();
            this.settings = ExerciseSettings.Instance;
            this.settingsGrid.DataContext = this.settings;
        }

        private void SaveSettingsClick(object sender, RoutedEventArgs e)
        {
            this.sl.SaveSettings();
        }
    }
}
