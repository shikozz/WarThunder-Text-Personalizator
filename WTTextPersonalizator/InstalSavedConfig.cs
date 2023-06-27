using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WTTextPersonalizator
{
    public class InstalSavedConfig
    {
        public string configString = "";
        public string configPath = "";
        public string menuPath = "";
        public string uiPath = "";
        public string menuString = "";
        public string uiString = "";
        public string configOldString;
        public InstalSavedConfig(string configStr, string menuP, string uiP, string uiStr, string menuStr, string configOldStr, string configP)
        {
            configString = configStr;
            menuPath = menuP;
            uiPath = uiP;
            menuString = menuStr;
            uiString = uiStr;
            configOldString = configOldStr;
            configPath = configP;
            startImporting();
        }
        public void startImporting()
        {
            if (configOldString == "")
            {
                string[] str = configString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string init = "";
                    string change = "";
                    int index = str[i].IndexOf(':');
                    if (index >= 0)
                    {
                        init = str[i].Substring(0, index);
                        change = str[i].Substring(index + 1);
                        //Console.WriteLine(init + "   " + change);
                        goFind(init,change);
                    }
                }
            }
            else
            {
                MessageBox.Show("Текущий конфиг содержит значения, прежде чем загружать старый конфиг, пожалуйста сбросьте текущий через Вышел патч");
                Console.WriteLine(configOldString);
            }
            MessageBox.Show("Конфиг успешно загружен");
        }

        public void reloadFiles()
        {
            using (StreamReader reader = new StreamReader(menuPath))
            {
                menuString = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(uiPath))
            {
                uiString = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(configPath))
            {
                configString = reader.ReadToEnd();
            }
        }

        public void goFind(string init, string gochange)
        {
            string initial = init;
            string change = gochange;
            string res = "";
            int indexFind = 0;
            while(indexFind>=0)
            {
                indexFind = menuString.IndexOf(initial);
                if (indexFind >= 0)
                {
                    res = menuString.Remove(indexFind, initial.Length).Insert(indexFind, change);
                    File.WriteAllText(menuPath, res);


                    int indexConfig = configString.IndexOf(initial);
                    if(indexConfig>=0)
                    {
                        
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(configPath))
                        {
                            sw.Write(initial + ":" + change + "|");
                        }
                    }
                    //MessageBox.Show("Запись "+change+" вместо "+initial);
                    reloadFiles();
                }
                else
                {
                    int indexFind1 = uiString.IndexOf(initial);
                    if (indexFind1 >= 0)
                    {
                        res = uiString.Remove(indexFind1, initial.Length).Insert(indexFind1, change);
                        File.WriteAllText(uiPath, res);
                        int indexConfig = configString.IndexOf(initial);
                        if (indexConfig >= 0)
                        {
                            
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(configPath))
                            {
                                sw.Write(initial + ":" + change + "|");
                            }
                        }
                        //MessageBox.Show("Запись " + change + " вместо " + initial);
                        reloadFiles();
                    }
                    else
                    {
                        //MessageBox.Show("Ошибка записи " + change + " вместо " + initial);
                    }
                }
            }        
        }
    }
}
