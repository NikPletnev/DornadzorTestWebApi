using DornadzorTestWebApi.DAL.Entity;

namespace DornadzorTestWebApi.DAL.Repositores
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        void DeleteOrder(Order entity);
        Order GetOrderById(int id);
        void UpdateOrder(Order entity, Order order);
    }
}