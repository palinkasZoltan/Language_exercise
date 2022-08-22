// <copyright file="NavigateHomeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    internal class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore navStore;

        public NavigateHomeCommand(NavigationStore navigationStore)
        {
            navStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.HomeViewModel;
        }
    }
}
