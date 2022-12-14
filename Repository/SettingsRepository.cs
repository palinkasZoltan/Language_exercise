// <copyright file="SettingsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using Language_exercise.DL;

    /// <summary>
    /// Contains the methods which need to be access by the SettingsLogic.
    /// </summary>
    public class SettingsRepository
    {
        private DataConnection dc = new DataConnection();

        /// <summary>
        /// Recovers data from the Settings.txt.
        /// </summary>
        /// <returns>Raw data of the saved settings.</returns>
        public string[] ReadSettingsData()
        {
            return this.dc.ReadExerciseSettings();
        }

        /// <summary>
        /// Saves the current settings into the Settings.txt file.
        /// </summary>
        /// <param name="newSettings">Raw data of the current settings.</param>
        public void SaveSettings(string[] newSettings)
        {
            this.dc.SaveSettings(newSettings);
        }
    }
}
