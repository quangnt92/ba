using BA.QLCN.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BA.QLCN.Service
{
    /// <summary>Interface CRUD of QuanLy</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public interface IQuanLyService
    {
        Task<IEnumerable<QuanLy>> GetQuanLysAsync();
        Task<QuanLy> FindQuanLy(string username, string password);
        Task<QuanLy> GetQuanLy(string username);
        Task AddQuanLy(QuanLy quanly);
    }
}
