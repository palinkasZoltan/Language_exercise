// <copyright file="NavigateStatisticsCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using Language_exercise.BL;
    using Language_exercise.Stores;

    internal class NavigateStatisticsCommand : NavigationCommandBase
    {
        private IStatisticsLogic logic;

        public NavigateStatisticsCommand(NavigationStore navigationStore, IStatisticsLogic logic)
            : base(navigationStore)
        {
            this.logic = logic;
        }

        public override void Execute(object? parameter)
        {
            navStore.CurrentViewModel = ViewModelLocator.StatisticsViewModel;
            navStore.CurrentFrameViewModel = ViewModelLocator.StatisticsFrameViewModel;
            logic.GetWordStatictics();
        }
    }
}
