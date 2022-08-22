﻿// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise
{
    using System;
    using System.Windows;
    using Language_exercise.BL;
    using Language_exercise.BL.BL.Model;
    using Language_exercise.BL.Model;
    using Language_exercise.DL;
    using Language_exercise.Stores;
    using Language_exercise.ViewModels;
    using Microsoft.Extensions.DependencyInjection;
    using Repository;
    using Repository.Interfaces;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<DataConnection>();
            services.AddSingleton<ExerciseLogic>();
            services.AddScoped<ISettingsLogic, SettingsLogic>();
            services.AddScoped<IDictionaryLogic, DictionaryLogic>();
            services.AddScoped<IStatisticsLogic, StatisticsLogic>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            services.AddSingleton<ExerciseViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<StatisticsViewModel>();
            services.AddSingleton<OtherViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<NavigationStore>();
            //services.AddSingleton<ExerciseSettings>();
            //services.AddSingleton<Statistic>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
