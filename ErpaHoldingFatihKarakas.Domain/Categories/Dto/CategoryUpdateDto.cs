namespace ErpaHoldingFatihKarakas.Domain.Categories.Dto
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciription { get; set; }
        public List<int> ProductIds { get; set; }

        public int? SubCategoryId { get; set; }
    }
}
