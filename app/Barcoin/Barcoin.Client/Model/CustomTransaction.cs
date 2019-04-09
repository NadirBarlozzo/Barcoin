using Barcoin.Blockchain.Model;

namespace Barcoin.Client.Model
{
    public class CustomTransaction : Transaction
    {
        public string Hash { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public new string Timestamp { get; set; }

        public string Color { get; set; }
    }
}
