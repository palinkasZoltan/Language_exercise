// <copyright file="StatisticsLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL
{
    public interface IStatisticsLogic
    {
        void GetWordStatictics();

        void OverwriteStatistics();

        void UpdateStatistics(string wordToUpdate, bool isCorrectAnswer);
    }
}