namespace Language_exercise.BL
{
    public interface IDictionaryLogic
    {
        Dictionary<string, string> GetWordsFromMultipleDictionariesBySettings(ExerciseSettings settings);
    }
}