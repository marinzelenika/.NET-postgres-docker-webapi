namespace SampleAPI.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public int TShirtID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
