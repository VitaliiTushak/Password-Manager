using System.Windows;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Menu;

namespace PasswordManagerWPF.Services.Navigation
{
    public class CustomNavigationService : INavigationService
    {
        public void NavigateTo(ObservableObject viewModel)
        {
            var viewType = GetViewType(viewModel.GetType());
            var view = Activator.CreateInstance(viewType);
            
            if (view is null)
                return;

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                SetMainWindowContent(mainWindow, view);
            }
        }

        private void SetMainWindowContent(MainWindow mainWindow, object view)
        {
            var content = mainWindow.MainFrame.Content;

            if (content is MenuView mainPage)
                mainPage.MainProgramFrame.Content = view;
            else
                mainWindow.MainFrame.Content = view;
        }

        private Type GetViewType(Type viewModelType)
        {
            string viewTypeName = viewModelType.FullName!.Replace("ViewModel", "View");
            return Type.GetType(viewTypeName)!;
        }
    }
}