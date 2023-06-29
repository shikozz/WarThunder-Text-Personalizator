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
    /// Логика взаимодействия для Instruction.xaml
    /// </summary>
    public partial class Instruction : Window
    {
        public Instruction()
        {
            InitializeComponent();
            setLanguage();
        }

        private void setLanguage()
        {
            languageResource lr = new languageResource(Properties.Settings.Default.Language);
            instructionMain.Content = lr.instructionMain;
            first.Text = lr.first;
            firstAdd.Content = lr.firstadd;
            second.Text = lr.second;
            secondAdd.Content = lr.secondAdd;
            third.Text = lr.third;
            fourth.Text = lr.fourth;
            fifth.Text = lr.fifth;
            fifthAdd.Text= lr.fifthAdd;
            sixth.Text = lr.sixth;
            sixthdotone.Text = lr.sixthdotone;
            closeInstr.Content = lr.closeInstr;
            if(Properties.Settings.Default.Language=="ru")
            {
                img1.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr1.png"));
                img2.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr2.png"));
                img3.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr3.png"));
            }
            else
            {
                img1.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr1_eng.png"));
                img2.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr2_eng.png"));
                img3.Source = new BitmapImage(
                    new Uri("pack://application:,,,/WTTextPersonalizator;component/instr3_eng.png"));
            }
        }

        private void closeInstr_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowInstruction = false;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
