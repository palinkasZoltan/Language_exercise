// <copyright file="Statistic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL.Model
{
    /// <summary>
    /// Contains everything which is needed to visualize the statistics of the previous exercises.
    /// </summary>
    public class Statistic
    {
        private List<WordSuccessRate> everyWord;

        /// <summary>
        /// Gets or sets the words which were answered correctly with the highest percentage.
        /// </summary>
        public WordSuccessRate[] MostSuccessfulWords { get; set; }

        /// <summary>
        /// Gets por sets the words which were answered correctly with the lowest percentage.
        /// </summary>
        public WordSuccessRate[] LeastSuccessfulWords { get; set; }

        /// <summary>
        /// Gets or sets every word currently stored in the dictionary with it's statistical data.
        /// </summary>
        public List<WordSuccessRate> EveryWord
        {
            get
            {
                return this.everyWord;
            }

            set
            {
                this.everyWord = value;

                this.MostSuccessfulWords = this.everyWord.OrderByDescending(wordStat => wordStat.CorrectAnswerPercentage).Select(wordStat => wordStat).Take(5).ToArray();
                this.LeastSuccessfulWords = this.everyWord.OrderBy(wordStat => wordStat.CorrectAnswerPercentage).Select(wordStat => wordStat).Take(5).ToArray();
            }
        }

        public Statistic(WordSuccessRate[] mostSuccessfulWords, WordSuccessRate[] leastSuccessfulWords, List<WordSuccessRate> everyWord)
        {
            this.MostSuccessfulWords = mostSuccessfulWords;
            this.LeastSuccessfulWords = leastSuccessfulWords;
            this.EveryWord = everyWord;
        }
    }
}
