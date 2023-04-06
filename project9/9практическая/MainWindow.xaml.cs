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

namespace _9практическая
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Computer computer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            computer = new("Компьютер", textboxProcessorType.Text, Int32.Parse(textboxMemorySize.Text), Int32.Parse(textboxHDDSize.Text), textboxVideoCard.Text);
            Computers.Items.Add(computer);
        }

        private void Computers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedComputer = (Computer)Computers.SelectedItem;
            MessageBox.Show("Тип процессора: " + selectedComputer.ProcessorType + "\n" + "Объем памяти: " +  selectedComputer.MemorySize.ToString() + "\n" + "Объем жесткого диска: " + selectedComputer.HDDSize.ToString() + "\n" + "Видеокарта: " + selectedComputer.VideoCard);
        }

        private void Average_Click(object sender, RoutedEventArgs e)
        {
            var selectedComputers = Computers.SelectedItems;
            int sum = 0;
            for (int i = 0; i < selectedComputers.Count; i++)
            {
                Computer computer = (Computer)selectedComputers[i];
                sum += computer.MemorySize;
            }
            int average = sum / selectedComputers.Count;
            MessageBox.Show("Среднее значение памяти: " + average.ToString());
        }
    }
}
