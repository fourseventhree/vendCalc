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
using System.Collections;

namespace niko_vend
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoTo1_Click(object sender, RoutedEventArgs e)
        {
            bool isWindowOpened = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _1)
                {
                    isWindowOpened = true;
                    w.Activate();
                }
            }

            if (!isWindowOpened)
            {
                _1 w = new _1();
                w.Show();
            }
            this.Close();
        }       

        private void GoTo1CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _1C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _1C w = new _1C();
                w.Show();
            }
            this.Close();
        }

        private void GoTo2_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _2)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _2 w = new _2();
                w.Show();
            }
            this.Close();
        }

        private void GoTo2CHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool iwo = false;

                foreach (Window w in App.Current.Windows)
                {
                    if (w is _2C)
                    {
                        w.Activate();
                        iwo = true;
                    }
                }

                if (!iwo)
                {
                    _2C w = new _2C();
                    w.Show();
                }
                this.Close();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void GoTo3_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _3)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _3 w = new _3();
                w.Show();
            }
            this.Close();
        }

        private void GoTo3CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _3C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _3C w = new _3C();
                w.Show();
            }
            this.Close();
        }

        private void GoTo4_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _4)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _4 w = new _4();
                w.Show();
            }
            this.Close();
        }

        private void GoTo4CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _4C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _4C w = new _4C();
                w.Show();
            }
            this.Close();
        }

        private void GoTo5_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _5)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _5 w = new _5();
                w.Show();
            }
            this.Close();
        }
        private void GoTo5CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _5C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _5C w = new _5C();
                w.Show();
            }
            this.Close();
        }

        private void GoTo6_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _6)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _6 w = new _6();
                w.Show();
            }
            this.Close();
        }

        private void GoTo6CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _6C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _6C w = new _6C();
                w.Show();
            }
            this.Close();
        }

        private void GoTo7_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _7)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _7 w = new _7();
                w.Show();
            }
            this.Close();
        }

        private void GoTo7CHistory_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is _7C)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                _7C w = new _7C();
                w.Show();
            }
            this.Close();
        }

        private void AllVendSum_Click(object sender, RoutedEventArgs e)
        {
            bool iwo = false;

            foreach (Window w in App.Current.Windows)
            {
                if (w is allVendSum)
                {
                    w.Activate();
                    iwo = true;
                }
            }

            if (!iwo)
            {
                allVendSum avs = new allVendSum();
                avs.Show();
            }
            this.Close();
        }
    }
}

