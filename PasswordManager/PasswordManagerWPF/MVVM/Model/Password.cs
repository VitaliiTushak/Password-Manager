namespace PasswordManagerWPF.MVVM.Model
{
    public class Password(int id, string name, string value, int encryptionMethodId, int userId, int categoryId)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
        public int EncryptionMethodId { get; set; } = encryptionMethodId;
        public int UserId { get; set; } = userId;
        public int CategoryId { get; set; } = categoryId;
    }
}