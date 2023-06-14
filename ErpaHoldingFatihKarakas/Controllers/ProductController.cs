using ErpaHoldingFatihKarakas.Domain.Products.Dto;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDto productDto)
        {

          var product= await _productServices.CreateAsync(productDto);
            return Ok(product);
   
        }
        [HttpPost]

        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productDto)
        {

            var product = await _productServices.UpdateAsync(productDto);
            return Ok(product);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {

            var product = await _productServices.GetAll();
            return Ok(product);

        }
        [HttpDelete]


        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product =  _productServices.DeleteProduct(id);
            return Ok(product);

        }
        [HttpGet]

        public async Task<IActionResult> GetProduct(int id)
        {

            var product = await _productServices.Get(id);
            return Ok(product);

        }
        [HttpGet]

        public async Task<IActionResult> GetAllByCategory(int CategoryId)
        {

            var product = await _productServices.GetAllByCategory(CategoryId);
            return Ok(product);

        }
        [HttpPost]

        public async Task<IActionResult> PublishProduct(int id)
        {

            var product = await _productServices.PublishProduct(id);
            return Ok(product);

        }
        [HttpPost]

        public async Task<IActionResult> NonPublishProduct(int id)
        {

            var product = await _productServices.NonePublishProduct(id);
            return Ok(product);

        }




    }
}
