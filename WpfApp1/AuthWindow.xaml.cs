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
using System.Windows.Interop;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string pass = passBox.Password.Trim();


            if (login.Length < 5)
            {
                tbLogin.ToolTip = "Некорректный ввод";
                tbLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 8)
            {
                passBox.ToolTip = "Некорректный ввод";
                passBox.Background = Brushes.Red;
            }
            else
            {
                tbLogin.ToolTip = "";
                tbLogin.Background = Brushes.LightGreen;

                passBox.ToolTip = "";
                passBox.Background = Brushes.LightGreen;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    UserPage userPage = new UserPage();
                    userPage.Show();
                    Close();
                }
                else
                {
                    tbLogin.Background = Brushes.Red;
                    passBox.Background = Brushes.Red;
                }
            }
        }

        private void Reg_Chenge(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void TopBor_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    var windowMode = this.ResizeMode;
                    if (this.ResizeMode != ResizeMode.NoResize)
                    {
                        this.ResizeMode = ResizeMode.NoResize;
                    }

                    this.UpdateLayout();

                    DragMove();


                    if (this.ResizeMode != windowMode)
                    {
                        this.ResizeMode = windowMode;
                    }

                    this.UpdateLayout();
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
