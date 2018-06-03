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
using System.Runtime.InteropServices;

namespace Mouse
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;
        public const UInt32 SPI_GETMOUSESPEED = 0x0070;

        [DllImport("User32.dll")]
        public static extern int SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
        public MainWindow()
        {

            InitializeComponent();
            PB.Maximum = 20;
            PB.Value = 10;
            PB.Minimum = 1;
            SP.Content = PB.Value.ToString();
            //Set default = int res = SystemParametersInfo(113, 0, 10, 0);
        }

        private void SpeedBTN_Click(object sender, RoutedEventArgs e)
        {

            int res = SystemParametersInfo(113, 0, 10, 0);
            PB.Value = 10;
        }

        private void PB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UInt32 uservalue = (UInt32)PB.Value;
            SP.Content = uservalue.ToString();
            int res = SystemParametersInfo(113, 0, uservalue, 0);
        }
    } 
}
