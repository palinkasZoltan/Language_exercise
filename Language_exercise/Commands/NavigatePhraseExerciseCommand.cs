// <copyright file="NavigatePhraseExerciseCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    public class NavigatePhraseExerciseCommand : NavigationCommandBase
    {
        public NavigatePhraseExerciseCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.PhrasesExerciseViewModel;
        }
    }
}
