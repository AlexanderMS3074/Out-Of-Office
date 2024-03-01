using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace OutOfOffice {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void CreateMessageDisplay(object sender, RoutedEventArgs e) {      
            Button btnSender = (Button)sender;
            string bgColor = btnSender.Background.ToString();

            MessageDisplay messageDisplay;
            TimeSelect timeSelect;

            switch(btnSender.Name) {
                case "btnMeeting":
                    messageDisplay = new MessageDisplay("In A\nMeeting", bgColor);
                    messageDisplay.Show();
                    break;
                case "btnDoNotRing":
                    messageDisplay = new MessageDisplay("Do Not\nRing Bell","If someone is at window, tap glass", bgColor);
                    messageDisplay.Show();
                    break;
                case "btnShouldReturn":
                    timeSelect = new TimeSelect(bgColor);
                    timeSelect.Show();
                    break;
                case "btnBRB":
                    messageDisplay = new MessageDisplay("Be Right\nBack", bgColor);
                    messageDisplay.Show();
                    break;
                case "btnAway":
                    messageDisplay = new MessageDisplay("Away\nFrom\nOffice", bgColor);
                    messageDisplay.Show();
                    break;
                case "btnLunch":
                    messageDisplay = new MessageDisplay("At\nLunch", bgColor);
                    messageDisplay.Show();
                    break;
                default:
                    MessageBox.Show($"{btnSender.Name} did not match case statement");
                    break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown(exitCode: 0);
        }
    }
}
