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
    public class ServiceRepository : EfRepository<Services>, IServiceRepository
    {
        public ServiceRepository(HotelManagementDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Services> GetServicesByRoomAndDate(int roomId, DateTime date)
        {
            var result = await _dbContext.Service.Where(s => s.RoomId == roomId && s.ServiceDate == date).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateService ( Services ser)
        {
            var sql = @"UPDATE dbo.Service SET [RoomNo]=@rn,[SDESC]=@d,[ServiceDate]=@sd,[Amount]=@am WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rn",ser.RoomId ?? (object)DBNull.Value),
                new SqlParameter("@sd", ser.ServiceDate ?? (Object)DBNull.Value),
                new SqlParameter("@am", ser.Amount ?? (object)DBNull.Value),
                new SqlParameter("@d", ser.SDESC),
                new SqlParameter("@id", ser.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
