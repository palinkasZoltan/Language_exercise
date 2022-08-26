// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise
{
    using System.Windows;
    using Language_exercise.BL;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISettingsLogic settingsLogic;
        private IStatisticsLogic statisticsLogic;

        public MainWindow(IStatisticsLogic statLogic, ISettingsLogic setLogic)
        {
            this.InitializeComponent();
            statisticsLogic = statLogic;
            settingsLogic = setLogic;
            this.settingsLogic.GetExerciseSettings();
            this.statisticsLogic.GetWordStatictics();
        }
    }
}
