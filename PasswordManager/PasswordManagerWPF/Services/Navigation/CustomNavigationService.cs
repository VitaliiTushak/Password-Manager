using System.Reflection;
using System.Windows;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.View.Menu;

namespace PasswordManagerWPF.Services.Navigation;

public class CustomNavigationService : INavigationService
{
    public void NavigateTo(Type viewModelType, object? parameter = null)
    {
        var viewModel = CreateViewModelInstance(viewModelType, parameter);
        if (viewModel == null)
            throw new ArgumentException("Invalid ViewModel type", nameof(viewModelType));

        var view = CreateViewInstance(viewModelType);
        if (view == null)
            throw new ArgumentException("Could not create View", nameof(viewModelType));

        SetViewDataContext(view, viewModel);

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            SetMainWindowContent(mainWindow, view);
        }
    }

    private ObservableObject? CreateViewModelInstance(Type viewModelType, object? parameter)
    {
        var constructor = GetViewModelConstructor(viewModelType, parameter);
        if (constructor != null)
            return constructor.Invoke(new[] { parameter }) as ObservableObject;

        constructor = viewModelType.GetConstructor(Type.EmptyTypes);
        return constructor?.Invoke(null) as ObservableObject;
    }

    private ConstructorInfo? GetViewModelConstructor(Type viewModelType, object? parameter)
    {
        var constructors = viewModelType.GetConstructors();

        return constructors.FirstOrDefault(ctor =>
        {
            var parameters = ctor.GetParameters();
            return parameters.Length == 1 && parameters[0].ParameterType == parameter?.GetType();
        });
    }

    private object? CreateViewInstance(Type viewModelType)
    {
        var viewType = GetViewType(viewModelType);
        return Activator.CreateInstance(viewType);
    }

    private void SetViewDataContext(object view, object dataContext)
    {
        if (view is FrameworkElement frameworkElement)
        {
            frameworkElement.DataContext = dataContext;
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
        return Type.GetType(viewTypeName) ?? throw new ArgumentException("Could not find View type", nameof(viewModelType));
    }
}