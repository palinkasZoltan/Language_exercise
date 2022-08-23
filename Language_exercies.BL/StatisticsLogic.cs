// <copyright file="StatisticsLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL
{
    using Language_exercise.BL.Model;
    using Repository.Interfaces;

    /// <summary>
    /// Logic class for methods involving Statistics data.
    /// </summary>
    public class StatisticsLogic : IStatisticsLogic
    {
        IStatisticsRepository repo;

        Statistic statistic;

        public StatisticsLogic(IStatisticsRepository statRepo)
        {
            repo = statRepo;
            statistic = Statistic.Instance;
        }

        public void GetWordStatictics()
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

            statistic.MostSuccessfulWords = mostSuccessfulWords;
            statistic.LeastSuccessfulWords = leastSuccessfulWords;
            statistic.EveryWord = everyWord;
        }

        public void OverwriteStatistics()
        {
            List<string> statsRawData = new List<string>();

            foreach (WordSuccessRate item in statistic.EveryWord)
            {
                statsRawData.Add($"{item.Word}-{item.NumberOfAllAnswers}-{item.NumberOfCorrectAnswers}-{item.CorrectAnswerPercentage}");
            }

            repo.OverwriteStatistics(statsRawData);
        }

        public void UpdateStatistics(string wordToUpdate, bool isCorrectAnswer)
        {
            WordSuccessRate currentWord = statistic.EveryWord.Find(word => word.Word == wordToUpdate);

            if (isCorrectAnswer)
            {
                currentWord.NumberOfCorrectAnswers++;
            }

            currentWord.NumberOfAllAnswers++;
        }
    }
}
