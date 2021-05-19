using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.Infrastructure.Data;

namespace TzuChing.HotelManagement.Infrastructure.Repository
{
    public class CustomerRepository : EfRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Customers>> GetAllCustomerByRoomId(int id)
        {
            var cus = await _dbContext.Customer.Where(c => c.RoomId == id).ToListAsync();
            return cus;
        }

        public async Task UpdateCustomer (Customers c)
        {
            var sql = @"UPDATE dbo.Customer SET RoomNo=@tn,CName=@n,Address=@ad,Phone=@ph,Email=@e,CheckIn=@ci,TotalPersons=@t,BookingDays=@b,Advance=@a WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tn",c.RoomId ?? (object)DBNull.Value),
                new SqlParameter("@n", c.CName),
                new SqlParameter("@ad", c.Address),
                new SqlParameter("@ph", c.Phone),
                new SqlParameter("@e", c.Email),
                new SqlParameter("@ci", c.CheckIn ?? (object)DBNull.Value),
                new SqlParameter("@t", c.TotalPersons ?? (object)DBNull.Value),
                new SqlParameter("@b", c.BookingDays ?? (object)DBNull.Value),
                new SqlParameter("@a", c.Advance ?? (object)DBNull.Value),
                new SqlParameter("@id", c.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
