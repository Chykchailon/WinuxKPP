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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string confirm = confBox.Password.Trim();
            string email = tbMail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                tbLogin.ToolTip = "Некорректный ввод";
                tbLogin.Background = Brushes.Red;
            } else if (pass.Length < 8)
            {
                passBox.ToolTip = "Некорректный ввод";
                passBox.Background = Brushes.Red;
            } else if (pass != confirm)
            {
                confBox.ToolTip = "Некорректный ввод";
                confBox.Background = Brushes.Red;
            } else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                tbMail.ToolTip = "Некорректный ввод";
                tbMail.Background = Brushes.Red;
            }
            else
            {
                tbLogin.ToolTip = "";
                tbLogin.Background = Brushes.LightGreen;

                passBox.ToolTip = "";
                passBox.Background = Brushes.LightGreen;
                
                confBox.ToolTip = "";
                confBox.Background = Brushes.LightGreen;
                
                tbMail.ToolTip = "";
                tbMail.Background = Brushes.LightGreen;

                User user = new User(login,email,pass);

                db.Users.Add(user);
                db.SaveChanges();

            }
        }

        private void In_Change(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
