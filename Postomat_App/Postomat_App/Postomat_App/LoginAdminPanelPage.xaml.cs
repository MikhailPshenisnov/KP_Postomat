using System;
using System.Windows;
using System.Windows.Controls;

namespace Postomat_App;

// Класс для окна входа в режим администратора
public partial class LoginAdminPanelPage : Page
{
    public MainWindow ProgramWindow { get; set; }
    
    public LoginAdminPanelPage()
    {
        InitializeComponent();
    }

    // Проверка пароля
    private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var status = Postomat.CheckAdminPassword(PasswordTextBox.Text);
            if (!status)
            {
                throw new Exception("Wrong password!");
            }

            ProgramWindow.OpenAdminPanelPage();
        }
        catch (Exception exception)
        {
            MessageBox.Show("Wrong password!\n" +
                            $"{exception.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        PasswordTextBox.Text = "Password...";
    }

    // Возврат наглавную
    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        ProgramWindow.OpenStartPage();
    }
}