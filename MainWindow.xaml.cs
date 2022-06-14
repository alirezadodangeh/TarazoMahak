using Newtonsoft.Json;
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

namespace TarazoMahak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Mahak Mahak;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//تنظیمات اولیه
            try
            {
                Mahak = new Mahak(int.Parse(txtCom.Text));
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {//تست اتصال

            try
            {
                txtLog.Text += "Connected: " + await Mahak.Connected();
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }

            try
            {
                txtLog.Text += "isActive: " + Mahak.Scale.isActive;
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }

            try
            {
                txtLog.Text += "isAvailable: " + Mahak.Scale.isAvailable;
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }

            try
            {
                txtLog.Text += "isPortOpen: " + Mahak.Scale.isPortOpen;
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {//خوندن وزن
            try
            {
                txtLog.Text += "GetWeight: " + await Mahak.GetWeight();
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//خروجی جیسان برای برسی بیشتر
            try
            {
                string json = JsonConvert.SerializeObject(Mahak.Scale);

                txtLog.Text += "json: " + json;
                txtLog.Text += "\n\r";
            }
            catch (Exception ex)
            {
                txtLog.Text += ex.Message;
                txtLog.Text += "\n\r";
            }
        }
    }
}
