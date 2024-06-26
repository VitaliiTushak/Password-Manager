using System.Windows.Input;
using PasswordManagerWPF.Commands.CategoryCommands;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Services.Navigation;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.Categories
{
    public class EditCategoryViewModel : ObservableObject
    {
        //Observable Properties
        private Category _category = null!;
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        
        //Fields
        private static Category StaticCategory { get; set; } = null!;
        private readonly ICategoryValidator _categoryValidator;
        private readonly INavigationService _navigationService;
        
        //Commands
        public ICommand EditCategoryCommand { get; set; }

        public EditCategoryViewModel(Category category = null!)
        {
            if (StaticCategory == null!)
                StaticCategory = category;
            
            EditCategoryCommand = new RelayCommand(EditCategoryCommandExecute);

            var categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            IDialogService dialogService = new DialogService();
            _categoryValidator = new CategoryValidator(categoryRepository, dialogService);
            _navigationService = new CustomNavigationService();
            
            Category = StaticCategory;
        }

        // Command Handlers
        private void EditCategoryCommandExecute(object? obj)
        {
            if (obj is Category category)
            {
                if (ValidateAndExecuteEdit(category))
                {
                    _navigationService.NavigateTo(typeof(CategoriesViewModel));
                }
            }
        }
        
        //Methods
        private bool ValidateAndExecuteEdit(Category category)
        {
            var result = _categoryValidator.IsCategoryNameValid(category.Name);
            if (result)
            {
                var editCategoryCommand = new EditCategoryCommand(category);
                editCategoryCommand.Execute();
                return true;
            }
            return false;
        }
    }
}
