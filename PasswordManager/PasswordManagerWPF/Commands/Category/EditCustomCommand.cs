namespace PasswordManagerWPF.Commands.Category
{
    public class EditCustomCommand(MVVM.Model.Category category) : CategoryCommand(category)
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