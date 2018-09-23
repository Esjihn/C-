using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        const string Username = "Matt";
        const string Password = "test";
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserName != null &&
                UserName.Text == Username &&
                PassWord != null &&
                PassWord.Password == Password)
            {
                MainWindow mw1 = new MainWindow();
                mw1.Show();
                this.Close();
            }
            else
            {
                UserName.Clear();
                PassWord.Clear();
                MessageBox.Show("Login Credentials are incorrect!");
            }
        }
    }
}
