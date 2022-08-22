// <copyright file="StatisticsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using Language_exercise.DL;
    using Repository.Interfaces;

    public class StatisticsRepository : BaseRepository, IStatisticsRepository
    {
        public StatisticsRepository(DataConnection dc)
            : base(dc)
        {
        }

        /// <summary>
        /// Gets the statistics data.
        /// </summary>
        /// <returns>Raw data in an IEnumberable-string- format.</returns>
        public IEnumerable<string> GetStatisticsData()
        {
            return this.dc.ReadStatistics();
        }

        /// <summary>
        /// Updates the statistics file with the changes from the current session.
        /// </summary>
        /// <param name="newStats">Raw data of the current Statistics object.</param>
        public void OverwriteStatistics(IEnumerable<string> newStats)
        {
            this.dc.OverwriteStatisticsFile(newStats);
        }
    }
}
