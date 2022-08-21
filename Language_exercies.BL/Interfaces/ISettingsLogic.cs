namespace Language_exercise.BL
{
    public interface ISettingsLogic
    {
        ExerciseSettings GetExerciseSettings();
        void SaveSettings(ExerciseSettings newSettings);
    }
}