using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.Infrastructure.Data;

namespace TzuChing.HotelManagement.Infrastructure.Repository
{
    public class RoomRepository : EfRepository<Rooms>, IRoomRepository
    {
        public RoomRepository(HotelManagementDBContext dbContext) : base(dbContext)
        {
        }

        public async Task UpdateRoome(RoomRequest request)
        {
            var sql = @"UPDATE dbo.Room SET RTCode=@rt, Status=@s WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rt",request.RoomTypeId),
                new SqlParameter("@s", request.Status),
                new SqlParameter("@id", request.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
