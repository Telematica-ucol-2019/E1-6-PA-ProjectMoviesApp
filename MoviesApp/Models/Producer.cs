using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesApp.Models
{
    [Table("Producers")]
    public class Producer
    {
        [PrimaryKey, AutoIncrement ]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }

    }
}
