using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.Commands.Category
{
    public class DeleteCategoryCommand(CategoryRepository categoryRepository, ICategoryValidator categoryValidator,
            MVVM.Model.Category category)
        : ICategoryCommand
    {
        public bool CanExecute()
        {
            return categoryValidator.IsCategoryExists(category.Name);
        }

        public void Execute()
        {
            categoryRepository.RemoveItem(category);
        }
    }
}