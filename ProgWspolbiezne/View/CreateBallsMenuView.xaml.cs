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
using System.Text.RegularExpressions;

namespace ProgWspolbiezne.View
{
    /// <summary>
    /// Interaction logic for CreateBallsMenuView.xaml
    /// </summary>
    public partial class CreateBallsMenuView : UserControl
    {
        public CreateBallsMenuView()
        {
            InitializeComponent();
        }

        private void NumValTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

