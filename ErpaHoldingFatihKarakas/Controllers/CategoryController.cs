using ErpaHoldingFatihKarakas.Application.Services.Products;
using ErpaHoldingFatihKarakas.Domain.Categories.Dto;
using ErpaHoldingFatihKarakas.Domain.Products.Dto;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpPost]

        public async Task<IActionResult> AddCategory(CategoryCreateDto categoryCreateDto)
        {

            var Category = await _categoryServices.CreateAsync(categoryCreateDto);
            return Ok(Category);

        }
        [HttpPut]

        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {

            var Category = await _categoryServices.UpdateAsync(categoryUpdateDto);
            return Ok(Category);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {

            var categories = await _categoryServices.GetAll();
            return Ok(categories);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var category =  _categoryServices.DeleteCategory(id);
            return Ok(category);

        }
        [HttpGet]

        public async Task<IActionResult> GetCategory(int id)
        {

            var category = await _categoryServices.Get(id);
            return Ok(category);

        }
        [HttpPost]

        public async Task<IActionResult> AddCategoryProduct(int productId,int categoryId)
        {

            var category =  _categoryServices.AddCategoryProduct(productId, categoryId);
            return Ok(category);

        }
        [HttpPost]

        public  async Task<IActionResult> RemoveCategoryProduct(int productId, int categoryId)
        {

            var category =  _categoryServices.RemoveCategoryProduct(productId, categoryId);
            return Ok(category);

        }

    }
}
