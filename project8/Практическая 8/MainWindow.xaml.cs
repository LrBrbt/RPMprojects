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

namespace Практическая_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CargoShip ship = new(TextBoxName.Text,double.Parse(TextBoxFull.Text), double.Parse(TextBoxUnladen.Text));
            ListOfShip.Items.Add(ship);
            ListOfLoadCapacity.Items.Add(ship.LoadCapacity());
        }
        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {

            ICargoTransport ship1 = ListOfShip.SelectedItems[0] as ICargoTransport;
            ICargoTransport ship2 = ListOfShip.SelectedItems[1] as ICargoTransport;

            if (ship1.CompareTo(ship2) == -1)
            {
                MessageBox.Show($"Грузоподъемность корабля {ship2} больше");
            } 
            else if (ship1.CompareTo(ship2) == 1)
            {
                MessageBox.Show($"Грузоподъемность корабля {ship1} больше");
            }
            else
            {
                MessageBox.Show("Корабли равны по грузоподъемности");
            }

        }

        private void clone_Click(object sender, RoutedEventArgs e)
        {
            ICargoTransport temp = ListOfShip.SelectedItem as ICargoTransport;
            ICargoTransport shipClone = (ICargoTransport)temp.Clone();
            ListOfShip.Items.Add(shipClone);
            ListOfLoadCapacity.Items.Add(shipClone.LoadCapacity());

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Погодина В.О.\n" + "Практическая работа 8.\n" + "Создать интерфейсы - корабль, грузовой транспорт. " +
                "Создать класс грузовой \r\nкорабль. " + "Класс должен включать конструктор, функцию для формирования строки \r\nинформации о работнике. " +
                "Сравнение производить по грузоподъемности");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

