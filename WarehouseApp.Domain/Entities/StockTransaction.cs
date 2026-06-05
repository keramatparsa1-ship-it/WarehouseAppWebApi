namespace WarehouseApp.Domain.Entities
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } = string.Empty; // IN / OUT
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
