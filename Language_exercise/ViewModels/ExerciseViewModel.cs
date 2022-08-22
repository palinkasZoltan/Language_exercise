// <copyright file="ExerciseViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Media;
    using GalaSoft.MvvmLight.Command;
    using Language_exercise.BL;
    using Language_exercise.BL.BL.Model;

    /// <summary>
    /// ViewModel class for LE_Exercise view.
    /// </summary>
    public class ExerciseViewModel : ViewModelBase
    {
        private IStatisticsLogic statisticsLogic;

        private Exercise currentExercise;

        private ExerciseLogic exLogic;

        private int indexOfWord = 0;

        private string expectedResult = string.Empty;

        private string wordInOriginalLang;
        private int progressbarValue;
        private string resultText;
        private string resultMessage;
        private bool submitIsVisible;
        private bool resetIsVisible;
        private Brush resultBackground;

        public ExerciseViewModel(ExerciseLogic exLogic, IStatisticsLogic statisticsLogic)
        {
            this.exLogic = exLogic;
            this.statisticsLogic = statisticsLogic;
            submitIsVisible = true;

            SubmitCommand = new RelayCommand(() => SubmitSolution());
            InitiateNewCommand = new RelayCommand(() => InitiateExercise());
            EnterKeyCommand = new RelayCommand(() => EnterKeyPressed());

            currentExercise = this.exLogic.ConstructNewExercise();
            wordInOriginalLang = currentExercise.WordsToExercise.ElementAt(indexOfWord).Value;
            expectedResult = currentExercise.WordsToExercise.ElementAt(indexOfWord).Key;
        }

        public ICommand SubmitCommand { get; private set; }

        public ICommand InitiateNewCommand { get; private set; }

        public ICommand EnterKeyCommand { get; private set; }

        #region Binding Properties

        public string DonePerAll
        {
            get
            {
                return $"{indexOfWord + 1}/{currentExercise.WordsToExercise.Count}";
            }

            set
            {
            }
        }

        public int ProgressbarValue
        {
            get
            {
                return progressbarValue;
            }

            set
            {
                progressbarValue = value;
                OnPropertyChanged(nameof(ProgressbarValue));
            }
        }

        public string ResultText
        {
            get
            {
                return resultText;
            }

            set
            {
                resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public Brush ResultBackground
        {
            get
            {
                return resultBackground;
            }

            set
            {
                resultBackground = value;
                OnPropertyChanged(nameof(ResultBackground));
            }
        }        

        public string ResultMessage
        {
            get
            {
                return resultMessage;
            }

            set
            {
                resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        public bool SubmitIsVisible
        {
            get
            {
                return submitIsVisible;
            }

            set
            {
                submitIsVisible = value;
                OnPropertyChanged(nameof(SubmitIsVisible));
            }
        }

        public bool ResetIsVisible
        {
            get
            {
                return resetIsVisible;
            }

            set
            {
                resetIsVisible = value;
                OnPropertyChanged(nameof(ResetIsVisible));
            }
        }


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
                OnPropertyChanged(nameof(WordInOriginalLang));
            }
        }

        #endregion

        public Dictionary<string, string> WordsToExercise
        {
            get
            {
                return currentExercise.WordsToExercise;
            }
        }

        private void SubmitSolution()
        {
            string resultWord = ResultText;
            bool isAnswerCorrect = expectedResult == resultWord;

            OnPropertyChanged(nameof(DonePerAll));
            ChangeResultMessage(isAnswerCorrect);
            statisticsLogic.UpdateStatistics(expectedResult, isAnswerCorrect);

            ResultText = string.Empty;
            ProgressbarValue += 100 / WordsToExercise.Count;
            //FocusManager.SetFocusedElement(exerciseGrid, result);

            if (indexOfWord < WordsToExercise.Count)
            {
                SetNextWordAsCurrent();
            }
            else
            {
                InvertSubmitAndResetVisibility();
            }
        }

        private void ChangeResultMessage(bool isAnswerCorrect)
        {
            if (isAnswerCorrect)
            {
                ResultMessage = "Good job!";
                ResultBackground = Brushes.LightGreen;
            }
            else
            {
                ResultMessage = "Too bad!";
                ResultBackground = Brushes.Red;
            }
        }

        private void EnterKeyPressed()
        {
            if (SubmitIsVisible)
            {
                SubmitSolution();
            }
            else
            {
                InitiateExercise();
            }
        }

        private void InitiateExercise()
        {
            indexOfWord = 0;
            ProgressbarValue = 0;

            OnPropertyChanged(nameof(DonePerAll));
            currentExercise = exLogic.ConstructNewExercise();
            statisticsLogic.OverwriteStatistics();

            SetNextWordAsCurrent();
            InvertSubmitAndResetVisibility();
        }

        private void InvertSubmitAndResetVisibility()
        {
            ResetIsVisible = !ResetIsVisible;
            SubmitIsVisible = !SubmitIsVisible;
        }

        private void SetNextWordAsCurrent()
        {
            WordInOriginalLang = currentExercise.WordsToExercise.ElementAt(indexOfWord).Value;
            expectedResult = currentExercise.WordsToExercise.ElementAt(indexOfWord).Key;
        }
    }
}
