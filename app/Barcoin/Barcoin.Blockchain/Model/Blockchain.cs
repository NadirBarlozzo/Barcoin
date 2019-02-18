using Barcoin.Blockchain.Interface;
using Barcoin.Blockchain.Service;
using System.Collections.Generic;

namespace Barcoin.Blockchain.Model
{
    public class Blockchain : IBlockchain
    {
        public List<Block> Blocks { get; set; }

        public BlockRepository BlockRepository { get; set; }

        public Blockchain()
        {
            BlockRepository = new BlockRepository();

            Blocks = BlockRepository.Get();
        }

        public void AcceptBlock(Block block)
        {
            BlockRepository.Add(block);
        }

        public bool IsValid()
        {
            bool isValid = true;

            foreach (Block block in Blocks)
            {
                if (!block.IsValid())
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
