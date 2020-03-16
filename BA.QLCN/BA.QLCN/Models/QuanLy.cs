using SQLite;

namespace BA.QLCN.Models
{
    /// <summary>Model QuanLy tương tác trực tiếp với DB</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public class QuanLy
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
