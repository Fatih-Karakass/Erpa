namespace ErpaHoldingFatihKarakas.Domain.Brands.Dto
{
    public class BrandUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
