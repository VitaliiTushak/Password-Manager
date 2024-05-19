using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.Commands.Category
{
    public class AddCategoryCommand(CategoryRepository categoryRepository, ICategoryValidator categoryValidator,
            MVVM.Model.Category category)
        : ICategoryCommand
    {
        public bool CanExecute()
        {
            return categoryValidator.IsCategoryNameValid(category.Name) &&
                   categoryValidator.IsCategoryNameUnique(category.Name);
        }

        public void Execute()
        {
            categoryRepository.AddItem(category);
        }
    }
}