using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [Table("Actores")]
    public class Actor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MothersLastN { get; set; }
        public string MoviesPart { get; set; }

    }
}
