namespace PasswordManagerWPF.MVVM.Model;

public class Category(int id, string name, string color)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Color { get; set; } = color;
}