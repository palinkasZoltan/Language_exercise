// <copyright file="AdditionalWordListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.BL.BL.Model
{
    using Microsoft.VisualStudio.PlatformUI;

    public class AdditionalWordListViewModel : ObservableObject
    {
        public string WordInOriginalLanguage { get; set; }

        public string WordInTranslatedLanguage { get; set; }

        public string FileName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is AdditionalWordListViewModel)
            {
                AdditionalWordListViewModel temp = obj as AdditionalWordListViewModel;

                return temp.WordInTranslatedLanguage == this.WordInTranslatedLanguage && temp.WordInOriginalLanguage == this.WordInOriginalLanguage;
            }

            return false;
        }
    }
}
