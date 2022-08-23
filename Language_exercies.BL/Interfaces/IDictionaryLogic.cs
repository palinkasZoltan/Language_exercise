namespace Language_exercise.BL
{
    using Language_exercise.BL.BL.Model;

    public interface IDictionaryLogic
    {
        Dictionary<string, string> GetWordsFromMultipleDictionariesBySettings();

        public List<string> GetExistingDictionaryFileNames();

        public void WriteAddtitionalWordsIntoTheirSpecifiedDictionary(ICollection<AdditionalWordListViewModel> additionalWords);
    }
}