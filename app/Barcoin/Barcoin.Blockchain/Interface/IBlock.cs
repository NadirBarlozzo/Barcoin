using Barcoin.Blockchain.Model;

namespace Barcoin.Blockchain.Interface
{
    public interface IBlock
    {
        void ComputeHash();

        bool IsValid(bool verbose);
    }
}
