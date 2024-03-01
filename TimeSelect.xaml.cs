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
using System.Windows.Shapes;

namespace OutOfOffice {
    /// <summary>
    /// Interaction logic for TimeSelect.xaml
    /// </summary>
    public partial class TimeSelect : Window {
        private string bgColor;

        public TimeSelect(string color) {
            InitializeComponent();
            bgColor = color;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e) {
            MessageDisplay messageDisplay = new MessageDisplay((int)sldTimeSelect.Value, bgColor);
            messageDisplay.Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
