using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Barcoin.Client.Model
{
    public class CustomTransaction
    {
        public int Id { get; set; }

        public string Hash { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public float Amount { get; set; }

        public string Timestamp { get; set; }

        public string Color { get; set; }
    }
}
