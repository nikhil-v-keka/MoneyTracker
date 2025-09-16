namespace MoneyTracker.DTOs
{
    public class TransactionCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
    }
}
