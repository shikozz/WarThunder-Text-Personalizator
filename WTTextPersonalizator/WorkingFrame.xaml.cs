using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        public string toBattle = "";
        public string enemyDestroyed = "";
        public string planeDestroyed = "";
        public string asist = "";
        public string hit = "";
        public string captureZone = "";
        public string kaboom = "";
        public string noPen = "";
        public string ricoshet = "";
        public string noDamage = "";
        public string crewDestroyed = "";
        public string critDamage = "";
        public string critDmg = "";
        public string scout;
        public string scoutDmg;
        public string scoutDestroyed;
        public string returnToHangar = "";
        public string missionWin = "";
        public string missionLost = "";
        public string repair = "";
        public string fire = "";
        public string lostControl = "";
        public string overload = "";

        public string saveConfigStr = "";
        public string notSaveConfigStr = "";

        public string changesSucces;
        public string notFound;
        public string stopSavingConfig;
        public string saveToAnotherDir;
        public string cannotSaveInGameDir;

        public string checkRunning;
        public bool gameRunnig;

        public WorkingFrame(string path)
        {
            InitializeComponent();
            //checkIfGameIsRunning();
            Properties.Settings.Default.ShowInstruction = false;
            SetLanguage();
            mainPath= path;
            instalConfig.Visibility = Visibility.Hidden;
            pathLabel.Content = path;
            menuPath = path + "/lang/menu.csv";
            uiPath = path + "/lang/ui.csv";
            configPath = path + "/WTTP.config";
            using (StreamWriter sw = File.AppendText(path + "/WTTP.config"))
            {

            }
            readFiles();
            combo1.Items.Add(toBattle) ;
            combo1.Items.Add(enemyDestroyed);
            combo1.Items.Add(planeDestroyed);
            combo1.Items.Add(asist);
            combo1.Items.Add(hit);
            combo1.Items.Add(captureZone);
            combo1.Items.Add(kaboom);
            combo1.Items.Add(noPen);
            combo1.Items.Add(ricoshet);
            combo1.Items.Add(noDamage);
            combo1.Items.Add(crewDestroyed);
            combo1.Items.Add(critDamage);
            combo1.Items.Add(critDmg);
            combo1.Items.Add(scout);
            combo1.Items.Add(scoutDmg);
            combo1.Items.Add(scoutDestroyed);
            combo1.Items.Add(returnToHangar);
            combo2.Items.Add(missionWin);
            combo2.Items.Add(missionLost);
            combo2.Items.Add(repair);
            combo2.Items.Add(fire);
            combo2.Items.Add(overload);
            combo2.Items.Add(lostControl);
            if(Properties.Settings.Default.Language=="ru")
            {
                helpMe.Visibility = Visibility.Visible;
            }
            else
            {
                helpMe.Visibility = Visibility.Hidden;
            }
            /*Properties.Settings.Default.ShowInstruction= true;
            Properties.Settings.Default.Save();*/

        }

        public void checkIfGameIsRunning()
        {
            if (Process.GetProcessesByName("aces").Length > 0)
            {
                MessageBox.Show(checkRunning);
                gameRunnig = true;
            }
            else
            {
                gameRunnig= false;
            }
        }
        public void SetLanguage()
        {
            languageResource lr = new languageResource(Properties.Settings.Default.Language);
            toBattle = lr.toBattle;
            enemyDestroyed= lr.enemyDestroyed;
            planeDestroyed= lr.planeDestroyed;
            asist = lr.asist;
            hit = lr.hit;
            captureZone= lr.captureZone;
            kaboom= lr.kaboom;
            noPen = lr.noPen;
            ricoshet= lr.ricoshet;
            noDamage= lr.noDamage;
            crewDestroyed= lr.crewDestroyed;
            critDamage= lr.critDamage;
            critDmg= lr.critDmg;
            scout = lr.scout;
            scoutDmg = lr.scoutDamage;
            scoutDestroyed= lr.scoutDestroyed;
            returnToHangar= lr.returnToHangar;
            missionWin= lr.missionWin;
            missionLost= lr.missionLost;
            repair = lr.repair;
            fire = lr.fire;
            overload= lr.overload;
            lostControl= lr.lostControl;
            changeMenu.Content = lr.changeMenu;
            frequentOptions.Content= lr.frequentOptions;
            frequentOptions1.Content = lr.frequentOptions;
            initValue.Content = lr.initValue;
            initValue1.Content = lr.initValue;
            endValue.Content = lr.endValue;
            endValue1.Content = lr.endValue;
            changeUi.Content = lr.changeUi;
            saveConfigStr = lr.saveConfig;
            notSaveConfigStr= lr.notSaveConfig;
            patchReload.Content = lr.patchBtn;
            change1.Content = lr.changeBtn;
            change2.Content = lr.changeBtn;
            clear1.Content= lr.clearBtn;
            clear2.Content = lr.clearBtn;
            saveConfig.Content= lr.savingConfigBtn;
            loadConfig.Content= lr.loadConfigBtn;
            instalConfig.Content= lr.instalConfigBtn;
            instruction.Content= lr.instructionBtn;

            changesSucces = lr.changesSucces;
            notFound = lr.notFound;
            stopSavingConfig = lr.stopSavingConfig;
            saveToAnotherDir= lr.saveToAnotherDir;
            cannotSaveInGameDir= lr.cannotSaveInGameDir;
            configStatus.Content = lr.saveConfig;

            checkRunning = lr.checkRunning;
        }
        public void readFiles()
        {
            try
            {
                using (StreamReader reader = new StreamReader(menuPath))
                {
                    menuString = reader.ReadToEnd();
                }
                using (StreamReader reader = new StreamReader(uiPath))
                {
                    uiString = reader.ReadToEnd();
                }
                using (StreamReader reader = new StreamReader(mainPath + "/WTTP.config"))
                {
                    configString = reader.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show(notFound+" menu.csv & ui.csv");
            }
        }

        private void change1_Click(object sender, RoutedEventArgs e)
        {
            checkIfGameIsRunning();
            if(!gameRunnig)
            { 
            string goChange ="\""+text1.Text+"\"";
            string res = "";
            string init = "\""+init1.Text+"\"";
            if (text1.Text == "" || init1.Text == "")
            { }
                else
                {
                    string resConfig = "";
                    string changeFromConfig = "";
                    int indexFind = configString.IndexOf(init);
                    int falseIndex = 0;
                    try
                    {
                        falseIndex= configString.IndexOf(goChange);
                    }
                    catch{}
                    if (indexFind >= 0 && falseIndex<0)
                    {
                        indexFind += init.Length + 1;
                        int indexSymbol = configString.IndexOf('|', indexFind);
                        changeFromConfig = configString.Substring(indexFind, indexSymbol - indexFind);
                        resConfig = configString.Remove(indexFind, indexSymbol - indexFind).Insert(indexFind, goChange);
                        File.WriteAllText(configPath, resConfig);
                        //replace
                        int index = menuString.IndexOf(changeFromConfig);
                        if (index >= 0)
                        {
                            res = menuString.Remove(index, changeFromConfig.Length).Insert(index, goChange);
                            File.WriteAllText(menuPath, res);
                            MessageBox.Show(changesSucces);
                            readFiles();
                            if (saveCfg)
                            {
                                int indexFind1 = configString.IndexOf(init);
                                if (indexFind1 >= 0)
                                {

                                }
                                else
                                {
                                    using (StreamWriter sw = File.AppendText(mainPath + "/WTTP.config"))
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
                                    MessageBox.Show(changesSucces);
                                    readFiles();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(notFound);
                        }
                    }
                    else
                    {
                        int index = menuString.IndexOf(init);
                        if (index >= 0)
                        {
                            res = menuString.Remove(index, init.Length).Insert(index, goChange);
                            File.WriteAllText(menuPath, res);
                            MessageBox.Show(changesSucces);
                            readFiles();
                            if (saveCfg)
                            {
                                int indexFind1 = configString.IndexOf(init);
                                if (indexFind1 >= 0)
                                {

                                }
                                else
                                {
                                    using (StreamWriter sw = File.AppendText(mainPath + "/WTTP.config"))
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
                                    MessageBox.Show(changesSucces);
                                    readFiles();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(notFound);
                        }
                    }
                    readFiles();
                }
            }
        }

        private void change2_Click(object sender, RoutedEventArgs e)
        {
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
            string goChange = "\"" + text2.Text + "\"";
            string res = "";
            string init = "\"" + init2.Text + "\"";
            string resConfig = "";
            string changeFromConfig = "";
                if (text2.Text == "" || init2.Text == "")
                { }
                else
                {
                    int indexFind = configString.IndexOf(init);
                    int falseIndex = 0;
                    try
                    {
                        falseIndex = configString.IndexOf(goChange);
                    }
                    catch { }
                    if (indexFind >= 0 && falseIndex<0)
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
                            MessageBox.Show(changesSucces);
                            readFiles();
                            if (saveCfg)
                            {
                                int indexFind1 = configString.IndexOf(init);
                                if (indexFind1 >= 0)
                                {

                                }
                                else
                                {
                                    using (StreamWriter sw = File.AppendText(mainPath + "/WTTP.config"))
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
                                    res = menuString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                                    File.WriteAllText(menuPath, res);
                                    MessageBox.Show(changesSucces);
                                    readFiles();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(notFound);
                        }
                    }
                    else
                    {
                        int index = uiString.IndexOf(init);
                        if (index >= 0)
                        {
                            res = uiString.Remove(index, init.Length).Insert(index, goChange);
                            File.WriteAllText(uiPath, res);
                            MessageBox.Show(changesSucces);
                            readFiles();
                            if (saveCfg)
                            {
                                int indexFind1 = configString.IndexOf(init);
                                if (indexFind1 >= 0)
                                {

                                }
                                else
                                {
                                    using (StreamWriter sw = File.AppendText(mainPath + "/WTTP.config"))
                                    {
                                        sw.Write(init + ":" + goChange + "|");
                                    }
                                }
                            }
                            int indexNxt = 0;
                            while (indexNxt >= 0)
                            {
                                indexNxt = uiString.IndexOf(init);
                                if (indexNxt >= 0)
                                {
                                    res = uiString.Remove(indexNxt, init.Length).Insert(indexNxt, goChange);
                                    File.WriteAllText(uiPath, res);
                                    MessageBox.Show(changesSucces);
                                    readFiles();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(notFound);
                        }
                    }
                    readFiles();
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
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                string initTextString = combo1.SelectedItem.ToString();
                initTextString= initTextString.Trim();
                init1.Text = initTextString;

            }
        }

        private void combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                string initTextString = combo2.SelectedItem.ToString();
                initTextString= initTextString.Trim(); 
                init2.Text = initTextString;
            }
        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                if (configStatus.Content.ToString() == notSaveConfigStr)
                {
                    configStatus.Content = saveConfigStr;
                    configStatus.Foreground = new SolidColorBrush(Colors.Green);
                    saveCfg = true;
                }
                else
                {
                    if (MessageBox.Show(stopSavingConfig, "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        configStatus.Content = notSaveConfigStr;
                        configStatus.Foreground = new SolidColorBrush(Colors.Red);
                        saveCfg = false;
                    }
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
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                readFiles();
                string pathNew = "";
                using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = mainPath;
                    openFileDialog.Filter = "Config files (*.config)|*.config";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pathNew = openFileDialog.FileName;

                        var fileStrem = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(pathNew))
                        {
                            configText.Text = reader.ReadToEnd();
                            if (configText.Text.Contains(":") && !configString.Contains(":"))
                            {
                                instalConfig.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                instalConfig.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
            }
        }

        private void patchReload_Click(object sender, RoutedEventArgs e)
        {
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                if (MessageBox.Show(saveToAnotherDir, "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Filter = "config files (*.config)|*.config";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = "WTTP.config";
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (saveFileDialog.FileName.Contains("War Thunder"))
                        {
                            MessageBox.Show(cannotSaveInGameDir);
                        }
                        else
                        {
                            string fileName = saveFileDialog.FileName;
                            System.IO.File.WriteAllText(fileName, configString);
                            string fileConfigDelete = configPath;
                            File.WriteAllText(configPath, "");
                            Directory.Delete(mainPath + "/lang", true);
                            instalConfig.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }

        private void instalConfig_Click(object sender, RoutedEventArgs e)
        {
            checkIfGameIsRunning();
            if (!gameRunnig)
            {
                goInstal();
            }
        }

        public async void goInstal()
        {
            readFiles();
            myProgressBar.Visibility = Visibility.Visible;
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke((Action)(() => {
                    var InstalSavedConfig = new InstalSavedConfig(configText.Text, menuPath, uiPath, uiString, menuString, configString, configPath,this);
                }));
            });
        }

        public void stopProgress()
        {
            myProgressBar.Visibility = Visibility.Hidden;
            instalConfig.Visibility = Visibility.Hidden;
        }

        private void helpMe_Click(object sender, RoutedEventArgs e)
        {
            donate don = new donate();
            don.ShowDialog();
        }
    }
}
