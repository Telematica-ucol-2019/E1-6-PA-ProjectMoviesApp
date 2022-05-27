using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesApp.Models
{
    [Table("Actores")]
    public class Actor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        [ManyToMany(typeof(MovieActor), CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Movie> Movies { get; set; }
    }
}
