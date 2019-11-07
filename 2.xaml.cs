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
using System.Collections;

namespace niko_vend
{
    /// <summary>
    /// Логика взаимодействия для _2.xaml
    /// </summary>
    public partial class _2 : Window
    {
        public _2()
        {
            InitializeComponent();
            
            initPricesAndDate();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            double res = 0;
            try
            {
                res += Convert.ToDouble(firstCash.Text) - Convert.ToDouble(coffeeGBox.Text) * Convert.ToDouble(coffeeGBox2.Text) - Convert.ToDouble(coffeeSBox.Text) * Convert.ToDouble(coffeeSBox2.Text)
                - Convert.ToDouble(milkBox.Text) * Convert.ToDouble(milkBox2.Text) - Convert.ToDouble(chocBox.Text) * Convert.ToDouble(chocBox2.Text)
                - Convert.ToDouble(teaYBox.Text) * Convert.ToDouble(teaYBox2.Text) - Convert.ToDouble(teaMBox.Text) * Convert.ToDouble(teaMBox2.Text)
                - Convert.ToDouble(sugarBox.Text) * Convert.ToDouble(sugarBox2.Text) - Convert.ToDouble(cupBox.Text) * Convert.ToDouble(cupBox2.Text)
                - Convert.ToDouble(stickBoxW.Text) * Convert.ToDouble(stickBox2W.Text) - Convert.ToDouble(stickBoxP.Text) * Convert.ToDouble(stickBox2P.Text)
                - Convert.ToDouble(wtrBox.Text) * Convert.ToDouble(wtrBox2.Text) - Convert.ToDouble(irelandBox.Text) * Convert.ToDouble(ireland2Box.Text) - Convert.ToDouble(rentBox.Text);
                result.Text = res.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводьте тільки числа. Десяткові числа вводьте через кому ( , ) а не через крапку ( . )!", "Помилкове значення", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Return1_Click(object sender, RoutedEventArgs e)
        {
            bool isWindowOpened = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is MainWindow)
                {
                    isWindowOpened = true;
                    w.Activate();
                }
            }

            if (!isWindowOpened)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            this.Close();
        }

        void SavePrices_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.coffeeGSave = coffeeGBox.Text;
            Properties.Settings.Default.coffeeSSave = coffeeSBox.Text;
            Properties.Settings.Default.milkSave = milkBox.Text;
            Properties.Settings.Default.chocSave = chocBox.Text;
            Properties.Settings.Default.teaYSave = teaYBox.Text;
            Properties.Settings.Default.teaMSave = teaMBox.Text;
            Properties.Settings.Default.sugarSave = sugarBox.Text;
            Properties.Settings.Default.cupSave = cupBox.Text;
            Properties.Settings.Default.stickWSave = stickBoxW.Text;
            Properties.Settings.Default.stickPSave = stickBoxP.Text;
            Properties.Settings.Default.wtrSave = wtrBox.Text;
            Properties.Settings.Default.irelandSave = irelandBox.Text;

            Properties.Settings.Default.Save();
            MessageBox.Show("Ціни збережені.", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void AddHistory_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (date.SelectedDate.ToString() != "")
                {
                    Properties.Settings.Default.string2C += $"%{ date.SelectedDate }\nЗагальна сума: { firstCash.Text}; чистий прибуток: { result.Text}.\n--------------------------------------------------------";
                    MessageBox.Show("Успішно додано в історію.", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Виберіть дату.", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            Properties.Settings.Default.Save();

        }
        private void initPricesAndDate()
        {
            coffeeGBox.Text = (coffeeGBox.Text = Properties.Settings.Default.coffeeGSave) == "" ? "0" : Properties.Settings.Default.coffeeGSave;
            coffeeSBox.Text = (coffeeSBox.Text = Properties.Settings.Default.coffeeSSave) == "" ? "0" : Properties.Settings.Default.coffeeSSave;
            milkBox.Text = (milkBox.Text = Properties.Settings.Default.milkSave) == "" ? "0" : Properties.Settings.Default.milkSave;
            chocBox.Text = (chocBox.Text = Properties.Settings.Default.chocSave) == "" ? "0" : Properties.Settings.Default.chocSave;
            teaYBox.Text = (teaYBox.Text = Properties.Settings.Default.teaYSave) == "" ? "0" : Properties.Settings.Default.teaYSave;
            teaMBox.Text = (teaMBox.Text = Properties.Settings.Default.teaMSave) == "" ? "0" : Properties.Settings.Default.teaMSave;
            sugarBox.Text = (sugarBox.Text = Properties.Settings.Default.sugarSave) == "" ? "0" : Properties.Settings.Default.sugarSave;
            cupBox.Text = (cupBox.Text = Properties.Settings.Default.cupSave) == "" ? "0" : Properties.Settings.Default.cupSave;
            stickBoxW.Text = (stickBoxW.Text = Properties.Settings.Default.stickWSave) == "" ? "0" : Properties.Settings.Default.stickWSave;
            stickBoxP.Text = (stickBoxP.Text = Properties.Settings.Default.stickPSave) == "" ? "0" : Properties.Settings.Default.stickPSave;
            wtrBox.Text = (wtrBox.Text = Properties.Settings.Default.wtrSave) == "" ? "0" : Properties.Settings.Default.wtrSave;
            irelandBox.Text = (irelandBox.Text = Properties.Settings.Default.irelandSave) == "" ? "0" : Properties.Settings.Default.irelandSave;

            date.Text = DateTime.Now.ToString();
        }
    }
}
