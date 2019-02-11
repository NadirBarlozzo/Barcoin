using Barcoin.Blockchain.Model;

namespace Barcoin.Blockchain.Interface
{
    public interface IBlockchain
    {
        void AcceptBlock(Block block);

        void IsValid();
    }
}
