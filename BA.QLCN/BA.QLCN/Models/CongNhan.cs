using SQLite;
using System;

namespace BA.QLCN.Models
{
    /// <summary>Model CongNhan tương tác trực tiếp với DB</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public class CongNhan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Hobbit { get; set; }

        public DateTime Birth { get; set; }

        public string Gender { get; set; }
    }
}
