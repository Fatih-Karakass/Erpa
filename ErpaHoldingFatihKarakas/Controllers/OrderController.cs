using AutoMapper;
using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Authentication.Dto;
using ErpaHoldingFatihKarakas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        public async Task<IActionResult> GetOrder(int id,Guid userId)
        {
          var order=await  _orderServices.GetOrder(id, userId);
            return Ok(order);
        }
        [HttpGet]

        public async Task<IActionResult> GetOrderByUser(string username)
        {
     
            var orderList = await _orderServices.GetOrderByUser(username);

            return Ok(orderList);
        }
        [HttpGet]

        public async Task<IActionResult> ListAllOrder()
        {
            var orderList=await _orderServices.ListAllOrder();
            return Ok(orderList);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(int id,Guid userId)
        {
            var user=await _orderServices.UpdateOrder(id, userId);
            return Ok(user);
        }


    }
}
