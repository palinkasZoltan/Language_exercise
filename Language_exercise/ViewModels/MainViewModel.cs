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

        public ViewModelBase CurrentFrameViewModel => navigationStore.CurrentFrameViewModel;

        public MainViewModel(NavigationStore navStore)
        {
            navigationStore = navStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            navigationStore.CurrentViewModelChanged += OnCurrentFrameViewModelChanged;

            HomeCommand = new NavigateHomeCommand(navigationStore);
            HomeCommand.Execute(null);
        }

        public ICommand HomeCommand { get; set; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentFrameViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentFrameViewModel));
        }
    }
}
