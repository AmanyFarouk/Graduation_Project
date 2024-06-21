using Graduation_Project.DTO.OrderDto;

namespace Graduation_Project.Services
{
    public interface IOrderRepository
    {

        void Add(OrderClientDto orderDto);
        void Edit(int id,OrderAdminDto orderAdminDto);
        List<OrderDto> GetAll();
        OrderClientDto GetById(int id);
        List<GetAllOrdersClientDto> GetOrdersById(int id);
        void EditOrder(int id, OrderClientDto orderDto);
        void Delete(int id);
    }
}
