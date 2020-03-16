using SQLite;

namespace BA.QLCN.Persistence
{
    /// <summary>Interface SQLite</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
