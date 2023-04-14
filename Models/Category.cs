namespace SampleAPI.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TShirt> TShirts { get; set; }
    }
}
