namespace PasswordManagerWPF.MVVM.Model
{
    public class Password(string name, string value, int userId, int categoryId)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
        public int UserId { get; set; } = userId;
        public int CategoryId { get; set; } = categoryId;
    }
}