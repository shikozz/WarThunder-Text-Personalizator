using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace WTTextPersonalizator
{
    /// <summary>
    /// Логика взаимодействия для WorkingFrame.xaml
    /// </summary>
    public partial class WorkingFrame : Window
    {
        string menuPath = "";
        string menuString = "";
        public WorkingFrame(string path)
        {
            InitializeComponent();
            pathLabel.Content = path;
            menuPath = path + "/lang/menu.csv";
            readFiles();
        }

        public void readFiles()
        {
            using (StreamReader reader = new StreamReader(menuPath))
            {
                menuString = reader.ReadToEnd();
                Console.WriteLine(menuString);
            }
        }

        private void change1_Click(object sender, RoutedEventArgs e)
        {
            string goChange =text1.Text;
            string res = "";
            string init = init1.Text;
            int index = menuString.IndexOf(init);
            if (index >= 0)
            {
                res = menuString.Remove(index, init.Length).Insert(index, goChange);
                File.WriteAllText(menuPath, res);
                MessageBox.Show("Изменено успешно!");
                init1.Text = "";
                text1.Text = "";
            }
            else
            {
                MessageBox.Show("Не найдено!");
            }
        }
    }
}
