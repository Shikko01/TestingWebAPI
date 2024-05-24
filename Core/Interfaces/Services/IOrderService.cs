namespace Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task DeleteOrderAsync(int id);
    }
}
