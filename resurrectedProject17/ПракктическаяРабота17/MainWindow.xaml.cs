using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ПракктическаяРабота17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        lab17Entities db = lab17Entities.GetContext();
        string textToFind = string.Empty;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Рейсы_аэрофлот.Load();
            DataBase.ItemsSource = db.Рейсы_аэрофлот.Local.ToBindingList();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.ShowDialog();
            DataBase.Focus();
        }

        private void FindAndReplace_GotFocus(object sender, RoutedEventArgs e)
        {

            Find.Text = "";
            Find.Foreground = Brushes.Black;
            Find.FontStyle = FontStyles.Normal;
            Find.FontWeight = FontWeights.Bold;
            // Find.Focus();
            //textToFind = Find.Text;

        }

        private void FindAndReplace_LostFocus(object sender, RoutedEventArgs e)
        {
            //Find.Text = "Найти и заменить";

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataBase.SelectedIndex;
            if (indexRow != -1)
            {
                Рейсы_аэрофлот row = (Рейсы_аэрофлот)DataBase.Items[indexRow];
                ForEdit.ID = row.Номер_рейса;
                EditWindow edit = new EditWindow();
                edit.ShowDialog();

                DataBase.Items.Refresh();
                DataBase.Focus();
            }
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            db.Рейсы_аэрофлот.Load();
            DataBase.Items.Refresh();

            //DataBase.Focus();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Рейсы_аэрофлот row = (Рейсы_аэрофлот)DataBase.SelectedItems[0];
                db.Рейсы_аэрофлот.Remove(row);
                db.SaveChanges();
            }
        }

        private void FindBTN_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < DataBase.Items.Count; i++)
            {
                var row = (Рейсы_аэрофлот)DataBase.Items[i];
                string toFind = row.Номер_рейса;
                if (toFind != null && toFind.Contains(textToFind))
                {
                    object item = DataBase.Items[i];
                    DataBase.SelectedItem = item;
                    DataBase.ScrollIntoView(item);
                    DataBase.Focus();
                    break;
                }
            }
        }

        private void FilterBTN_Click(object sender, RoutedEventArgs e)
        {
            FilterFind filter = new FilterFind();
            filter.ShowDialog();

            DataBase.Focus();

            if (Filter.filteredTable != null)
            {
                DataBase.ItemsSource = Filter.filteredTable;
            }
            else
            {
                MessageBox.Show("Вы не применили ни одного фильтра", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
