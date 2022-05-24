using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [Table("Producers")]
    public class Producer
    {
        [PrimaryKey, AutoIncrement ]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
