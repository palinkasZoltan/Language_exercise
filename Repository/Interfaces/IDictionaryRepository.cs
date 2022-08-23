namespace Repository.Interfaces
{
    public interface IDictionaryRepository
    {
        IEnumerable<string> GetMultipleDictionatriesBySettings(string[] neededFiles);

        public IEnumerable<string> GetExistingDatabaseFileNames();

        public void WriteIntoFileByDictionaryName(string FileName, List<string> newWords);

        public void WriteStatistics(string fileName, List<string> newLine);
    }
}