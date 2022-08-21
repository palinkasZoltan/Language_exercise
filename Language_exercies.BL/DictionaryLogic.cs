namespace Language_exercise.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Repository;

    public class DictionaryLogic : IDictionaryLogic
    {
        private DictionaryRepository repo = new DictionaryRepository();

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
