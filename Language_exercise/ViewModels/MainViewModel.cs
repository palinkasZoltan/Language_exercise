// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System.Windows.Input;
    using Language_exercise.BL;
    using Language_exercise.Commands;
    using Language_exercise.Stores;

    /// <summary>
    /// ViewModel class for the Main window.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //public int test { get; set; } = 1;

        private NavigationStore navigationStore;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public ICommand ChangeToHomeCommand { get; set; }

        public ICommand ChangeToExerciseCommand { get; set; }

        public ICommand ChangeToStatisticsCommand { get; set; }

        public ICommand ChangeToSettingsCommand { get; set; }

        public ICommand ChangeToOtherCommand { get; set; }

        public MainViewModel(NavigationStore navStore, IStatisticsLogic statLogic)
        {
            navigationStore = navStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            ChangeToHomeCommand = new NavigateHomeCommand(navigationStore);
            ChangeToExerciseCommand = new NavigateExerciseCommand(navigationStore);
            ChangeToOtherCommand = new NavigateOtherCommand(navigationStore);
            ChangeToSettingsCommand = new NavigateSettingsCommand(navigationStore);
            ChangeToStatisticsCommand = new NavigateStatisticsCommand(navigationStore, statLogic);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
