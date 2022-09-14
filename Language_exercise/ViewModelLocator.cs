// <copyright file="ViewModelLocator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise
{
    using Language_exercise.ViewModels;
    using Language_exercise.ViewModels.Exercises;
    using Language_exercise.ViewModels.Frames;
    using Language_exercise.ViewModels.Others;

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

        public static ViewModelBase ReadyMadeVocabularyExerciseViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(ReadyMadeVocabularyExerciseViewModel)) as ReadyMadeVocabularyExerciseViewModel;
            }
        }

        public static ViewModelBase CustomMadeVocabularyExerciseViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(CustomMadeVocabularyExerciseViewModel)) as CustomMadeVocabularyExerciseViewModel;
            }
        }

        public static ViewModelBase PhrasesExerciseViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(PhrasesExerciseViewModel)) as PhrasesExerciseViewModel;
            }
        }

        public static ViewModelBase MainFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(MainFrameViewModel)) as MainFrameViewModel;
            }
        }

        public static ViewModelBase ExerciseFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(ExerciseFrameViewModel)) as ExerciseFrameViewModel;
            }
        }

        public static HomeFrameViewModel HomeFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(HomeFrameViewModel)) as HomeFrameViewModel;
            }
        }

        public static StatisticsFrameViewModel StatisticsFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(StatisticsFrameViewModel)) as StatisticsFrameViewModel;
            }
        }

        public static SettingsFrameViewModel SettingsFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(SettingsFrameViewModel)) as SettingsFrameViewModel;
            }
        }

        public static OtherFrameViewModel OtherFrameViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(OtherFrameViewModel)) as OtherFrameViewModel;
            }
        }

        public static CreateCustomDictionaryViewModel CreateCustomDictionaryViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(CreateCustomDictionaryViewModel)) as CreateCustomDictionaryViewModel;
            }
        }

        public static ExtendDictionaryViewModel ExtendDictionaryViewModel
        {
            get
            {
                return App.ServiceProvider.GetService(typeof(ExtendDictionaryViewModel)) as ExtendDictionaryViewModel;
            }
        }
    }
}
