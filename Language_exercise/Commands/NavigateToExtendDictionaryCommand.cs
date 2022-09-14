// <copyright file="NavigateToExtendDictionaryCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    internal class NavigateToExtendDictionaryCommand : NavigationCommandBase
    {
        public NavigateToExtendDictionaryCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            this.navStore.CurrentViewModel = ViewModelLocator.ExtendDictionaryViewModel;
        }
    }
}
