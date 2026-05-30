namespace WarehouseAppWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // نام کالا
        public string Code { get; set; } = string.Empty; // کد کالا (مثلاً PRD-101)
        public int Quantity { get; set; } // موجودی انبار
        public decimal Price { get; set; } // قیمت کالا
    }
}
