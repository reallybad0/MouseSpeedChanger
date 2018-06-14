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
        //
        [DllImport("User32.dll")]
        public static extern int SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
    
        //
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

        private const uint SPI_GETMOUSESPEED = 0x0070;
        public MainWindow()
        {

            InitializeComponent();
            //Progress bar setup
            
            PB.Maximum = 20;

            //Current mouse sensitivity
            uint currentMouseSensitivity = getCurrentMouseSensitivity();
            PB.Value = currentMouseSensitivity;

            PB.Minimum = 1;


            //Label setup            
            SP.Content = PB.Value.ToString();

        }

        private void SpeedBTN_Click(object sender, RoutedEventArgs e)
        {
            //Changes speed to default
            int res = SystemParametersInfo(113, 0, 10, 0);
            PB.Value = 10;
        }

        private void PB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Change the speed when progress bar moves
            UInt32 uservalue = (UInt32)PB.Value;
            SP.Content = uservalue.ToString();

            int res = SystemParametersInfo(113, 0, uservalue, 0);
        }
        private static uint getCurrentMouseSensitivity()
        {
            
            uint result = 0;
            //Get the mouse speed
            SystemParametersInfo(SPI_GETMOUSESPEED, 0x0, ref result, 0x0);
            return result;

        }
    } 
}
