using Barcoin.Blockchain.Model;

namespace Barcoin.Blockchain.Service
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string username);

        void Update(User item);

        void Delete(int id);
    }
}
