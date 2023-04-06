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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }
        lab17Entities db = new lab17Entities();
        Рейсы_аэрофлот entry = new Рейсы_аэрофлот();
        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            entry.Номер_рейса = NumberReic.Text;
            entry.Пункт_назначения = PointArrive.Text;

            TimeSpan timeStart = TimeSpan.Parse(TimeStart.Text);
            entry.Время_вылета = timeStart;

            TimeSpan timeArrive = TimeSpan.Parse(TimeArrive.Text);
            entry.Время_прибытия = timeArrive;

            entry.Количество_свободных_мест = int.Parse(CountMest.Text);
            entry.Тип_самолета = TypeAirplan.Text;
            entry.Вместимость = int.Parse(Capacity.Text);

            db.SaveChanges();
            this.Close();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            entry = db.Рейсы_аэрофлот.Find(ForEdit.ID);

            NumberReic.Text = entry.Номер_рейса;
            PointArrive.Text = entry.Пункт_назначения;

            TimeStart.Text = entry.Время_вылета.ToString();
            TimeArrive.Text = entry.Время_прибытия.ToString();

            CountMest.Text = entry.Количество_свободных_мест.ToString();
            TypeAirplan.Text = entry.Тип_самолета;
            Capacity.Text = entry.Вместимость.ToString();
        }
    }
}
