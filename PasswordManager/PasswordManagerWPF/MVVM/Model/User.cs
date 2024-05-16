namespace PasswordManagerWPF.MVVM.Model;

public class User(string login, string password)
{
    public int Id { get; set; }
    public string Login { get; set; } = login;
    public string Password { get; set; } = password;
}