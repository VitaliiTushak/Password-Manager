using PasswordManagerWPF.Database;
using PasswordManagerWPF.MVVM.Model;

namespace PasswordManagerWPF.Repositories.RepositoryFactory
{
    public class RepositoryFactory
    {
        private static RepositoryFactory? _repositoryFactory;

        private readonly ApplicationContext _context;

        private static readonly object Lock = new object();

        public static RepositoryFactory GetInstance(string configuration)
        {
            if (_repositoryFactory == null)
            {
                lock (Lock)
                {
                    _repositoryFactory ??= new RepositoryFactory();
                }
            }

            return _repositoryFactory;
        }

        private RepositoryFactory()
        {
            _context = new ApplicationContext();
        }

        public UserRepository GetUserRepository() => UserRepository.GetInstance(_context);
    }
}