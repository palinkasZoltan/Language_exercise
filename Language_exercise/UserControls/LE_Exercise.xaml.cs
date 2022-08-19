// <copyright file="LE_Exercise.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using Language_exercise.BL;
    using Language_exercise.BL.Model;

    /// <summary>
    /// Interaction logic for LE_Exercise.xaml.
    /// </summary>
    public partial class LE_Exercise : UserControl
    {
        private Dictionary<string, string> wordsToExercise = new Dictionary<string, string>();

        private ExerciseSettings settings;

        private Statistic statistic;

        private string wordInOriginalLang = "TEST";

        private int indexOfWord = 0;

        private string expectedResult = string.Empty;

        private DictionaryLogic dictionaryLogic;

        private StatisticsLogic statisticsLogic;

        /// <summary>
        /// Gets or sets the actual word which the user needs to translate.
        /// </summary>
        public string WordInOriginalLang
        {
            get
            {
                return wordInOriginalLang;
            }

            set
            {
                wordInOriginalLang = value;
            }
        }

        public LE_Exercise(ExerciseSettings sessionSettings, Statistic stats)
        {
            InitializeComponent();
            originalLang.DataContext = this;
            dictionaryLogic = new DictionaryLogic();
            statisticsLogic = new StatisticsLogic();
            settings = sessionSettings;
            statistic = stats;
            wordsToExercise = dictionaryLogic.GetWordsFromMultipleDictionariesBySettings(settings);
            wordInOriginalLang = wordsToExercise.ElementAt(indexOfWord).Value;
            expectedResult = wordsToExercise.ElementAt(indexOfWord).Key;
        }

        private void SubmitSolution(object sender, RoutedEventArgs e)
        {
            string resultWord = result.Text;
            bool isAnswerCorrect = expectedResult == resultWord;
            ChangeResultMessage(isAnswerCorrect);

            UpdateStatistics(expectedResult, isAnswerCorrect);
            result.Clear();
            FocusManager.SetFocusedElement(exerciseGrid, result);
            progressBar.Value += 100 / wordsToExercise.Count;

            indexOfWord++;
            if (indexOfWord < wordsToExercise.Count)
            {
                WordInOriginalLang = wordsToExercise.ElementAt(indexOfWord).Value;
                expectedResult = wordsToExercise.ElementAt(indexOfWord).Key;
                BindingExpression binding = originalLang.GetBindingExpression(ContentProperty);
                binding.UpdateTarget();
            }
            else
            {
                MessageBox.Show("It's over.");
                submitButton.Visibility = Visibility.Collapsed;
                resetButton.Visibility = Visibility.Visible;
            }
        }

        private void ChangeResultMessage(bool isAnswerCorrect)
        {
            if (isAnswerCorrect)
            {
                resultMessage.Content = "Good job!";
                resultMessage.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                resultMessage.Content = "Too bad!";
                resultMessage.Background = System.Windows.Media.Brushes.Red;
            }
        }

        private void ExerciseKeyControl(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (submitButton.IsVisible)
                {
                    SubmitSolution(sender, e);
                }
                else
                {
                    InitiateExercise(sender, e);
                }
            }
        }

        private void InitiateExercise(object sender, RoutedEventArgs e)
        {
            indexOfWord = 0;
            wordsToExercise = dictionaryLogic.GetWordsFromMultipleDictionariesBySettings(settings);
            wordInOriginalLang = wordsToExercise.ElementAt(indexOfWord).Value;
            expectedResult = wordsToExercise.ElementAt(indexOfWord).Key;
            progressBar.Value = 0;

            statisticsLogic.OverwriteStatistics(statistic);

            BindingExpression binding = originalLang.GetBindingExpression(ContentProperty);
            binding.UpdateTarget();

            resetButton.Visibility = Visibility.Collapsed;
            submitButton.Visibility = Visibility.Visible;
        }

        private void UpdateStatistics(string wordToUpdate, bool isCorrectAnswer)
        {
            WordSuccessRate currentWord = statistic.EveryWord.Find(word => word.WordPair == wordToUpdate);

            if (isCorrectAnswer)
            {
                currentWord.NumberOfCorrectAnswers++;
            }

            currentWord.NumberOfAllAnswers++;
        }
    }
}
