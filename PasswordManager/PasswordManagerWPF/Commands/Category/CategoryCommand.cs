using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Utilities.Category;

namespace PasswordManagerWPF.Commands.Category
{
    public abstract class CategoryCommand
    {
        protected readonly MVVM.Model.Category Category;
        protected readonly CategoryRepository CategoryRepository;
        protected readonly CategoryValidator CategoryValidator;

        protected CategoryCommand(MVVM.Model.Category category)
        {
            Category = category;
            CategoryRepository = RepositoryFactory.GetInstance().GetCategoryRepository();
            IDialogService dialogService = new DialogService();
            CategoryValidator = new CategoryValidator(CategoryRepository, dialogService);
        }

        public abstract bool CanExecute();
        public abstract void Execute();
    }
}