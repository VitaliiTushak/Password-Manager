using System.Windows;
using PasswordManagerWPF.MVVM.ViewModel.Auth;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var navigationService = new CustomNavigationService();
        navigationService.NavigateTo(typeof(LoginViewModel));
    }
}