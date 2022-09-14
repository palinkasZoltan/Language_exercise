// <copyright file="ListedWord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL.BL.Model
{
    public class ListedWord
    {
        /// <summary>
        /// Gets or sets the translated version of the word.
        /// </summary>
        public string TranslatedVersion { get; set; }

        public string OriginalVersion { get; set; }

        public string ContainingDictionary { get; set; }
    }
}
