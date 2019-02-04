using Barcoin.Client.Model;

namespace Barcoin.Client.Service
{
    interface IUserDataRepository : IBaseRepository<User>
    {
        User Get(string username);        
    }
}
