// <copyright file="StatisticsLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL
{
    using Language_exercise.BL.Interfaces;
    using Language_exercise.BL.Model;
    using Repository;

    /// <summary>
    /// Logic class for methods involving Statistics data.
    /// </summary>
    public class StatisticsLogic : IStatisticsLogic
    {
        StatisticsRepository repo = new StatisticsRepository();

        public Statistic GetWordStatictics()
        {
            IEnumerable<string> rawData = this.repo.GetStatisticsData();

            List<WordSuccessRate> everyWord = new();

            foreach (string dataRow in rawData)
            {
                string[] splittedDataRow = dataRow.Split('-');
                everyWord.Add(new WordSuccessRate(splittedDataRow[0], int.Parse(splittedDataRow[1]), double.Parse(splittedDataRow[2])));
            }

            WordSuccessRate[] mostSuccessfulWords = everyWord.OrderByDescending(wordStat => wordStat.CorrectAnswerPercentage).Select(wordStat => wordStat).Take(5).ToArray();
            WordSuccessRate[] leastSuccessfulWords = everyWord.OrderBy(wordStat => wordStat.CorrectAnswerPercentage).Select(wordStat => wordStat).Take(5).ToArray();

            return new Statistic(mostSuccessfulWords, leastSuccessfulWords, everyWord);
        }

        public void OverwriteStatistics(Statistic newStats)
        {
            List<string> statsRawData = new List<string>();

            foreach (WordSuccessRate item in newStats.EveryWord)
            {
                statsRawData.Add($"{item.Word}-{item.NumberOfAllAnswers}-{item.NumberOfCorrectAnswers}-{item.CorrectAnswerPercentage}");
            }

            repo.OverwriteStatistics(statsRawData);
        }
    }
}
