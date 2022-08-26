namespace Language_exercise.ViewModels
{
    using System.Windows.Input;
    using Language_exercise.BL;
    using Language_exercise.Commands;
    using Language_exercise.Stores;

    internal class MainFrameViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public ViewModelBase CurrentFrameViewModel => navigationStore.CurrentFrameViewModel;

        public ICommand ChangeToHomeCommand { get; set; }

        public ICommand ChangeToExerciseCommand { get; set; }

        public ICommand ChangeToStatisticsCommand { get; set; }

        public ICommand ChangeToSettingsCommand { get; set; }

        public ICommand ChangeToOtherCommand { get; set; }

        public MainFrameViewModel(NavigationStore navStore, IStatisticsLogic statLogic)
        {
            navigationStore = navStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            navigationStore.CurrentFrameViewModelChanged += NavigationStore_CurrentFrameViewModelChanged;
            ChangeToHomeCommand = new NavigateHomeCommand(navigationStore);
            ChangeToExerciseCommand = new NavigateExerciseCommand(navigationStore);
            ChangeToOtherCommand = new NavigateOtherCommand(navigationStore);
            ChangeToSettingsCommand = new NavigateSettingsCommand(navigationStore);
            ChangeToStatisticsCommand = new NavigateStatisticsCommand(navigationStore, statLogic);

            //ChangeToHomeCommand.Execute(null);
        }

        private void NavigationStore_CurrentFrameViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFrameViewModel));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
