using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Dialog;

namespace PasswordManagerWPF.Utilities.Category;

public class CategoryValidator(CategoryRepository categoryRepository, IDialogService dialogService) : ICategoryValidator
{
    private void ShowErrorMessage(string message, string title)
    {
        dialogService.ShowMessage(message, title, DialogType.Error);
    }

    public bool IsCategoryNameValid(string name)
    {
        if (!StringValidator.IsStringValid(name))
        {
            ShowErrorMessage("Введіть назву категорії", "Помилка");
            return false;
        }
        
        return true;
    }

    public bool IsCategoryNameUnique(string name)
    {
        if (categoryRepository.GetCategoryByName(name) != null!)
        {
            ShowErrorMessage("Така категорія вже існує", "Помилка");
            return false;
        }
        
        return true;
    }

    public bool IsCategoryExists(string name)
    {
        if (categoryRepository.GetCategoryByName(name) == null!)
        {
            ShowErrorMessage("Такої категорії не існує", "Помилка");
            return false;
        }
        
        return true;
    }
}