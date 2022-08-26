// <copyright file="NavigateReadyExerciseCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using System;
    using Language_exercise.Stores;

    internal class NavigateReadyExerciseCommand : NavigationCommandBase
    {
        public NavigateReadyExerciseCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.ReadyMadeVocabularyExerciseViewModel;
        }
    }
}
