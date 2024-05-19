using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Services.Dialog;

namespace PasswordManagerWPF.Utilities.Category;

public class CategoryValidator(CategoryRepository categoryRepository, DialogService dialogService) : ICategoryValidator
{
    public bool IsCategoryNameValid(string name)
    {
        if (!StringValidator.IsStringValid(name))
        {
            dialogService.ShowMessage("Введіть назву категорії", "Помилка", DialogType.Error);
            return false;
        }
        
        return true;
    }

    public bool IsCategoryNameUnique(string name)
    {
        if (categoryRepository.GetCategoryByName(name) != null!)
        {
            dialogService.ShowMessage("Така категорія вже існує", "Помилка", DialogType.Error);
            return false;
        }
        
        return true;
    }

    public bool IsCategoryExists(string name)
    {
        if (categoryRepository.GetCategoryByName(name) == null!)
        {
            dialogService.ShowMessage("Такої категорії не існує", "Помилка", DialogType.Error);
            return false;
        }
        
        return true;
    }
}