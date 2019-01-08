namespace Barcoin.Client.Model
{
    public class Balance
    {
        public Transaction Transaction { get; set; }

        public double PrincipalBalance { get; set; }

        public double AccruedInterest { get; set; }

        public double InterestBalance { get; set; }

        public double PrincipalPaid { get; set; }

        public double InterestPaid { get; set; }

        public double TotalOwed { get; set; }
    }
}
