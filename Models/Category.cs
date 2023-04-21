namespace SampleAPI.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryID { get; set; } // Add this property to reference the parent category

        public Category ParentCategory { get; set; } // Add this property to navigate to the parent category
        public ICollection<Category> Subcategories { get; set; } // Add this property to navigate to the subcategories

        public virtual ICollection<TShirt> TShirts { get; set; }
    }
}
