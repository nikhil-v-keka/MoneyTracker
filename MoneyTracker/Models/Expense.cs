using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; } = 0;
    }
}
