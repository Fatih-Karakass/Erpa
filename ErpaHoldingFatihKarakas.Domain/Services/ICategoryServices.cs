﻿using ErpaHoldingFatihKarakas.Domain.Categories.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface ICategoryServices
    {
        public Task<CategoryCreateDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        public Task<CategoryUpdateDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        public Task DeleteCategory(int id);
        public Task<List<CategoryDto>> GetAll();
        public Task<CategoryDto> Get(int id);
        public Task AddCategoryProduct(int productId, int categoryId);
        public Task RemoveCategoryProduct(int productId, int categoryId);





    }
}
