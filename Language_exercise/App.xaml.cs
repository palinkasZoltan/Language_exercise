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
    using Language_exercise.ViewModels.Frames;
    using Language_exercise.ViewModels.Others;
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
            AddExerciseViewModels(services);
            services.AddSingleton<ExerciseViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<StatisticsViewModel>();
            services.AddSingleton<OtherViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<CreateCustomDictionaryViewModel>();
            services.AddSingleton<ExtendDictionaryViewModel>();
            services.AddSingleton<OtherFrameViewModel>();
            services.AddSingleton<SettingsFrameViewModel>();
            services.AddSingleton<StatisticsFrameViewModel>();
            services.AddSingleton<HomeFrameViewModel>();
            services.AddSingleton<ExerciseFrameViewModel>();
            services.AddSingleton<MainFrameViewModel>();
            services.AddSingleton<MainViewModel>();
        }

        private void AddExerciseViewModels(ServiceCollection services)
        {
            services.AddSingleton<CustomMadeVocabularyExerciseViewModel>();
            services.AddSingleton<ReadyMadeVocabularyExerciseViewModel>();
            services.AddSingleton<PhrasesExerciseViewModel>();
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
