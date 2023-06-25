﻿using System;
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
        bool saveCfg = false;
        public WorkingFrame(string path)
        {
            InitializeComponent();
            mainPath= path;
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
            combo1.Items.Add("Точка захвачена");
            combo1.Items.Add("Взрыв боекомплекта");
            combo1.Items.Add("Не пробил");
            combo1.Items.Add("Рикошет");
            combo1.Items.Add("Экипаж выведен из строя");
            combo1.Items.Add("Критический урон");
            combo1.Items.Add("Вернуться в ангар");
            combo2.Items.Add("Миссия выполнена");
            combo2.Items.Add("Миссия провалена");
            combo2.Items.Add("удерживайте, чтобы начать ремонт танка");
            combo2.Items.Add("начать тушить пожар");
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
                    int indexNxt = menuString.IndexOf(changeFromConfig);
                    if (indexNxt >= 0)
                    {
                        res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                        File.WriteAllText(menuPath, res);
                        MessageBox.Show("Изменено успешно!");
                        readFiles();
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
                    int indexNxt = menuString.IndexOf(init);
                    if (indexNxt >= 0)
                    {
                        res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                        File.WriteAllText(menuPath, res);
                        MessageBox.Show("Изменено успешно!");
                        readFiles();
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }          
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
                    int indexNxt = menuString.IndexOf(changeFromConfig);
                    if (indexNxt >= 0)
                    {
                        res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                        File.WriteAllText(menuPath, res);
                        MessageBox.Show("Изменено успешно!");
                        readFiles();
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
                    int indexNxt = uiString.IndexOf(init);
                    if (indexNxt >= 0)
                    {
                        res = uiString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                        File.WriteAllText(uiPath, res);
                        MessageBox.Show("Изменено успешно!");
                        readFiles();
                    }
                }
                else
                {
                    MessageBox.Show("Не найдено!");
                }
            }
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
                configStatus.Content = "Не сохраняется";
                configStatus.Foreground = new SolidColorBrush(Colors.Red);
                saveCfg = false;
            }
        }
    }
}
