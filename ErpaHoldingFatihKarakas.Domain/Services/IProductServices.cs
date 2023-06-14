using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IProductServices
    {
        //public Task<List<ProductDto>> GetAllProductByCategoryId(int id);
        public  Task<ProductDto> CreateAsync(ProductCreateDto product);
        public Task<ProductDto> UpdateAsync(ProductUpdateDto product);
        public Task<List<ProductDto>> GetAll();
        public Task DeleteProduct(int id);
        public Task<ProductDto> Get(int id);
        public Task<List<ProductDto>> GetAllByCategory(int CategoryId);
        public Task<ProductDto> PublishProduct(int productId);
        public Task<ProductDto> NonePublishProduct(int productId);


    }
}
