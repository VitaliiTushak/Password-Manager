namespace PasswordManagerWPF.MVVM.Model;

public class Category(string name, int userId)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public int UserId { get; set; } = userId;
}