// <copyright file="StatisticsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        IEnumerable<string> GetStatisticsData();
        void OverwriteStatistics(IEnumerable<string> newStats);
    }
}