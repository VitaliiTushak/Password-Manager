namespace PasswordManagerWPF.Commands.Category;

public class DeleteCustomCommand(MVVM.Model.Category category) : CategoryCommand(category)
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