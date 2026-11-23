namespace dto
{
    public class Jewelrydto
    {
        public int JewelryCode { get; set; }

        public string JewelryName { get; set; } = null!;

        public int CategoryCode { get; set; }

        public int MaterialCode { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercent { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        //שם קטגוריה- שדה נוסף שלא קיים בטבלה המקורית
        public string? CategoryName { get; set; }
    }
}
