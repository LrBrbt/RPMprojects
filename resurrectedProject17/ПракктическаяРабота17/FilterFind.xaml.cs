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

namespace ПракктическаяРабота17
{
    /// <summary>
    /// Логика взаимодействия для FilterFind.xaml
    /// </summary>
    public partial class FilterFind : Window
    {
        public FilterFind()
        {
            InitializeComponent();
        }
        lab17Entities db = lab17Entities.GetContext();
        List<Рейсы_аэрофлот> aeroflot;

        private void Number_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PointArrive_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void filterBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Number.IsChecked == true)
            {
                aeroflot = db.Рейсы_аэрофлот.ToList();
                var filtered = aeroflot.Where(aeroflot => aeroflot.Номер_рейса.Contains(filterTXT.Text));
                Filter.filteredTable = filtered;
                this.Close();
            }
            else if (PointArrive.IsChecked == true)
            {
                aeroflot = db.Рейсы_аэрофлот.ToList();
                var filtered = aeroflot.Where(aeroflot => aeroflot.Пункт_назначения.Contains(filterTXT.Text));
                Filter.filteredTable = filtered;
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
