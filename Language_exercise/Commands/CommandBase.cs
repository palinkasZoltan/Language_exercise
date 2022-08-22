// <copyright file="CommandBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Commands
{
    using System;
    using System.Windows.Input;

    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    }
}
