using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _11_практическая
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            string s = "aba aca aea abba adca abea";
            Regex firstRegex = new("a..a");

            MatchCollection matches = firstRegex.Matches(s);

            if(matches.Count > 0)
            {
                object[] mas = new object[matches.Count];
                matches.CopyTo(mas, 0);

                ListOfString.ItemsSource = mas;

            }

            string s1 = "ave a#b a2b a$b a4b a5b a-b acb";
            Regex secondRegex = new("a[^A-Za-z0-9]b");

            MatchCollection matches1 = secondRegex.Matches(s1);

            if (matches.Count > 0)
            {
                object[] mas1 = new object[matches1.Count];
                matches1.CopyTo(mas1, 0);

                ListOfString1.ItemsSource = mas1;

            }
        }
    }
}
