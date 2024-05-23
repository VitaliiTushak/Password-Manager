namespace PasswordManagerWPF.MVVM.Model
{
    public class Password
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        
        public Password()
        {
        }
        
        public Password(string name, string value, int userId, int categoryId)
        {
            Name = name;
            Value = value;
            UserId = userId;
            CategoryId = categoryId;
        }
    }
}