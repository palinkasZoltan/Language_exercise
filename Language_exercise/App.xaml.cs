// <copyright file="App.xaml.cs" company="PlaceholderCompany">
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
    using Language_exercise.ViewModels.Exercises;
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
            services.AddScoped<IExerciseLogic, ExerciseLogic>();
            services.AddScoped<ISettingsLogic, SettingsLogic>();
            services.AddScoped<IDictionaryLogic, DictionaryLogic>();
            services.AddScoped<IStatisticsLogic, StatisticsLogic>();
            services.AddScoped<IExerciseLogic, ExerciseLogic>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            services.AddSingleton<ExerciseViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<StatisticsViewModel>();
            services.AddSingleton<OtherViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CustomMadeVocabularyExerciseViewModel>();
            services.AddSingleton<ReadyMadeVocabularyExerciseViewModel>();
            services.AddSingleton<PhrasesExerciseViewModel>();
            services.AddSingleton<ExerciseFrameViewModel>();
            services.AddSingleton<MainFrameViewModel>();
            services.AddSingleton<NavigationStore>();
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
