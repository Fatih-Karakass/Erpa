using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Categories.Dto;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Products;
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
        private readonly IUnitOfWork _unitOfWork;



        public CategoryServices(ICategoryRepository repository, IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategoryProduct(int productId, int categoryId)
        {
           var product= await _productRepository.GetByIdAsync(productId);
            var category = await _repository.GetAll().Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null||product==null) 
            {
                throw new Exception("Bulunamadı");
            }
            category.Products.Add(product);
            await _repository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryCreateDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
           
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _repository.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryCreateDto>(category);
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception("Bulunamadı");
            }
            await _repository.DeleteAsync(category);
        }

        public async Task<CategoryDto> Get(int id)
        {
            var Category = await _repository.GetAll().Include(x => x.Products).FirstOrDefaultAsync(x=>x.Id==id);
            if (Category == null)
            {
                throw new Exception("Bulunamadı");
            }
            return _mapper.Map<CategoryDto>(Category);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var CategoryList = await _repository.GetAll().Include(x=>x.Products).ToListAsync();
            return _mapper.Map<List<CategoryDto>>(CategoryList);
        }

        public async Task RemoveCategoryProduct(int productId, int categoryId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var category = await _repository.GetAll().Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null || product == null)
            {
                throw new Exception("Bulunamadı");
            }
            category.Products.Remove(product);
            await _repository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<CategoryUpdateDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _repository.GetAll().Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryUpdateDto.Id);
            if (category == null)
            {
                throw new Exception("Bulunamadı");
            }
            category.Name=categoryUpdateDto.Name;
            category.Desciription = categoryUpdateDto.Desciription;
            category.SubCategoryId = categoryUpdateDto.SubCategoryId;
            category.Products = new List<Product>();
            foreach(var item in categoryUpdateDto.ProductIds)
            {
                var products = await _productRepository.GetByIdAsync(item);
                if (products == null)
                {
                    continue;
                }
                
                category.Products.Add(products);
            }
            var categoryFromDb = await _repository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryUpdateDto>(categoryFromDb);
        }
    }
}
