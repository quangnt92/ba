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
    /// <seealso cref="BA.QLCN.Service.IQuanLyService" />
    public class QuanLyService : IQuanLyService
    {
        private SQLiteAsyncConnection _connection;


        /// <summary>Create table QuanLy</summary>
        /// <param name="db">The database.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public QuanLyService(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<QuanLy>();
        }


        /// <summary>Get list QuanLys.</summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task<IEnumerable<QuanLy>> GetQuanLysAsync()
        {
            return await _connection.Table<QuanLy>().OrderByDescending(s => s.ID).ToListAsync();
        }


        /// <summary>Add item</summary>
        /// <param name="quanly">The quanly.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task AddQuanLy(QuanLy quanly)
        {
            await _connection.InsertAsync(quanly);
        }


        /// <summary>Get item by username.</summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public async Task<QuanLy> GetQuanLy(string username)
        {
            return await _connection.Table<QuanLy>().FirstOrDefaultAsync(s => s.UserName == username);
        }


        /// <summary>Finds item by username and password, check for login</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public Task<QuanLy> FindQuanLy(string username, string password)
        {            
            return _connection.Table<QuanLy>().FirstOrDefaultAsync(s => s.UserName == username && s.Password == password);
        }
    }
}
