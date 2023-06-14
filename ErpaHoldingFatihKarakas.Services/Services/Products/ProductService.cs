using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Products.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Application.Services.Products
{
    public class ProductService:IProductServices
    {
        private readonly IProductRepository _repository;

        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper = null)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto productDto)
        {
           Product product=_mapper.Map<Product>(productDto);
           var producFromDb= await _repository.CreateAsync(product);

            return _mapper.Map<ProductDto>(producFromDb);
        }

        public async Task DeleteProduct(int id)
        {
            var product =await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(product);
        }

        public async Task<ProductDto> Get(int id)
        {
            var product =await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<List<ProductDto>> GetAll()
        {
            var product = await _repository.GetAll().ToListAsync() ;
            return _mapper.Map<List<ProductDto>>(product);
        }

        public async Task<List<ProductDto>> GetAllByCategory(int CategoryId)
        {
            var productList = await _repository.GetAll().Where(x => x.CategoryId == CategoryId).ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> NonePublishProduct(int productId)
        {
            var product = await _repository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Bulunamadı");
            }
            product.IsPublished = false;
           var productFromDb= await _repository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(productFromDb);
        }

        public async Task<ProductDto> PublishProduct(int productId)
        {
            var product = await _repository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Bulunamadı");
            }
            product.IsPublished = true;
            var productFromDb = await _repository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(productFromDb);
        }

        public async Task<ProductDto> UpdateAsync(ProductUpdateDto productDto)
        {
         
            var product = _mapper.Map<Product>(productDto);
            //test edilicek
           var productFromDb= await _repository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(productFromDb);
        }


      
    }
}
