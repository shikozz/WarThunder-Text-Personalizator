using Microsoft.Win32;
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
        string uiPath = "";
        string uiString = "";
        string mainPath = "";
        string configPath = "";
        string configString = "";
        bool saveCfg = true;
        public WorkingFrame(string path)
        {
            InitializeComponent();
            mainPath= path;
            instalConfig.Visibility = Visibility.Hidden;
            pathLabel.Content = path;
            menuPath = path + "/lang/menu.csv";
            uiPath = path + "/lang/ui.csv";
            configPath = path + "/WTTR.config";
            using (StreamWriter sw = File.AppendText(path + "/WTTR.config"))
            {

            }
            readFiles();
            combo1.Items.Add("В бой!");
            combo1.Items.Add("Техника уничтожена");
            combo1.Items.Add("Самолёт сбит");
            combo1.Items.Add("Помощь в уничтожении противника");
            combo1.Items.Add("Попадание");
            combo1.Items.Add("Зона захвачена");
            combo1.Items.Add("Взрыв боекомплекта");
            combo1.Items.Add("Не пробил");
            combo1.Items.Add("Рикошет");
            combo1.Items.Add("Цель не была повреждена");
            combo1.Items.Add("Экипаж выведен из строя");
            combo1.Items.Add("Критический урон");
            combo1.Items.Add("Критические повреждения");
            combo1.Items.Add("Вернуться в ангар");
            combo2.Items.Add("Миссия выполнена");
            combo2.Items.Add("Миссия провалена");
            combo2.Items.Add("удерживайте, чтобы начать ремонт танка");
            combo2.Items.Add("Начать тушить пожар");

            /*Properties.Settings.Default.ShowInstruction= true;
            Properties.Settings.Default.Save();*/
        }

        public void readFiles()
        {
            using (StreamReader reader = new StreamReader(menuPath))
            {
                menuString = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(uiPath))
            {
                uiString = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(mainPath+"/WTTR.config"))
            {
                configString = reader.ReadToEnd();
            }

        }

        private void change1_Click(object sender, RoutedEventArgs e)
        {
            string goChange ="\""+text1.Text+"\"";
            string res = "";
            string init = "\""+init1.Text+"\"";

            string resConfig = "";
            string changeFromConfig = "";
            int indexFind = configString.IndexOf(init);
            if (indexFind >= 0)
            {
                indexFind += init.Length + 1;
                int indexSymbol = configString.IndexOf('|', indexFind);
                changeFromConfig = configString.Substring(indexFind, indexSymbol-indexFind);
                resConfig = configString.Remove(indexFind, indexSymbol - indexFind).Insert(indexFind, goChange);
                File.WriteAllText(configPath, resConfig);
                //replace
                int index = menuString.IndexOf(changeFromConfig);
                if (index >= 0)
                {
                    res = menuString.Remove(index, changeFromConfig.Length).Insert(index, goChange);
                    File.WriteAllText(menuPath, res);
                    MessageBox.Show("Изменено успешно!");
                    readFiles();
                    if (saveCfg)
                    {
                        int indexFind1 = configString.IndexOf(init);
                        if (indexFind1 >= 0)
                        {

                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(mainPath + "/WTTR.config"))
                            {
                                sw.Write(init + ":" + goChange + "|");
                            }
                        }
                    }
                    int indexNxt = 0;
                    while (indexNxt >= 0)
                    {
                        indexNxt = menuString.IndexOf(changeFromConfig);
                        if (indexNxt >= 0)
                        {
                            res = menuString.Remove(indexNxt, changeFromConfig.Length).Insert(indexNxt, goChange);
                            File.WriteAllText(menuPath, res);
                            MessageBox.Show("Изменено успешно!");
                            readFiles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }
            else
            {
                int index = menuString.IndexOf(init);
                if (index >= 0)
                {
                    res = menuString.Remove(index, init.Length).Insert(index, goChange);
                    File.WriteAllText(menuPath, res);
                    MessageBox.Show("Изменено успешно!");
                    readFiles();
                    if (saveCfg)
                    {
                        int indexFind1 = configString.IndexOf(init);
                        if (indexFind1 >= 0)
                        {

                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(mainPath + "/WTTR.config"))
                            {
                                sw.Write(init + ":" + goChange + "|");
                            }
                        }
                    }
                    int indexNxt = 0;
                    while (indexNxt >= 0)
                    {
                        indexNxt = menuString.IndexOf(init);
                        if (indexNxt >= 0)
                        {
                            res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                            File.WriteAllText(menuPath, res);
                            MessageBox.Show("Изменено успешно!");
                            readFiles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }
            readFiles();
        }

        private void change2_Click(object sender, RoutedEventArgs e)
        {
            string goChange = "\"" + text2.Text + "\"";
            string res = "";
            string init = "\"" + init2.Text + "\"";

            string resConfig = "";
            string changeFromConfig = "";
            int indexFind = configString.IndexOf(init);
            if (indexFind >= 0)
            {
                indexFind += init.Length + 1;
                int indexSymbol = configString.IndexOf('|', indexFind);
                changeFromConfig = configString.Substring(indexFind, indexSymbol - indexFind);
                resConfig = configString.Remove(indexFind, indexSymbol - indexFind).Insert(indexFind, goChange);
                File.WriteAllText(configPath, resConfig);
                //replace
                int index = uiString.IndexOf(changeFromConfig);
                if (index >= 0)
                {
                    res = uiString.Remove(index, init.Length).Insert(index, goChange);
                    File.WriteAllText(uiPath, res);
                    MessageBox.Show("Изменено успешно!");
                    readFiles();
                    if (saveCfg)
                    {
                        int indexFind1 = configString.IndexOf(init);
                        if (indexFind1 >= 0)
                        {

                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(mainPath + "/WTTR.config"))
                            {
                                sw.Write(init + ":" + goChange + "|");
                            }
                        }
                    }
                    int indexNxt = 0;
                    while (indexNxt>=0)
                    {
                        indexNxt = menuString.IndexOf(changeFromConfig);
                        if (indexNxt >= 0)
                        {
                            res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                            File.WriteAllText(menuPath, res);
                            MessageBox.Show("Изменено успешно!");
                            readFiles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }
            else
            {
                int index = uiString.IndexOf(init);
                if (index >= 0)
                {
                    res = uiString.Remove(index, init.Length).Insert(index, goChange);
                    File.WriteAllText(uiPath, res);
                    MessageBox.Show("Изменено успешно!");
                    readFiles();
                    if (saveCfg)
                    {
                        int indexFind1 = configString.IndexOf(init);
                        if (indexFind1 >= 0)
                        {

                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(mainPath + "/WTTR.config"))
                            {
                                sw.Write(init + ":" + goChange + "|");
                            }
                        }
                    }
                    int indexNxt = 0;
                    while (indexNxt>=0)
                    {
                        indexNxt = uiString.IndexOf(init);
                        if (indexNxt >= 0)
                        {
                            res = uiString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                            File.WriteAllText(uiPath, res);
                            MessageBox.Show("Изменено успешно!");
                            readFiles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }
            readFiles();
        }

        private void clear1_Click(object sender, RoutedEventArgs e)
        {
            text1.Text = "";
            init1.Text = "";
        }

        private void clear2_Click(object sender, RoutedEventArgs e)
        {
            text2.Text = "";
            init2.Text = "";
        }

        private void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            init1.Text = combo1.SelectedItem.ToString();
        }

        private void combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            init2.Text = combo2.SelectedItem.ToString();
        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            if (configStatus.Content.ToString() == "Не сохраняется")
            {
                configStatus.Content = "Сохраняется";
                configStatus.Foreground = new SolidColorBrush(Colors.Green);
                saveCfg = true;
            }
            else
            {
                if(MessageBox.Show("Вы уверены, что хотите отключить сохранение конфигурации?\nВ таком случае для обновления надписей вам \nпридется указать текущее значение!","Отключить конфигурацию", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK) 
                {
                    configStatus.Content = "Не сохраняется";
                    configStatus.Foreground = new SolidColorBrush(Colors.Red);
                    saveCfg = false;
                }
            }
        }

        private void instruction_Click(object sender, RoutedEventArgs e)
        {
            Instruction newWindow = new Instruction();
            newWindow.Show();
        }

        private void loadConfig_Click(object sender, RoutedEventArgs e)
        {
            string pathNew = "";
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = mainPath;
                openFileDialog.Filter = "Config files (*.config)|*.config";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathNew = openFileDialog.FileName;

                    var fileStrem = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(pathNew))
                    {
                        configText.Text = reader.ReadToEnd();
                        if (configText.Text == "")
                        {
                            instalConfig.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        private void patchReload_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Сохраните файл в другую папку, отличную от корневой директивы игры","Внимание",MessageBoxButton.OKCancel,MessageBoxImage.Warning)==MessageBoxResult.OK)
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "config files (*.config)|*.config";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "WTTR.config";
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog.FileName.Contains("War Thunder"))
                    {
                        MessageBox.Show("Нельзя сохранить конфигурацию в эту папку");
                    }
                    else
                    {
                        string fileName = saveFileDialog.FileName;
                        System.IO.File.WriteAllText(fileName, configString);
                        string fileConfigDelete = configPath;
                        File.WriteAllText(configPath,"");
                        Directory.Delete(mainPath + "/lang", true);
                    }
                }
            }
        }

        private void instalConfig_Click(object sender, RoutedEventArgs e)
        {
            var InstalSavedConfig = new InstalSavedConfig(configText.Text,menuPath,uiPath, uiString, menuString, configString, configPath);
        }
    }
}
