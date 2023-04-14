namespace SampleAPI.DTOs
{
    public class TShirtDTO
    {
        public int TShirtID { get; set; }
        public int? CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Sizes { get; set; }
    }
}
