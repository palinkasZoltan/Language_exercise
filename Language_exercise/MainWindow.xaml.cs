namespace Language_exercise
{
    using System.Windows;
    using System.Windows.Controls;
    using Language_exercise.BL;
    using Language_exercise.BL.Model;
    using Language_exercise.UserControls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ExerciseSettings settings = new ExerciseSettings();

        private static Statistic statistic;

        SettingsLogic settingsLogic = new SettingsLogic();
        StatisticsLogic statisticsLogic = new StatisticsLogic();

        public void ChangeContent(UserControl uc)
        {
            this.contentGrid.Children.Clear();
            this.contentGrid.Children.Add(uc);
            uc.BringIntoView();
        }

        public MainWindow()
        {
            this.InitializeComponent();
            settings = this.settingsLogic.GetExerciseSettings();
            statistic = this.statisticsLogic.GetWordStatictics();
            LE_Homepage lE_Homepage = new LE_Homepage();
            this.ChangeContent(lE_Homepage);
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            LE_Homepage lE_Homepage = new LE_Homepage();
            this.ChangeContent(lE_Homepage);
        }

        private void Others_click(object sender, RoutedEventArgs e)
        {
            LE_Other lE_Other = new LE_Other();
            this.ChangeContent(lE_Other);
        }

        private void Exercise_click(object sender, RoutedEventArgs e)
        {
            LE_Exercise lE_Exercise = new LE_Exercise(settings, statistic);
            this.ChangeContent(lE_Exercise);
        }

        private void Statistics_click(object sender, RoutedEventArgs e)
        {
            LE_Statistics lE_Statistics = new LE_Statistics(statistic);
            this.ChangeContent(lE_Statistics);
        }

        private void Settings_click(object sender, RoutedEventArgs e)
        {
            LE_Settings lE_Settings = new LE_Settings(settings);
            this.ChangeContent(lE_Settings);
        }
    }
}
