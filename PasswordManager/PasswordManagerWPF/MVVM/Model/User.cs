namespace PasswordManagerWPF.MVVM.Model;

public class User(int id, string login, string password)
{
    public int Id { get; set; } = id;
    public string Login { get; set; } = login;
    public string Password { get; set; } = password;
}