// <copyright file="SettingsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Windows.Input;
using Language_exercise.BL;
using Language_exercise.BL.BL.Model;

namespace Language_exercise.ViewModels
{
    /// <summary>
    /// ViewModel for Settings UserControl.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private ISettingsLogic _settingsLogic;

        public ExerciseSettings settings { get; private set; }

        public SettingsViewModel(ISettingsLogic setLogic)
        {
            _settingsLogic = setLogic;
            this.settings = ExerciseSettings.Instance;
        }

        public ICommand SaveSettingsCommand { get; set; }

        public int NumberOfWords
        {
            get
            {
                return settings.NumberOfWords;
            }

            set
            {
                settings.NumberOfWords = value;
                OnPropertyChanged(nameof(NumberOfWords));
            }
        }

        public bool IsAllIncluded
        {
            get
            {
                return settings.IsAllIncluded;
            }

            set
            {
                settings.IsAllIncluded = value;
                OnPropertyChanged(nameof(IsAllIncluded));
            }
        }

        public bool IsAnimalsIncluded
        {
            get
            {
                return settings.IsAnimalsIncluded;
            }

            set
            {
                settings.IsAnimalsIncluded = value;
                OnPropertyChanged(nameof(IsAnimalsIncluded));
            }
        }

        public bool IsFamilyIncluded
        {
            get
            {
                return settings.IsFamilyIncluded;
            }

            set
            {
                settings.IsFamilyIncluded = value;
                OnPropertyChanged(nameof(IsFamilyIncluded));
            }
        }

        public bool IsSportIncluded
        {
            get
            {
                return settings.IsSportIncluded;
            }

            set
            {
                settings.IsSportIncluded = value;
                OnPropertyChanged(nameof(IsSportIncluded));
            }
        }

        public bool IsVehiclesIncluded
        {
            get
            {
                return settings.IsVehiclesIncluded;
            }

            set
            {
                settings.IsVehiclesIncluded = value;
                OnPropertyChanged(nameof(IsVehiclesIncluded));
            }
        }

        public bool IsArtsIncluded
        {
            get
            {
                return settings.IsArtsIncluded;
            }

            set
            {
                settings.IsArtsIncluded = value;
                OnPropertyChanged(nameof(IsArtsIncluded));
            }
        }

        public bool IsHomeIncluded
        {
            get
            {
                return settings.IsHomeIncluded;
            }

            set
            {
                settings.IsHomeIncluded = value;
                OnPropertyChanged(nameof(IsHomeIncluded));
            }
        }

        public bool IsOthersIncluded
        {
            get
            {
                return settings.IsOthersIncluded;
            }

            set
            {
                settings.IsOthersIncluded = value;
                OnPropertyChanged(nameof(IsOthersIncluded));
            }
        }

        public bool IsLifeIncluded
        {
            get
            {
                return settings.IsLifeIncluded;
            }

            set
            {
                settings.IsLifeIncluded = value;
                OnPropertyChanged(nameof(IsLifeIncluded));
            }
        }

        public bool IsGoingOutIncluded
        {
            get
            {
                return settings.IsGoingOutIncluded;
            }

            set
            {
                settings.IsGoingOutIncluded = value;
                OnPropertyChanged(nameof(IsGoingOutIncluded));
            }
        }

        public bool IsWorkIncluded
        {
            get
            {
                return settings.IsWorkIncluded;
            }

            set
            {
                settings.IsWorkIncluded = value;
                OnPropertyChanged(nameof(IsWorkIncluded));
            }
        }

        private void SaveSettings()
        {
            _settingsLogic.SaveSettings();
        }
    }
}
