using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PasswordManagerWPF.Database;

namespace PasswordManagerWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    ApplicationContext context = new ApplicationContext();
    
}