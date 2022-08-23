// <copyright file="StatisticsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System.Collections.Generic;
    using Language_exercise.BL.Model;

    /// <summary>
    /// ViewModel class for Statistics UserControl.
    /// </summary>
    public class StatisticsViewModel : ViewModelBase
    {
        private Statistic statistic;

        public StatisticsViewModel()
        {
            statistic = Statistic.Instance;
        }

        public WordSuccessRate[] MostSuccessfulWords
        {
            get { return statistic.MostSuccessfulWords; }
            set { statistic.MostSuccessfulWords = value; }
        }

        public WordSuccessRate[] LeastSuccessfulWords
        {
            get { return statistic.LeastSuccessfulWords; }
            set { statistic.LeastSuccessfulWords = value; }
        }

        public List<WordSuccessRate> EveryWord
        {
            get { return statistic.EveryWord; }
            set { statistic.EveryWord = value; }
        }
    }
}
