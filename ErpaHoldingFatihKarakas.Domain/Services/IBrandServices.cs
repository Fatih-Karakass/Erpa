using ErpaHoldingFatihKarakas.Domain.Brands.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IBrandServices
    {
        public Task<BrandCreateDto> CreateAsync(BrandCreateDto brandCreateDto);
        public Task<BrandUpdateDto> UpdateAsync(BrandUpdateDto brandUpdateDto);
        public Task Delete(int Id);
        public Task<List<BrandDto>> GetAll();
        public Task<BrandDto> Get(int id);
        //public Task<List<BrandDto>> GetProductByBrand(int productId);
        public Task<BrandDto> GetProductByBrand(int productId);
    }
}
