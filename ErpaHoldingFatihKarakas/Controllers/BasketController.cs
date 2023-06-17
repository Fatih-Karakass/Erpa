using ErpaHoldingFatihKarakas.Application.Services.Products;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServices _basketServices;

        public BasketController(IBasketServices basketServices)
        {
            _basketServices = basketServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int productId,int productCount,Guid userId)
        {

             await _basketServices.AddProductToBasket(productId, productCount, userId); 
            return Ok();

        }
        [HttpGet]


        public async Task<IActionResult> RemoveProductFromBasket(int productId,int productCount,Guid userId)
        {

             await _basketServices.AddProductToBasket(productId,productCount,userId);
            return Ok();

        }
        [HttpPut]

        public async Task<IActionResult> UpdateBasket(int productId,int productCount,Guid userId)
        {

             await _basketServices.AddProductToBasket(productId, productCount,userId);
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> ListBasket(int basketId)
        {

            var basket = await _basketServices.ListBasket(basketId);
            return Ok(basket);

        }
        [HttpPost]
        public async Task<IActionResult> BasketFinished(int basketId,string adress)
        {
            var basket = await _basketServices.BasketFinished(basketId, adress);
            return Ok(basket);

        }


    }
}
