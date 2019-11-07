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
    /// Логика взаимодействия для _7C.xaml
    /// </summary>
    public partial class _7C : Window
    {
        public _7C()
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

        private void _1CClear_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Очистити історію?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                result = MessageBox.Show("Ви впевнені що хочете очистити історію?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _testCListBox.Items.Clear();
                    Properties.Settings.Default.string7C = "";
                    Properties.Settings.Default.Save();
                }

            }
        }

        private void _1COneClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_testCListBox.SelectedItem != null)
                {
                    var result = MessageBox.Show("Видалити вибрану історію?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        string mtResult, mcResult;
                        int mIndexStartT, mIndexEndT, mIndexEndC, mIndexStartС;
                        double tTMP, cTMP;

                        mIndexStartT = _testCListBox.SelectedItem.ToString().IndexOf("сума: ") + 5;
                        mIndexEndT = _testCListBox.SelectedItem.ToString().IndexOf(';', mIndexStartT) - mIndexStartT;
                        mtResult = _testCListBox.SelectedItem.ToString().Substring(mIndexStartT, mIndexEndT);
                        tTMP = Convert.ToDouble(tSumAllTime.Text) - Convert.ToDouble(mtResult);
                        tSumAllTime.Text = tTMP.ToString();

                        mIndexStartС = _testCListBox.SelectedItem.ToString().IndexOf("ток: ") + 5;
                        mIndexEndC = _testCListBox.SelectedItem.ToString().IndexOf('.', mIndexStartС) - mIndexStartС;
                        mcResult = _testCListBox.SelectedItem.ToString().Substring(mIndexStartС, mIndexEndC);
                        cTMP = Convert.ToDouble(cSumAllTime.Text) - Convert.ToDouble(mcResult);
                        cSumAllTime.Text = cTMP.ToString();

                        int index = Properties.Settings.Default.string7C.IndexOf(_testCListBox.SelectedItem.ToString());
                        Properties.Settings.Default.string7C.Remove(index - 1, 1);
                        Properties.Settings.Default.string7C = Properties.Settings.Default.string7C.Remove(index - 1, _testCListBox.SelectedItem.ToString().Length + 1);
                        Properties.Settings.Default.Save();

                        _testCListBox.Items.Remove(_testCListBox.SelectedItem);
                    }
                }
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

        private void showHistory()
        {
            string[] items = Properties.Settings.Default.string7C.Split('%');

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
