using Pizzeria.Core.DataTransfer;
using Pizzeria.Core.Models;
using System.Threading.Tasks;

namespace Pizzeria.Core.Managers
{
    public interface IOrderManager
    {
        Task<ApiResponse<Order>> PlaceOrder(OrderInput orderInput);
    }
}
