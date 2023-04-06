using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace практическая_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle rectangle;
        TextBox lastSelected;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartRectangle_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Length.Text, out int valueLength) && Int32.TryParse(Width.Text, out int valueWidth))
            {
                if (valueLength < 0 || valueWidth < 0)
                {
                    MessageBox.Show("Вы ввели некорректные данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    rectangle = new(valueLength, valueWidth);
                    ResultPerimeter.Text = (rectangle.Perimeter(valueLength, valueWidth)).ToString();
                    ResultArea.Text = (rectangle.Area(valueLength, valueWidth)).ToString();
                    Length.Focus();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели некорректные данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearLength_Click(object sender, RoutedEventArgs e)
        {
            Length.Clear();
            ResultPerimeter.Clear();
            ResultArea.Clear();
            Length.Focus();

        }

        private void ClearWidth_Click(object sender, RoutedEventArgs e)
        {
            Width.Clear();
            ResultPerimeter.Clear();
            ResultArea.Clear();
            Width.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Length.Clear();
            Width.Clear();
            ResultPerimeter.Clear();
            ResultArea.Clear();
            Length.Focus();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Погодина В.О.\n Задание:\n " +
                "• Даны стороны прямоугольника a и b. Найти его площадь периметр.\n " +
                "• Дано трехзначное число. Вывести число, полученное при прочтении исходного числа справа налево.");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbValueToRotate.Clear();
            tbRotatedValue.Clear();
            tbValueToRotate.Focus();
        }
        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            string str = tbValueToRotate.Text;
            tbRotatedValue.Text = Rotate(str);
            tbValueToRotate.Focus();
        }
        public string Rotate(string str)
        {
            char[] chars = str.ToCharArray();

            Array.Reverse(chars);
            return new string(chars);
        }
        private void tbValueToRotate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Back) ;
            else
            {
                MessageBox.Show("Вы вводите некорректные данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
        }
        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new();
            timer.Tick += Timer_Tick;
            timer.Interval = new(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tbTime.Text = date.ToString("T");
            tbData.Text = date.ToString("d");
        }

        private void IsPanelOfToolsEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Hidden;
        }

        private void IsPanelOfToolsEnable_Checked(object sender, RoutedEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Visible;
        }

    }
}
