using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.Commands.Category
{
    public class DeleteCategoryCommand : ICategoryCommand
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly MVVM.Model.Category _category;
        private readonly ICategoryValidator _categoryValidator;
        
        public DeleteCategoryCommand(MVVM.Model.Category category)
        {
            _categoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            _categoryValidator = new CategoryValidator(_categoryRepository, new DialogService());
            _category = category;
        }
        public bool CanExecute()
        {
            return _categoryValidator.IsCategoryExists(_category.Name);
        }

        public void Execute()
        {
            _categoryRepository.RemoveItem(_category);
        }
    }
}