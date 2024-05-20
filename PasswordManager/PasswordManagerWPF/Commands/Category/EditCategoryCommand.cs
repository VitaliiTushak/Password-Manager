using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.Commands.Category
{
    public class EditCategoryCommand : ICategoryCommand
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly MVVM.Model.Category _category;
        private readonly ICategoryValidator _categoryValidator;
        
        public EditCategoryCommand(MVVM.Model.Category category)
        {
            _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            _categoryValidator = new CategoryValidator(_categoryRepository, new DialogService());
            _category = category;
        }
        public bool CanExecute()
        {
            return _categoryValidator.IsCategoryNameValid(_category.Name) &&
                   _categoryValidator.IsCategoryNameUnique(_category.Name);
        }

        public void Execute()
        {
            _categoryRepository.UpdateItem(_category);
        }
    }
}