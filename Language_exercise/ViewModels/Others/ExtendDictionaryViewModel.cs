namespace Language_exercise.ViewModels.Others
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Windows.Media;
    using GalaSoft.MvvmLight.Command;
    using Language_exercise.BL;
    using Language_exercise.BL.BL.Model;

    public class ExtendDictionaryViewModel : ViewModelBase
    {
        private ObservableCollection<AdditionalWordListViewModel> additionalWordListViews;

        private string translatedWord;

        private string originalWord;

        public List<string> currentFileNames { get; set; }

        public string selectedFile { get; set; }

        private IDictionaryLogic dictionaryLogic;
        private Brush listBoxBorderBrush;
        private AdditionalWordListViewModel selectedListItem;

        public bool IsDataGridFocused { get; }

        public ICommand AddToListCommand { get; set; }

        public ICommand AddToDictionaryCommand { get; set; }

        public ICommand UndoCommand { get; set; }

        public ICommand DeleteSelectedByKeyCommand { get; set; }

        public ICommand DeleteSelectedCommand { get; set; }

        public ICommand EnterKeyCommand { get; set; }

        public ExtendDictionaryViewModel(IDictionaryLogic dictLogic)
        {
            this.dictionaryLogic = dictLogic;
            currentFileNames = dictionaryLogic.GetExistingDictionaryFileNames();
            additionalWordListViews = new();

            SetupCommands();
        }

        public ObservableCollection<AdditionalWordListViewModel> AdditionalWordListViews
        {
            get { return additionalWordListViews; }

            set
            {
                SetProperty(ref additionalWordListViews, value);
                OnPropertyChanged(nameof(AdditionalWordListViews));
            }
        }

        public Brush ListBoxBorderBrush
        {
            get
            {
                return listBoxBorderBrush;
            }

            set
            {
                listBoxBorderBrush = value;
                OnPropertyChanged(nameof(ListBoxBorderBrush));
            }
        }

        public AdditionalWordListViewModel SelectedListItem
        {
            get
            {
                return selectedListItem;
            }

            set
            {
                selectedListItem = value;
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }

        public string OriginalWord
        {
            get
            {
                return originalWord;
            }

            set
            {
                originalWord = value;
                OnPropertyChanged(nameof(OriginalWord));
            }
        }

        public string TranslatedWord
        {
            get
            {
                return translatedWord;
            }

            set
            {
                translatedWord = value;
                OnPropertyChanged(nameof(TranslatedWord));
            }
        }

        private void AddToList()
        {
            if (selectedFile == null)
            {
                ListBoxBorderBrush = Brushes.Red;
            }

            if (OriginalWord != string.Empty && TranslatedWord != string.Empty && selectedFile != null)
            {
                AdditionalWordListViewModel newWordTemp = new AdditionalWordListViewModel()
                {
                    WordInOriginalLanguage = OriginalWord,
                    WordInTranslatedLanguage = TranslatedWord,
                    FileName = selectedFile,
                };

                bool contains = AdditionalWordListViews.Contains(newWordTemp);

                if (!contains)
                {
                    AdditionalWordListViews.Add(newWordTemp);
                }
            }

            OriginalWord = string.Empty;
            TranslatedWord = string.Empty;
        }

        private void Undo()
        {
            if (AdditionalWordListViews.Count > 0)
            {
                this.AdditionalWordListViews.RemoveAt(AdditionalWordListViews.Count - 1);
            }
        }

        private void DeleteSelectedListViewItem()
        {
            this.AdditionalWordListViews.Remove(this.SelectedListItem);
        }

        private void SaveListToDictionary()
        {
            dictionaryLogic.WriteAddtitionalWordsIntoTheirSpecifiedDictionary(AdditionalWordListViews);
            AdditionalWordListViews.Clear();
        }

        private void SetupCommands()
        {
            AddToListCommand = new RelayCommand(() => AddToList());
            AddToDictionaryCommand = new RelayCommand(() => SaveListToDictionary());
            UndoCommand = new RelayCommand(() => Undo());
            DeleteSelectedCommand = new RelayCommand(() => DeleteSelectedListViewItem());
        }
    }
}
