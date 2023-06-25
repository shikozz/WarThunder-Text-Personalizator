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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using MessageBox = System.Windows.MessageBox;

namespace WTTextPersonalizator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private bool isPathLoaded = false;
        public string selectedFolder = "";
        public MainWindow()
        {
            InitializeComponent();
            selectedFolder = Properties.Settings.Default.GamePath;
            if (selectedFolder != "")
            {
                saveSet.IsChecked = true;
                isPathLoaded = true;
                label.Text = selectedFolder;
            }
            else
            {
                saveSet.IsChecked = false;
                isPathLoaded = false;
            }
            if(Properties.Settings.Default.ShowInstruction)
            {
                Instruction nw = new Instruction();
                nw.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                label.Text = folderDlg.SelectedPath;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = label.Text + "/lang/menu.csv";
                string testStr = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    testStr = reader.ReadToEnd();
                }
                if (saveSet.IsChecked == true)
                {
                    Properties.Settings.Default.GamePath = label.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.GamePath = "";
                    Properties.Settings.Default.Save();
                }
                WorkingFrame wf = new WorkingFrame(label.Text);
                wf.Show();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Укажиет корректный путь игры");
            }
        }

        private void saveSet_Checked(object sender, RoutedEventArgs e)
        {
            if (label.Text != "")
            {
                Properties.Settings.Default.GamePath = label.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
