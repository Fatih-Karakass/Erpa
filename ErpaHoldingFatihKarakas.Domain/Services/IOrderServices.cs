using ErpaHoldingFatihKarakas.Domain.Orders.Dto;

namespace ErpaHoldingFatihKarakas.Domain.Services
{
    public interface IOrderServices
    {
        public Task<List<OrderDto>> ListAllOrder();
        public Task<OrderDto> GetOrder(int id, Guid userId);
        public Task<List<OrderDto>> GetOrderByUser(string userName);

        public Task<OrderUpdateDto> UpdateOrder(int orderId, Guid userId);
    }
}
