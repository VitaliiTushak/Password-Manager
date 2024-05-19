using System.Windows;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Auth;
using PasswordManagerWPF.MVVM.View.Menu;

namespace PasswordManagerWPF.Services.Navigation;

public class CustomNavigationService : INavigationService
{
    public void NavigateTo(ObservableObject viewModel)
    {
        var viewType = GetViewType(viewModel.GetType());
        var view = Activator.CreateInstance(viewType);

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            var content = mainWindow.MainFrame.Content;
            
            if (content is MenuView mainPage)
            {
               mainPage.MainProgramFrame.Content = view;
            }
            else
            {
                mainWindow.MainFrame.Content = view;
            }
        }
    }

    private Type GetViewType(Type viewModelType)
    {
        string viewTypeName = viewModelType.FullName!.Replace("ViewModel", "View");
        return Type.GetType(viewTypeName)!;
    }
}