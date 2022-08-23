// <copyright file="ViewModelBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System;
    using System.ComponentModel;
    using Microsoft.Toolkit.Mvvm.ComponentModel;

    /// <summary>
    /// Contains everything which will definitely be needed by any ViewModel.
    /// </summary>
    public abstract class ViewModelBase : ObservableRecipient, INotifyPropertyChanged, IDisposable
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc/>
        public virtual void Dispose() { }

        /// <summary>
        /// Invokes the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property which has been changed.</param>
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
