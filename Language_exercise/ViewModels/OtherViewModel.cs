// <copyright file="OtherViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Language_exercise.BL;
    using Language_exercise.BL.BL.Model;

    /// <summary>
    /// ViewModel class for Other UserControl.
    /// </summary>
    internal class OtherViewModel : ViewModelBase
    {
        private ObservableCollection<AdditionalWordListViewModel> additionalWordListViews;

        private string translatedWord;

        private string originalWord;

        public List<string> currentFileNames { get; set; }

        public string selectedFile { get; set; }

        private IDictionaryLogic dictionaryLogic;

        public ICommand AddToListCommand { get; set; }

        public OtherViewModel(IDictionaryLogic dictLogic)
        {
            this.dictionaryLogic = dictLogic;
            currentFileNames = dictionaryLogic.GetExistingDictionaryFileNames();
            additionalWordListViews = new ();
            AddToListCommand = new RelayCommand(() => AddToList());
        }

        public ObservableCollection<AdditionalWordListViewModel> AdditionalWordListViews
        {
            get { return additionalWordListViews; }

            set
            {
                additionalWordListViews = value;
                OnPropertyChanged(nameof(AdditionalWordListViews));
            }
        }

        public string OriginalWord
        {
            get { return originalWord; }

            set
            {
                originalWord = value;
                OnPropertyChanged(nameof(OriginalWord));
            }
        }

        public string TranslatedWord
        {
            get { return translatedWord; }

            set
            {
                translatedWord = value;
                OnPropertyChanged(nameof(TranslatedWord));
            }
        }

        private void AddToList()
        {
            AdditionalWordListViews.Add(new AdditionalWordListViewModel()
            {
                WordInOriginalLanguage = OriginalWord,
                WordInTranslatedLanguage = TranslatedWord,
                FileName = selectedFile,
            });
        }
    }
}
