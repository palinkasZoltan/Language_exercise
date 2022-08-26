// <copyright file="ExerciseLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL
{
    using Language_exercise.BL.BL.Model;

    public class ExerciseLogic : IExerciseLogic
    {
        private ExerciseSettings settings;

        private IDictionaryLogic dictionaryLogic;

        public ExerciseLogic(IDictionaryLogic dictionaryLogic)
        {
            this.dictionaryLogic = dictionaryLogic;
            this.settings = ExerciseSettings.Instance;
        }

        public Exercise ConstructNewExercise()
        {
            var wordsToExercise = dictionaryLogic.GetWordsFromMultipleDictionariesBySettings();

            Exercise newExercise = new Exercise(wordsToExercise);

            return newExercise;
        }
    }
}
