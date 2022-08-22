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
    }
}
