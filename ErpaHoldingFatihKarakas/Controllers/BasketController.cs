using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServices _basketServices;


        public BasketController(IBasketServices basketServices)
        {
            _basketServices = basketServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int productId, int productCount)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            await _basketServices.AddProductToBasket(productId, productCount, Guid.Parse(user.Value));
            return Ok();

        }
        [HttpGet]


        public async Task<IActionResult> RemoveProductFromBasket(int productId, int productCount)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            await _basketServices.AddProductToBasket(productId, productCount, Guid.Parse(user.Value));
            return Ok();

        }
        [HttpPut]

        public async Task<IActionResult> UpdateBasket(int productId, int productCount)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            await _basketServices.AddProductToBasket(productId, productCount, Guid.Parse(user.Value));
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> ListBasket(int basketId)
        {

            var basket = await _basketServices.ListBasket(basketId);
            return Ok(basket);

        }
        [HttpPost]
        public async Task<IActionResult> BasketFinished(int basketId, string adress)
        {
            var basket = await _basketServices.BasketFinished(basketId, adress);
            return Ok(basket);

        }


    }
}
