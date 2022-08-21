// <copyright file="StatisticsLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Language_exercise.BL.Model;

namespace Language_exercise.BL.Interfaces
{
    public interface IStatisticsLogic
    {
        Statistic GetWordStatictics();
        void OverwriteStatistics(Statistic newStats);
    }
}