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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace project17
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        lab17Entities1 db = new lab17Entities1();
        Рейсы_аэрофлот entry = new Рейсы_аэрофлот();
        private void AddBTN_Click(object sender, RoutedEventArgs e)
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

            db.Рейсы_аэрофлот.Add(entry);
            db.SaveChanges();
            
            this.Close();
        }
    }
}
