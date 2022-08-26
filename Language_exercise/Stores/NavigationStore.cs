// <copyright file="NavigationStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.Stores
{
    using System;
    using Language_exercise.ViewModels;

    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        private ViewModelBase _currentFrameViewModel;

        public NavigationStore()
        {
            //CurrentViewModel = ViewModelLocator.HomeViewModel;
            //CurrentFrameViewModel = ViewModelLocator.MainFrameViewModel;
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public ViewModelBase CurrentFrameViewModel
        {
            get => _currentFrameViewModel;

            set
            {
                _currentFrameViewModel = value;
                OnCurrentFrameViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        public event Action CurrentFrameViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private void OnCurrentFrameViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}