using System.ComponentModel.DataAnnotations;

namespace PasswordManagerWPF.MVVM.Model;

public class SecurityMethod(string name, string description)
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
}