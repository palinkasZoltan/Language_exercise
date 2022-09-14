// <copyright file="NavigateOtherCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.Stores;

    internal class NavigateOtherCommand : NavigationCommandBase
    {
        public NavigateOtherCommand(NavigationStore store)
            : base(store)
        {
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.ExtendDictionaryViewModel;
            navStore.CurrentFrameViewModel = ViewModelLocator.OtherFrameViewModel;
        }
    }
}
