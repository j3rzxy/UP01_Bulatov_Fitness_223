using System;
using System.Windows;

namespace UP01_Bulatov_Fitness_223
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1),
                IsEnabled = true
            };
            timer.Tick += (o, t) =>
            {
                DateTimeNow.Text = DateTime.Now.ToString();
            };
            timer.Start();
        }

        private void BackPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть окно?", "Message",
            MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.No)
                e.Cancel = true;
            else

                e.Cancel = false;
        }
    }
}
