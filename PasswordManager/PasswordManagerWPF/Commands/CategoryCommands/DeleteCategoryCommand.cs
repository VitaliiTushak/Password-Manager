using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Commands.CategoryCommands;

public class DeleteCategoryCommand(Category category) : CategoryCommand(category)
{
    public override bool CanExecute()
    {
        return CategoryValidator.IsCategoryExists(Category.Name);
    }

    public override void Execute()
    {
        CategoryRepository.RemoveItem(Category);
    }
}