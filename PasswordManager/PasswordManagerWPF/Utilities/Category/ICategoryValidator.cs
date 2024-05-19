namespace PasswordManagerWPF.Utilities.Category;

public interface ICategoryValidator
{
    bool IsCategoryNameValid(string name);
    bool IsCategoryNameUnique(string name);
    bool IsCategoryExists(string name);
}