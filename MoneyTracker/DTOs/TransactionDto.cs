namespace MoneyTracker.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
    }
}
