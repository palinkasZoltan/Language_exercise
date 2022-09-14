// <copyright file="NavigateHomeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    internal class NavigateHomeCommand : NavigationCommandBase
    {
        public NavigateHomeCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.HomeViewModel;
            navStore.CurrentFrameViewModel = ViewModelLocator.HomeFrameViewModel;
        }
    }
}
