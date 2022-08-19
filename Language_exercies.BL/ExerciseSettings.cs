namespace Language_exercise.BL
{
    using System;
    using System.Reflection;

    public class ExerciseSettings
    {
        public int NumberOfWords { get; set; }

        public bool IsAllIncluded { get; set; }

        public bool IsAnimalsIncluded { get; set; }

        public bool IsFamilyIncluded { get; set; }

        public bool IsGoingOutIncluded { get; set; }

        public bool IsWorkIncluded { get; set; }

        public bool IsLifeIncluded { get; set; }

        public bool IsHomeIncluded { get; set; }

        public bool IsOthersIncluded { get; set; }

        public bool IsVehiclesIncluded { get; set; }

        public bool IsSportIncluded { get; set; }

        public bool IsArtsIncluded { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string result = string.Empty;

            Type type = typeof(ExerciseSettings);
            PropertyInfo[] propertyInfos = type.GetProperties();

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                result += $"{propertyInfos[i].Name}-{propertyInfos[i].GetValue(this)}";
                if (i != propertyInfos.Length - 1)
                {
                    result += "\n";
                }
            }

            return result;
        }
    }
}
