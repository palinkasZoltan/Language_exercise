namespace Repository.Interfaces
{
    public interface IDictionaryRepository
    {
        IEnumerable<string> GetMultipleDictionatriesBySettings(string[] neededFiles);
    }
}