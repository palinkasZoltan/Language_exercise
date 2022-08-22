// <copyright file="LE_Statistics.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Language_exercise.UserControls
{
    using System.Windows.Controls;
    using Language_exercise.BL.Model;

    /// <summary>
    /// Interaction logic for LE_Statistics.xaml.
    /// </summary>
    public partial class LE_Statistics : UserControl
    {
        private Statistic statistic;

        /// <summary>
        /// Initializes a new instance of the <see cref="LE_Statistics"/> class.
        /// </summary>
        /// <param name="stat">The Statistics object which will be loaded into the controls.</param>
        public LE_Statistics()
        {
            this.InitializeComponent();
        }
    }
}
