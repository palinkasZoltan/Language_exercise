// <copyright file="CommandBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using System;
    using System.Windows.Input;
    using Language_exercise.Stores;

    public abstract class NavigationCommandBase : ICommand
    {

        protected NavigationStore navStore;

        public NavigationCommandBase(NavigationStore navStore)
        {
            this.navStore = navStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    }
}
