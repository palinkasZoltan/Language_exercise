﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Language_exercise.DL;
using Repository.Interfaces;

namespace Repository
{
    public class DictionaryRepository : IDictionaryRepository
    {
        DataConnection dc = new DataConnection();

        public IEnumerable<string> GetMultipleDictionatriesBySettings(string[] neededFiles)
        {
            return dc.ReadDictionariesBySettings(neededFiles);
        }
    }
}
