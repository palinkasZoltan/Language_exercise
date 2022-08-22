using Language_exercise.BL.BL.Model;

namespace Language_exercise.BL
{
    public interface IDictionaryLogic
    {
        Dictionary<string, string> GetWordsFromMultipleDictionariesBySettings();

        public List<string> GetExistingDictionaryFileNames();
    }
}