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

namespace _10_практическая
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] array;
        List<int> valuesMultiplesOfSeven = new();
        int result = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBoxArray.Items.Clear();
                MultiplesOfSeven.Items.Clear();
                valuesMultiplesOfSeven.Clear();

                bool sizeConversion = int.TryParse(Length.Text, out int sizeOfArray);
                bool maxValueConversion = int.TryParse(txtbxMaxValue.Text, out int maxValue);

                if (maxValueConversion && sizeConversion)
                {
                    array = new int[sizeOfArray];
                    Random rnd = new();
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = rnd.Next(maxValue);
                        ListBoxArray.Items.Add(array[i]);
                    }
                }
                else throw new ArgumentException("Введены неверные данные. " +
                    "Максимальное значение массива и его размерр должны представлять из себя целые числа");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 7 == 0)
                    {
                        valuesMultiplesOfSeven.Add(array[i]);
                    }
                }
                for (int j = 0; j < valuesMultiplesOfSeven.Count; j++)
                {
                    MultiplesOfSeven.Items.Add(valuesMultiplesOfSeven[j]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < valuesMultiplesOfSeven.Count; i++)
                {
                    result += valuesMultiplesOfSeven[i];
                }
                Sum.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа 10.\n" + "Разработчик: Погодина В.\n"
                + "Составьте программу вычисления в массиве суммы всех чисел, кратных 7.");

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
    }
}
