using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IOrderServices
    {
        public  Task<List<OrderDto>> ListAllOrder(); 
        public Task<OrderDto> GetOrder(int id,Guid userId);
        public Task<List<OrderDto>> GetOrderByUser(string userName);

        public Task<OrderUpdateDto> UpdateOrder(int orderId, Guid userId);
    }
}
