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
using System.Windows.Threading;

namespace OutOfOffice {
    /// <summary>
    /// Interaction logic for MessageDisplay.xaml
    /// </summary>
    public partial class MessageDisplay : Window {
        private DispatcherTimer? timer;
        private TimeSpan time;
        private bool isTimed = false;

        private void InitControls(string color) {
            PreviewKeyDown += new KeyEventHandler(HandleEsc);

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        public MessageDisplay() {
            InitializeComponent();
            InitControls("#80F");

            txBlMain.Text = "If you are seeing this screen\nsomething went wrong";
        }

        public MessageDisplay(string mainMessage, string color) {
            InitializeComponent();
            InitControls(color);

            rDefSub.Height = (GridLength) new GridLengthConverter().ConvertFromString("0")!;
            txBlMain.Text = mainMessage;
        }
        
        public MessageDisplay(string mainMessage, string subMessage, string color) {
            InitializeComponent();
            InitControls(color);

            rDefSub.Height = (GridLength)new GridLengthConverter().ConvertFromString("*")!;
            txBlMain.Text = mainMessage;
            txBlSub.Text = subMessage;
        }

        public MessageDisplay(int duration, string color) {
            InitializeComponent();
            InitControls(color);
            isTimed = true;
            rDefSub.Height = (GridLength)new GridLengthConverter().ConvertFromString("0")!;

            time = TimeSpan.FromMinutes(duration);
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate {
                int minutes = ((int)time.TotalSeconds / 60) + 1; //Rounds the minutes up e.g.: 12m 45s => 13m
                txBlSub.FontSize = 48;
                if(minutes > 10) {
                    txBlMain.Text = $"Will Return In\n{minutes} Minutes";
                }
                if(minutes <= 10) {
                    timer.Stop();
                    txBlMain.Text = $"Will Return\nSoon";
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            timer.Start();
        }

        private void HandleEsc(object sender, KeyEventArgs e) {
            if(e.Key == Key.Escape) {
                if(isTimed && timer.IsEnabled) {
                    timer.Stop();
                }
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            txBlMain.FontSize = (rDefMain.ActualHeight / 2) * 0.5;
            if(txBlSub.Text != "") {
                txBlSub.FontSize = rDefSub.ActualHeight * 0.5;
            }
        }
    }
}
