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

namespace project7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Money money = new(2, 5);
            Money money2 = new(5, 10);

            Money res = money2.Division(money);
            MessageBox.Show(res.ToString());
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var selectedPair = ListWithPairs.SelectedItems;
                if (selectedPair.Count == 3)
                {
                    Pair pair1 = selectedPair[0] as Pair;
                    Pair pair2 = selectedPair[1] as Pair;
                    Pair pair3 = selectedPair[2] as Pair;
                    Result.Text = pair1.Addition(pair2, pair3).ToString();
                }
                else
                {
                    Pair pair1 = selectedPair[0] as Pair;
                    Pair pair2 = selectedPair[1] as Pair;
                    Result.Text = pair2.Addition(pair1).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddPair_Click(object sender, RoutedEventArgs e)
        {
            bool firstConverse = int.TryParse(FirstValue.Text, out int firstValue);
            bool secondConverse = int.TryParse(SecondValue.Text, out int secondValue);

            if (firstConverse && secondConverse)
            {
                Pair pair = new Pair(Convert.ToInt32(firstValue), Convert.ToInt32(secondValue));
                ListWithPairs.Items.Add(pair);
            }

            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!");
            }
        }
        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedPair = ListWithPairs.SelectedItems;
                Pair pair1 = selectedPair[0] as Pair;
                Pair helpPair = pair1.IncreaseFields();
                ListWithPairs.Items[ListWithPairs.SelectedIndex] = helpPair;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedPair = ListWithPairs.SelectedItems;
                Pair pair1 = selectedPair[0] as Pair;
                Pair helpPair = --pair1;
                ListWithPairs.Items[ListWithPairs.SelectedIndex] = helpPair;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Погодина В.О.\n" + "Практическая работа 5\n" + "Создать класс Pair (пара чисел). Создать необходимые методы и свойства.\n" +
                "Определить методы метод сложения полей и операцию сложения пар(а, b) + (с, d)\n" +
                "= (а + c, b + d).Создать перегруженные методы для увеличения полей на 1, сложения трех пар чисел.;");
        }

    }
}
