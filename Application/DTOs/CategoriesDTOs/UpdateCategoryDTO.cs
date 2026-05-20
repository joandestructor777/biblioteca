
namespace Application.DTOs.CategoriesDTOs
{
    public class UpdateCategoryDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
