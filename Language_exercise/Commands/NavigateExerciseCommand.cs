// <copyright file="NavigateExerciseCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    internal class NavigateExerciseCommand : NavigationCommandBase
    {
        public NavigateExerciseCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.ReadyMadeVocabularyExerciseViewModel;
            navStore.CurrentFrameViewModel = ViewModelLocator.ExerciseFrameViewModel;

        }
    }
}
