using System.Collections.Generic;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;

namespace TzuChing.HotelManagement.ApplicationCore.RepositoryInterface
{
    public interface ICustomerRepository : IAsyncRepository<Customers>
    {
        Task<List<Customers>> GetAllCustomerByRoomId(int id);
        Task UpdateCustomer(Customers c);
    }
}
