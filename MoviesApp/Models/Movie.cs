using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [Table("Movies")]
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Coverpage { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string ReleaseDate { get; set; }
        public string Producer { get; set; }
    }
}
