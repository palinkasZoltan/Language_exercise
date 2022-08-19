// <copyright file="LE_Other.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using Language_exercise.BL.Model;
    using Language_exercise.DL;

    /// <summary>
    /// Interaction logic for LE_Other.xaml.
    /// </summary>
    public partial class LE_Other : UserControl
    {
        private List<WordSuccessRate> wordsToAdd;

        public List<WordSuccessRate> WordsToAdd
        {
            get { return wordsToAdd; }
            set { wordsToAdd = value; }
        }

        public LE_Other()
        {
            this.InitializeComponent();
        }

        private void Extend_click(object sender, RoutedEventArgs e)
        {
            DataConnection dc = new DataConnection();
            List<string> newWords = new List<string>();
            string newWord = germanVers.Text + " - " + englishVers.Text;
            newWords.Add(newWord);
            dc.WriteFile("test_file2.txt", newWords);
        }
    }
}
