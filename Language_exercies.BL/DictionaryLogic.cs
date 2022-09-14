namespace Language_exercise.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Language_exercise.BL.BL.Model;
    using Repository.Interfaces;

    public class DictionaryLogic : IDictionaryLogic
    {
        private IDictionaryRepository repo;

        private ExerciseSettings settings;

        public DictionaryLogic(IDictionaryRepository dictRepo)
        {
            repo = dictRepo;
        }

        public Dictionary<string, string> GetWordsFromMultipleDictionariesBySettings(ExerciseSettings settings)
        {
            string[] fileNames = this.GetFilenamesFromTopicSettings(settings);

            IEnumerable<string> rawWordPairs = this.repo.GetMultipleDictionatriesBySettings(fileNames);

            IEnumerable<string> randomizedWordPairSet = this.RandomizeSelectedWords(rawWordPairs.ToArray(), settings);

            Dictionary<string, string> splitWordPairs = new Dictionary<string, string>();

            foreach (string wordPair in randomizedWordPairSet)
            {
                string[] temp = wordPair.Split('-');
                splitWordPairs.Add(temp[0].Trim(), temp[1].Trim());
            }

            return splitWordPairs;
        }

        public List<string> GetExistingDictionaryFileNames()
        {
            return repo.GetExistingDatabaseFileNames().Select(fileName => fileName.Replace(".txt", string.Empty)).ToList();
        }

        public void WriteAddtitionalWordsIntoTheirSpecifiedDictionary(ICollection<AdditionalWordListViewModel> additionalWords)
        {
            Dictionary<string, List<string>> sortedWords = SortAdditionalWordsByDictionaries(additionalWords);

            foreach (var item in sortedWords)
            {
                repo.WriteIntoFileByDictionaryName(item.Key, item.Value);
            }

            List<string> wordsToStatistics = additionalWords.Select(word => word.WordInTranslatedLanguage + "-0-0-0").ToList();

            string statFileName = "Stats_of_german_words";

            repo.WriteStatistics(statFileName, wordsToStatistics);
        }

        private Dictionary<string, List<string>> SortAdditionalWordsByDictionaries(ICollection<AdditionalWordListViewModel> additionalWordListViews)
        {
            Dictionary<string, List<string>> sortedWords = new Dictionary<string, List<string>>();

            foreach (var word in additionalWordListViews)
            {
                string concatenatedWordPair = word.WordInTranslatedLanguage + "-" + word.WordInOriginalLanguage;

                if (!sortedWords.ContainsKey(word.FileName))
                {
                    sortedWords.Add(word.FileName, new List<string>());
                }

                sortedWords[word.FileName].Add(concatenatedWordPair);
            }

            return sortedWords;
        }

        private string[] GetFilenamesFromTopicSettings(ExerciseSettings settings)
        {
            Type type = typeof(ExerciseSettings);
            PropertyInfo[] propertyInfos = type.GetProperties();
            var neededFileNames = propertyInfos.Where(info => info.PropertyType == typeof(bool) && (bool)info.GetValue(settings) == true)
                                               .Where(info => !info.Name.Contains("All"))
                                               .Select(info => info.Name.Replace("Is", string.Empty).Replace("Included", string.Empty));

            return neededFileNames.ToArray();
        }

        private IEnumerable<string> RandomizeSelectedWords(string[] everyWordPair, ExerciseSettings settings)
        {
            string[] selectedWords = new string[settings.NumberOfWords];

            if (everyWordPair.Length <= settings.NumberOfWords)
            {
                return everyWordPair;
            }
            else
            {
                Random r = new Random();
                int totalWordPairCount = everyWordPair.Length;
                for (int i = 0; i < selectedWords.Length; i++)
                {
                    while (selectedWords[i] == null)
                    {
                        int randomNumber = r.Next(0, totalWordPairCount);
                        if (!selectedWords.Contains(everyWordPair[randomNumber]))
                        {
                            selectedWords[i] = everyWordPair[randomNumber];
                        }
                    }
                }
            }

            return selectedWords;
        }
    }
}
