// <copyright file="Exercise.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL.BL.Model
{
    public class Exercise
    {
        public Exercise(Dictionary<string, string> wordsToExercise)
        {
            this.WordsToExercise = wordsToExercise;
        }

        public Exercise()
        {

        }

        public virtual Dictionary<string, string> WordsToExercise { get; set; }

        private Stack<string> CreateStackFromCollection(ICollection<string> collection)
        {
            Stack<string> result = new Stack<string>();

            foreach (var value in collection)
            {
                result.Push(value.ToString());
            }

            return result;
        }
    }
}
