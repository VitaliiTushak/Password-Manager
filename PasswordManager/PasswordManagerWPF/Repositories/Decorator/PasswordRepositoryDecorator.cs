
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services;

namespace PasswordManagerWPF.Repositories
{
    public class PasswordRepositoryDecorator() : IRepository<Password>
    {
        private readonly IRepository<Password> _repository = null!;
        private static List<Password> _encryptedPasswords = new();
        private static List<string> _encryptedPasswordsValues = new();

        public PasswordRepositoryDecorator(IRepository<Password> repository) : this()
        {
            _repository = repository;
            if (_encryptedPasswords.Count == 0)
            {
                _encryptedPasswords = repository.GetItems().ToList();
                _encryptedPasswordsValues = repository.GetItems().Select(p => p.Value).ToList();
            }
        }
        public void AddItem(Password item)
        {
            item.Value = PasswordEncryptionService.Encrypt(item.Value);
            _repository.AddItem(item);
            _encryptedPasswords.Add(item);
        }

        public void RemoveItem(Password item)
        {
            if (GetItem(item.Id) != null!)
            {
                _repository.RemoveItem(item);
                _encryptedPasswords.Remove(item);
            }
        }

        public void UpdateItem(Password item)
        {
            item.Value = PasswordEncryptionService.Encrypt(item.Value);
            _repository.UpdateItem(item);
            _encryptedPasswords.Remove(item);
            _encryptedPasswords.Add(item);
        }

        public List<Password> GetItems()
        {
            var encryptedPasswords = _repository.GetItems();
        
            foreach (var password in encryptedPasswords.Where(password => _encryptedPasswordsValues.Contains(password.Value)))
            {
                password.Value = PasswordEncryptionService.Decrypt(password.Value);
            }

            return encryptedPasswords;
        }

        public Password GetItem(int id)
        {
            var item = _repository.GetItem(id);
            if (_encryptedPasswordsValues.Contains(item.Value))
            {
                item.Value = PasswordEncryptionService.Decrypt(item.Value);
            }
    
            return item;
        }

    }
}
