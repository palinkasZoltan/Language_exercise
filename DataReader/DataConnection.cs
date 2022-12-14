// <copyright file="DataConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.DL
{
    /// <summary>
    /// Contains the methods to be able to access the DB files.
    /// </summary>
    public class DataConnection
    {
        /// <summary>
        /// Reads a single file.
        /// </summary>
        /// <param name="fileName">Specifies the name of the file which has to be read.</param>
        /// <returns>The text of the file in a raw, IEnumerable format.</returns>
        public IEnumerable<string> ReadSingleFile(string fileName)
        {
            IEnumerable<string> lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\File_DB\" + fileName + ".txt");

            return lines;
        }

        /// <summary>
        /// Writes in the Statistics.txt file, and overwrites it if needed.
        /// </summary>
        /// <param name="newStatisticData">Provides the string data which need to be written into the Statistics.txt file.</param>
        public void OverwriteStatisticsFile(IEnumerable<string> newStatisticData)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory() + @"\File_DB\Statistics\Stats_of_german_words.txt");
            File.WriteAllLines(filePath, newStatisticData);
        }

        /// <summary>
        /// Write in a file, or creates a new file if there is no file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file which needs to be written or created.</param>
        /// <param name="newText">Text which needs to be written in the specified file.</param>
        public void WriteFile(string fileName, List<string> newText)
        {
            fileName = Directory.GetCurrentDirectory() + @"\File_DB\" + fileName;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter streamWriter = new StreamWriter(fs);
                foreach (string text in newText)
                {
                    streamWriter.WriteLine(text);
                }

                streamWriter.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// Reads dictionary file specified in the Settings.txt file or object.
        /// </summary>
        /// <param name="neededFileNames">Prescribes which files has to be read.</param>
        /// <returns>The text of the files in a raw, IEnumerable format.</returns>
        public IEnumerable<string> ReadDictionariesBySettings(string[] neededFileNames)
        {
            IEnumerable<string> loadedDictionaries = new List<string>();
            foreach (string fileName in neededFileNames)
            {
                loadedDictionaries = loadedDictionaries.Concat(this.ReadSingleFile(fileName));
            }

            return loadedDictionaries;
        }

        /// <summary>
        /// Reads the statistics.txt file.
        /// </summary>
        /// <returns>The current statistics in a raw string IEnumerable format.</returns>
        public IEnumerable<string> ReadStatistics()
        {
            return this.ReadSingleFile(@"Statistics\Stats_of_german_words");
        }

        /// <summary>
        /// Reads the current Settings.txt file.
        /// </summary>
        /// <returns>The current settings in a raw string array format.</returns>
        public string[] ReadExerciseSettings()
        {
            string[] settingsData = File.ReadAllLines("Settings.txt");

            return settingsData;
        }

        /// <summary>
        /// Gets the raw data of the current settings object, and writes it in the settings.txt file.
        /// </summary>
        /// <param name="newSettings">Raw data of the current settings file.</param>
        public void SaveSettings(string[] newSettings)
        {
            using (FileStream fs = new FileStream("Settings.txt", FileMode.Open, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);

                foreach (string s in newSettings)
                {
                    sw.WriteLine(s);
                }

                sw.Close();
            }
        }

        private IEnumerable<string> ReadAllDictionary()
        {
            IEnumerable<string> dictionary = new List<string>();

            string[] dir = Directory.GetFiles("File_DB");
            foreach (string file in dir)
            {
                dictionary = dictionary.Concat(this.ReadSingleFile(file));
            }

            return dictionary;
        }
    }
}