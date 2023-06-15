using SampleAPI.DTOs;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<Order> AddAsync(OrderDTO orderDto);
        Task<Order> UpdateAsync(int id, OrderDTO orderDto);
        Task<OrderDTO> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);

    }
}
