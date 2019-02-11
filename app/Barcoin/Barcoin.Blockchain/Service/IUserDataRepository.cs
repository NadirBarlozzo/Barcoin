using Barcoin.Blockchain.Model;

namespace Barcoin.Blockchain.Service
{
    public interface IUserDataRepository : IBaseRepository<User>
    {
        User Get(string username);

        void Update(User item);

        void Delete(int id);
    }
}
