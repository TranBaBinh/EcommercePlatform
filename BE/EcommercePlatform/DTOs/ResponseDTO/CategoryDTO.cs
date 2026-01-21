namespace EcommercePlatform.DTOs.ResponseDTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public List<CategoryDTO> SubCategories { get; set; } = new List<CategoryDTO>();
    }
}
