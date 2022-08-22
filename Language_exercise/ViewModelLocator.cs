// <copyright file="ViewModelLocator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise
{
    using Language_exercise.ViewModels;

    /// <summary>
    /// Provides a way to get services from the serviceProvider.
    /// </summary>
    public class ViewModelLocator
    {
        public static ViewModelBase MainViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(MainViewModel)) as MainViewModel;
            }
        }

        public static ViewModelBase ExerciseViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(ExerciseViewModel)) as ExerciseViewModel;
            }
        }

        public static ViewModelBase HomeViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(HomeViewModel)) as HomeViewModel;
            }
        }

        public static ViewModelBase SettingsViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(SettingsViewModel)) as SettingsViewModel;
            }
        }

        public static ViewModelBase StatisticsViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(StatisticsViewModel)) as StatisticsViewModel;
            }
        }

        public static ViewModelBase OtherViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(OtherViewModel)) as OtherViewModel;
            }
        }
    }
}
