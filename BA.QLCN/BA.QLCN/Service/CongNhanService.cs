using BA.QLCN.Models;
using BA.QLCN.Persistence;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BA.QLCN.Service
{
    /// <summary>Implement interface IQuanLyService</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.Service.ICongNhanService" />
    public class CongNhanService : ICongNhanService
    {
        private SQLiteAsyncConnection _connection;


        /// <summary>Create table CongNhan</summary>
        /// <param name="db">The database.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public CongNhanService(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<CongNhan>();
        }


        /// <summary>Get list CongNhan by keyword.</summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task<IEnumerable<CongNhan>> GetCongNhansAsync(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return await _connection.Table<CongNhan>().OrderByDescending(s => s.ID).ToListAsync();
            }
            else
            {
                return await _connection.Table<CongNhan>().Where(s => s.Name.Contains(keyword)).OrderByDescending(s => s.ID).ToListAsync();
            }            
        }


        /// <summary>Delte item.</summary>
        /// <param name="congnhan">The congnhan.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task DeleteCongNhan(CongNhan congnhan)
        {
            await _connection.DeleteAsync(congnhan);
        }


        /// <summary>Add item.</summary>
        /// <param name="congnhan">The congnhan.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task AddCongNhan(CongNhan congnhan)
        {
            await _connection.InsertAsync(congnhan);
        }


        /// <summary>Update item.</summary>
        /// <param name="congnhan">The congnhan.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task UpdateCongNhan(CongNhan congnhan)
        {
            await _connection.UpdateAsync(congnhan);
        }


        /// <summary>Get item by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task<CongNhan> GetCongNhan(int id)
        {
            return await _connection.FindAsync<CongNhan>(id);
        }
    }
}
