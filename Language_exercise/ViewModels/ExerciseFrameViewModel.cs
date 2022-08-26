// <copyright file="ExerciseFrameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System.Windows.Input;
    using Language_exercise.Stores;
    using Language_exercise.Commands;

    public class ExerciseFrameViewModel : ViewModelBase
    {
        private NavigationStore store;

        public ViewModelBase CurrentViewModel => store.CurrentViewModel;

        public ExerciseFrameViewModel(NavigationStore store)
        {
            this.store = store;

            PhraseExerciseCommand = new NavigateReadyExerciseCommand(store);
        }

        public ICommand PremadeExerciseCommand { get; set; }

        public ICommand CustomExerciseCommand { get; set; }

        public ICommand PhraseExerciseCommand { get; set; }
    }
}
