// <copyright file="CreateCustomDictionaryViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels.Others
{
    using System.Collections.ObjectModel;
    using Language_exercise.BL.BL.Model;

    public class CreateCustomDictionaryViewModel : ViewModelBase
    {
        public ObservableCollection<ListedWord> SelectedWords { get; set; }

        public CreateCustomDictionaryViewModel()
        {
            SelectedWords = new ObservableCollection<ListedWord>();
            SelectedWords.Add(new ListedWord() { TranslatedVersion = "FFFF", OriginalVersion = "ssss", ContainingDictionary = "fffff" });
        }
    }
}
