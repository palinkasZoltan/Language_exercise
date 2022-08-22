namespace Repository.Interfaces
{
    public interface IDictionaryRepository
    {
        IEnumerable<string> GetMultipleDictionatriesBySettings(string[] neededFiles);

        public IEnumerable<string> GetExistingDatabaseFileNames();
    }
}