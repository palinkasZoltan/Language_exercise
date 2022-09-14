namespace Language_exercise.BL
{
    using System.Reflection;
    using Language_exercise.BL.BL.Model;
    using Repository.Interfaces;

    /// <summary>
    /// Contains all the method which is needed to handle the settings of the Exercise page.
    /// </summary>
    public class SettingsLogic : ISettingsLogic
    {
        private ISettingsRepository settingsRepository;

        public SettingsLogic(ISettingsRepository settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        /// <summary>
        /// Reads the raw data from the Settings.txt file and converts it into an ExerciseSettings object.
        /// </summary>
        /// <returns>An ExerciseSettings object with the current values.</returns>
        public void GetExerciseSettings()
        {
            string[] settingsData = this.settingsRepository.ReadSettingsData();

            ExerciseSettings settings = ExerciseSettings.Instance;

            int index = 0;
            for (int i = 0; i < settingsData.Length; i++)
            {
                string temp = settingsData[i];
                Type type = typeof(ExerciseSettings);
                PropertyInfo prop = type.GetProperty(temp.Split('-')[0]);
                if (i == 0)
                {
                    prop.SetValue(settings, int.Parse(temp.Split('-')[1]));
                }
                else
                {
                    prop.SetValue(settings, bool.Parse(temp.Split('-')[1]));
                }

                index++;
            }
        }

        public void SaveSettings()
        {
            ExerciseSettings newSettings = ExerciseSettings.Instance;

            string[] settingsRawData = newSettings.ToString().Split('\n');

            this.settingsRepository.SaveSettings(settingsRawData);
        }
    }
}