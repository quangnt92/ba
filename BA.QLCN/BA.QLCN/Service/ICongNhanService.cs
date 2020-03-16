using BA.QLCN.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BA.QLCN.Service
{
    /// <summary>Interface CRUD of CongNhan</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public interface ICongNhanService
    {
        Task<IEnumerable<CongNhan>> GetCongNhansAsync(string keyword);
        Task<CongNhan> GetCongNhan(int id);
        Task AddCongNhan(CongNhan congnhan);
        Task UpdateCongNhan(CongNhan congnhan);
        Task DeleteCongNhan(CongNhan congnhan);
    }
}
