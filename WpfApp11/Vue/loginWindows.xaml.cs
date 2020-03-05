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

namespace WpfApp11.Vue
{
    /// <summary>
    /// Logique d'interaction pour loginWindows.xaml
    /// </summary>
    public partial class loginWindows : Window
    {
        public loginWindows()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page_main = new MainWindow(this);
            page_main.Show();
            this.Close();
        }
    }
}
