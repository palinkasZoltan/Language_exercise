// <copyright file="NavigateCustomExerciseCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    public class NavigateCustomExerciseCommand : NavigationCommandBase
    {
        public NavigateCustomExerciseCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.CustomMadeVocabularyExerciseViewModel;
        }
    }
}
