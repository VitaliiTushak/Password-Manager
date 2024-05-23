using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using PasswordManagerWPF.Commands.Passwords;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.GenerationMethods.StrategyFactory;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;

public class AddPasswordViewModel : ObservableObject
{
    private string _passwordName = null!;
    private string _passwordValue = null!;
    private Category _selectedCategory = null!;
    private StrategyName _selectedStrategy;
    private string _length = null!;

    public string PasswordName
    {
        get => _passwordName;
        set
        {
            if (_passwordName != value)
            {
                _passwordName = value;
                OnPropertyChanged(nameof(PasswordName));
            }
        }
    }
    public string PasswordValue
    {
        get => _passwordValue;
        set
        {
            if (_passwordValue != value)
            {
                _passwordValue = value;
                OnPropertyChanged(nameof(PasswordValue));
            }
        }
    }
    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
    }
    public StrategyName SelectedStrategy
    {
        get => _selectedStrategy;
        set
        {
            if (_selectedStrategy != value)
            {
                _selectedStrategy = value;
                OnPropertyChanged(nameof(SelectedStrategy));
            }
        }
    }
    
    public string Length
    {
        get => _length;
        set
        {
            if (_length != value)
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }
    }
    
    public ObservableCollection<Category> Categories { get; set; }
    public List<StrategyName> PasswordGenerationStrategies { get; set; }
    private readonly CategoryRepository _categoryRepository;
    private readonly INavigationService _navigationService;
    
    
    public ICommand AddPasswordCommand { get; set; }
    public ICommand GeneratePasswordCommand { get; set; }
    
    public AddPasswordViewModel()
    {
        AddPasswordCommand = new RelayCommand(AddPasswordCommandExecute);
        GeneratePasswordCommand = new RelayCommand(GeneratePasswordCommandExecute);

        _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
        Categories = new ObservableCollection<Category>(_categoryRepository.GetItems());
        PasswordGenerationStrategies = new List<StrategyName>
        {
            StrategyName.Simple,
            StrategyName.Complex,
            StrategyName.Numeric,
            StrategyName.Alphanumeric,
            StrategyName.Pronounceable
        };

        _navigationService = new CustomNavigationService();
    }

    private void AddPasswordCommandExecute(object? obj)
    {
        if (SelectedCategory != null!)
        {
            var password = new Password(
                PasswordName,
                PasswordValue,
                UserRepository.CurrentUser.Id, 
                _categoryRepository.GetCategoryByName(SelectedCategory.Name).Id
                );

            var addPasswordCommand = new AddPasswordCommand(password);
            addPasswordCommand.Execute();
            
            _navigationService.NavigateTo(new PasswordsViewModel());
        }
    }
    
    private void GeneratePasswordCommandExecute(object? obj)
    {
        if (obj is StrategyName strategyName)
        {
            var factory = new PasswordGenerationStrategyFactory();
            var strategy = factory.CreateStrategy(strategyName);
            PasswordValue = strategy.GeneratePassword(int.Parse(Length));
        }
    }
}