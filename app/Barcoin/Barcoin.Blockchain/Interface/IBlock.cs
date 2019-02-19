using Barcoin.Blockchain.Model;

namespace Barcoin.Blockchain.Interface
{
    public interface IBlock
    {
        void ComputeHash();

        void AssignPool();

        bool IsValid(bool verbose);
    }
}
