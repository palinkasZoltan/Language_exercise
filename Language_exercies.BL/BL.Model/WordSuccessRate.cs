// <copyright file="WordSuccessRate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL.Model
{
    public class WordSuccessRate
    {
        private double numberOfAllAnswers;

        private double numberOfCorrectAnswers;

        public string WordPair { get; set; }

        public double NumberOfAllAnswers
        {
            get
            {
                return this.numberOfAllAnswers;
            }

            set
            {
                this.numberOfAllAnswers = value;
                this.RecalculateAnswerPercentageWhenAnswerNumberSet();
            }
        }

        public double NumberOfCorrectAnswers
        {
            get
            {
                return this.numberOfCorrectAnswers;
            }

            set
            {
                this.numberOfCorrectAnswers = value;
                this.RecalculateAnswerPercentageWhenAnswerNumberSet();
            }
        }


        /// <summary>
        /// Gets the percentage of the correct answers as a string.
        /// </summary>
        public string CorrectAnswerPercentageAsString
        {
            get
            {
                return Math.Round(this.CorrectAnswerPercentage, 2) + "%";
            }
        }

        public double CorrectAnswerPercentage { get; set; }

        public WordSuccessRate(string word, int numberOfAllAnswers, double numberOfCorrectAnswers)
        {
            this.WordPair = word;
            this.NumberOfAllAnswers = numberOfAllAnswers;
            this.NumberOfCorrectAnswers = numberOfCorrectAnswers;
            this.CorrectAnswerPercentage = numberOfAllAnswers == 0 ? 0 : ((double)(numberOfCorrectAnswers / numberOfAllAnswers)) * 100;
        }

        private void RecalculateAnswerPercentageWhenAnswerNumberSet()
        {
            this.CorrectAnswerPercentage = this.NumberOfAllAnswers == 0 ? 0 : ((double)(this.NumberOfCorrectAnswers / this.NumberOfAllAnswers)) * 100;
        }
    }
}
