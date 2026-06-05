namespace WarehouseApp.Domain.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int WarehouseId { get; set; }

        public int Quantity { get; set; }

        public Product? Product { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
