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

namespace WTTextPersonalizator
{
    /// <summary>
    /// Логика взаимодействия для donate.xaml
    /// </summary>
    public partial class donate : Window
    {
        public donate()
        {
            InitializeComponent();
        }

        private void press_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.donationalerts.com/r/shikozzrevenge");
        }
    }
}
