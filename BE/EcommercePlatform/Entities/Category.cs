using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required , StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }  

        public Guid? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();




    }
}
