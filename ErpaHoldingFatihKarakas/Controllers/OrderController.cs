using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder(int id)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            var order = await _orderServices.GetOrder(id, Guid.Parse(user.Value));
            return Ok(order);
        }
        [HttpGet]

        public async Task<IActionResult> GetOrderByUser(string username)
        {

            var orderList = await _orderServices.GetOrderByUser(username);

            return Ok(orderList);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> ListAllOrder()
        {
            var orderList = await _orderServices.ListAllOrder();
            return Ok(orderList);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            var user = await _orderServices.UpdateOrder(id, Guid.Parse(user.Value));
            return Ok(user);
        }


    }
}
