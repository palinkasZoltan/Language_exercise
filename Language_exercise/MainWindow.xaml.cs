namespace Language_exercise
{
    using System.Windows;
    using Language_exercise.BL;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        SettingsLogic settingsLogic = new SettingsLogic();
        IStatisticsLogic statisticsLogic;

        public MainWindow(IStatisticsLogic statLogic)
        {
            this.InitializeComponent();
            statisticsLogic = statLogic;

            this.settingsLogic.GetExerciseSettings();
            this.statisticsLogic.GetWordStatictics();
        }
    }
}
