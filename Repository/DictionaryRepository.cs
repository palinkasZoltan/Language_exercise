// <copyright file="DictionaryRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using Language_exercise.DL;
    using Repository.Interfaces;

    public class DictionaryRepository : BaseRepository, IDictionaryRepository
    {
        public DictionaryRepository(DataConnection dataConnection)
            : base(dataConnection)
        {
        }

        public IEnumerable<string> GetMultipleDictionatriesBySettings(string[] neededFiles)
        {
            return dc.ReadDictionariesBySettings(neededFiles);
        }

        public IEnumerable<string> GetExistingDatabaseFileNames()
        {
            return dc.GetExistingDatabaseFileNames();
        }

        public void WriteIntoFileByDictionaryName(string FileName, List<string> newWords)
        {
            dc.WriteFile(FileName, newWords);
        }

        public void WriteStatistics(string fileName, List<string> newLine)
        {
            dc.WriteStatistics(fileName, newLine);
        }
    }
}
