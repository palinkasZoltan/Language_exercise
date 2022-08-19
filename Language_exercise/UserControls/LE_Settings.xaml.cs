// <copyright file="LE_Settings.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using Language_exercise.BL;

    /// <summary>
    /// Interaction logic for LE_Settings.xaml.
    /// </summary>
    public partial class LE_Settings : UserControl
    {
        private ExerciseSettings settings = new ExerciseSettings();

        private SettingsLogic sl = new SettingsLogic();

        public LE_Settings(ExerciseSettings sessionsSettings)
        {
            this.InitializeComponent();
            this.settings = sessionsSettings;
            this.settingsGrid.DataContext = this.settings;
        }

        private void SaveSettingsClick(object sender, RoutedEventArgs e)
        {
            this.sl.SaveSettings(this.settings);
        }
    }
}
