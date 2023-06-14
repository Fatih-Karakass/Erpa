using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Categories.Dto;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Application.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repository;
        private readonly IProductRepository _productRepository;//!!!!!!!!!!!!!!!!!!!!
        private readonly IMapper _mapper;


        public CategoryServices(ICategoryRepository repository, IMapper mapper, IProductRepository productRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task AddCategoryProduct(int productId, int categoryId)
        {
           var product= await _productRepository.GetByIdAsync(productId);
           var category = await _repository.GetByIdAsync(categoryId);
            category.Products.Add(product);
            await _repository.UpdateAsync(category);
        }

        public async Task<CategoryCreateDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
                throw new ArgumentNullException(nameof(categoryCreateDto));
            }
            var Category = _mapper.Map<Category>(categoryCreateDto);
            await _repository.CreateAsync(Category);
            return _mapper.Map<CategoryCreateDto>(Category);
        }

        public async Task DeleteCategory(int id)
        {
            var Category = await _repository.GetByIdAsync(id);
            if (Category == null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(Category);
        }

        public async Task<CategoryDto> Get(int id)
        {
            var Category = await _repository.GetByIdAsync(id);
            if (Category == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<CategoryDto>(Category);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var CategoryList = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<CategoryDto>>(CategoryList);
        }

        public async Task RemoveCategoryProduct(int productId, int categoryId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var category = await _repository.GetByIdAsync(categoryId);
            category.Products.Remove(product);
            await _repository.UpdateAsync(category);
        }

        public async Task<CategoryUpdateDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            var categoryFromDb = await _repository.UpdateAsync(category);
            return _mapper.Map<CategoryUpdateDto>(categoryFromDb);
        }
    }
}
