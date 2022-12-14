namespace Language_exercise.BL
{
    using System.Reflection;
    using Repository;

    /// <summary>
    /// Contains all the method which is needed to handle the settings of the Exercise page.
    /// </summary>
    public class SettingsLogic
    {
        private SettingsRepository settingsRepository = new SettingsRepository();

        /// <summary>
        /// Reads the raw data from the Settings.txt file and converts it into an ExerciseSettings object.
        /// </summary>
        /// <returns>An ExerciseSettings object with the current values.</returns>
        public ExerciseSettings GetExerciseSettings()
        {
            string[] settingsData = this.settingsRepository.ReadSettingsData();

            ExerciseSettings settings = new ExerciseSettings();

            int index = 0;
            for (int i = 0; i < settingsData.Length; i++)
            {
                string temp = settingsData[i];
                Type type = typeof(ExerciseSettings);
                PropertyInfo prop = type.GetProperty(temp.Split('-')[0]);
                if (index == 0)
                {
                    prop.SetValue(settings, int.Parse(temp.Split('-')[1]));
                }
                else
                {
                    prop.SetValue(settings, bool.Parse(temp.Split('-')[1]));
                }

                index++;
            }

            return settings;
        }

        public void SaveSettings(ExerciseSettings newSettings)
        {
            string[] settingsRawData = newSettings.ToString().Split('\n');

            this.settingsRepository.SaveSettings(settingsRawData);
        }
    }
}