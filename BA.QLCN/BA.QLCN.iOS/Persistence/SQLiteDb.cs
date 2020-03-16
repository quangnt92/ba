using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using BA.QLCN.iOS;
using BA.QLCN.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]
namespace BA.QLCN.iOS
{
    /// <summary>Connect SQLite</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.Persistence.ISQLiteDb" />
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "QLCN2.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}