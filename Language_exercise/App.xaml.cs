// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise
{
    using System;
    using System.Windows;
    using Language_exercise.BL;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<DataConnection>();
            services.AddSingleton<NavigationStore>();
            AddRepos(services);
            AddLogic(services);
            AddViewModels(services);
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        private void AddViewModels(ServiceCollection services)
        {
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
            services.AddSingleton<MainViewModel>();
        }

        private void AddRepos(ServiceCollection services)
        {
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
        }

        private void AddLogic(ServiceCollection services)
        {
            services.AddScoped<IExerciseLogic, ExerciseLogic>();
            services.AddScoped<ISettingsLogic, SettingsLogic>();
            services.AddScoped<IDictionaryLogic, DictionaryLogic>();
            services.AddScoped<IStatisticsLogic, StatisticsLogic>();
            services.AddScoped<IExerciseLogic, ExerciseLogic>();
        }
    }
}
