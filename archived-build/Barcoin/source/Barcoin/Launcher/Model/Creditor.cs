namespace Launcher.Model
{
    public class Creditor
    {
        public int CreditLineID { get; set; }

        public string CreditorName { get; set; }

        public string CreditorSurname { get; set; }

        public string Description { get; set; }

        public int DiemRate { get; set; }

        public double DefaultInterestRate { get; set; }
    }
}
