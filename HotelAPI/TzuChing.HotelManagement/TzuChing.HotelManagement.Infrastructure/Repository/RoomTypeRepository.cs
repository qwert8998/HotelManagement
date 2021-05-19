using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.Entities;
using TzuChing.HotelManagement.ApplicationCore.Models.Request;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.Infrastructure.Data;

namespace TzuChing.HotelManagement.Infrastructure.Repository
{
    public class RoomTypeRepository : EfRepository<RoomTypes>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<RoomTypes> GetByName (string name)
        {
            try
            {
                var result = await _dbContext.RoomType.FirstOrDefaultAsync(r => r.RTDESC == name);
                return result;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task UpdateRoomType(RoomTypeRequest request)
        {
            var sql = @"UPDATE dbo.RoomType SET RTDESC=@rt, Rent=@rent WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rt",request.RTDESC),
                new SqlParameter("@rent", request.Rent),
                new SqlParameter("@id", request.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
