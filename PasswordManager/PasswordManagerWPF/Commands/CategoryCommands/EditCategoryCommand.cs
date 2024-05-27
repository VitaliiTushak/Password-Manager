using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.CategoryCommands
{
    public class EditCategoryCommand(Category category) : CategoryCommand(category)
    {
        public override bool CanExecute()
        {
            return CategoryValidator.IsCategoryNameValid(Category.Name) &&
                   CategoryValidator.IsCategoryNameUnique(Category.Name);
        }

        public override void Execute()
        {
            CategoryRepository.UpdateItem(Category);
        }
    }
}