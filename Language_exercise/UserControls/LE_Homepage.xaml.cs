using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Language_exercise.UserControls
{
    /// <summary>
    /// Interaction logic for LE_Homepage.xaml
    /// </summary>
    public partial class LE_Homepage : UserControl
    {
        public LE_Homepage()
        {
            InitializeComponent();
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
