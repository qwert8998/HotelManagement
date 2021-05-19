using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.Models.Response;

namespace TzuChing.HotelManagement.ApplicationCore.ServiceInterface
{
    public interface ICustomerService
    {
        Task<CustomerResponse> AddCustomer(CustomerRequest request);
        Task<CustomerResponse> UpdateCustomer(CustomerRequest request);
        Task<BasicResponse> DeleteCustomer(int id);
        Task<ListAllCustomer> GetAllCustomers();
        Task<CustomerResponse> GetCustomerById(int id);
    }
}
