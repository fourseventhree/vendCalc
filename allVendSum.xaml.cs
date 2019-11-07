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

namespace niko_vend
{
    /// <summary>
    /// Логика взаимодействия для allVendSum.xaml
    /// </summary>
    public partial class allVendSum : Window
    {
        public allVendSum()
        {
            InitializeComponent();
            showHistory();
            calcTotalAndClearSum();
        }
        private void _1CReturn_Click(object sender, RoutedEventArgs e)
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
                MainWindow w = new MainWindow();
                w.Show();
            }
            this.Close();
        }

        private void calcTotalAndClearSum()
        {
            try
            {
                string result;
                double sum = 0;
                foreach (var item in _testCListBox.Items)
                {
                    int startIndex = item.ToString().IndexOf("сума: ") + 5;
                    int endIndex = item.ToString().IndexOf(';', startIndex) - startIndex;
                    result = item.ToString().Substring(startIndex, endIndex);
                    sum += Convert.ToDouble(result);
                }
                tSumAllTime.Text = sum.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                string result;
                double sum = 0;
                foreach (var item in _testCListBox.Items)
                {
                    int startIndex = item.ToString().IndexOf("ток: ") + 5;
                    int endIndex = item.ToString().IndexOf('.', startIndex) - startIndex;
                    result = item.ToString().Substring(startIndex, endIndex);
                    sum += Convert.ToDouble(result);
                }
                cSumAllTime.Text = sum.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            double tSum = 0, cSum = 0;
            string tResult, cResult, lbDateString;
            try
            {
                DateTime dtStart = DateTime.Parse(startDate.ToString());
                DateTime dtEnd = DateTime.Parse(endDate.ToString());
                if (dtStart > dtEnd)
                {
                    MessageBox.Show("Початкова дата періоду не може бути більша за кінцеву.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tResultBox.Text = "";
                    cResultBox.Text = "";
                }
                else
                {
                    foreach (var item in _testCListBox.Items)
                    {
                        lbDateString = item.ToString().Substring(0, 10);
                        DateTime lbDate = DateTime.Parse(lbDateString.ToString());

                        if (lbDate >= dtStart && lbDate <= dtEnd)
                        {
                            int startIndexT = item.ToString().IndexOf("сума: ") + 5;
                            int endIndexT = item.ToString().IndexOf(';', startIndexT) - startIndexT;
                            tResult = item.ToString().Substring(startIndexT, endIndexT);
                            tSum += Convert.ToDouble(tResult);

                            int startIndexC = item.ToString().IndexOf("ток: ") + 5;
                            int endIndexC = item.ToString().IndexOf('.', startIndexC) - startIndexC;
                            cResult = item.ToString().Substring(startIndexC, endIndexC);
                            cSum += Convert.ToDouble(cResult);

                        }
                    }
                    tResultBox.Text = tSum.ToString();
                    cResultBox.Text = cSum.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Виберіть початкову та кінцеву дати періоду.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void showHistory()
        {
            Properties.Settings.Default.stringAllVend = Properties.Settings.Default.string1C + Properties.Settings.Default.string2C + Properties.Settings.Default.string3C + Properties.Settings.Default.string4C +
                Properties.Settings.Default.string5C + Properties.Settings.Default.string6C + Properties.Settings.Default.string7C;

            string[] items = Properties.Settings.Default.stringAllVend.Split('%');

            foreach (var item in items)
            {
                if (item.ToString() != "")
                {
                    _testCListBox.Items.Add(item);
                }
            }
        }        
    }
}
