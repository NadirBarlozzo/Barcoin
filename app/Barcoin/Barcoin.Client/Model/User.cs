using System;

namespace Barcoin.Client.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Address { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
