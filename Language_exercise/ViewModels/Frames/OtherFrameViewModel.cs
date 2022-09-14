// <copyright file="OtherFrameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels.Frames
{
    using System.Windows.Input;
    using Language_exercise.Commands;
    using Language_exercise.Stores;

    public class OtherFrameViewModel : ViewModelBase
    {
        private NavigationStore store;

        public ViewModelBase CurrentViewModel => store.CurrentViewModel;

        public OtherFrameViewModel(NavigationStore store)
        {
            this.store = store;

            store.CurrentViewModelChanged += OnCurrentViewModelChanged;
            SetupCommands(store);
        }

        private void SetupCommands(NavigationStore store)
        {
            NavigateToCreateCustomCommand = new NavigateCreateCustomCommand(store);
            NavigateToExtendCommand = new NavigateToExtendDictionaryCommand(store);
        }

        public ICommand NavigateToExtendCommand;

        public ICommand NavigateToCreateCustomCommand { get; set; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
