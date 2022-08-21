// <copyright file="SettingsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository.Interfaces
{
    public interface ISettingsRepository
    {
        string[] ReadSettingsData();

        void SaveSettings(string[] newSettings);
    }
}