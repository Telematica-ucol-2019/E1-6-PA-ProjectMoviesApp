using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [ForeignKey(typeof(Producer))]
        public int FKProducerId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Producer Producer { get; set; }

        [ManyToMany(typeof(MovieActor), CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Actor> Actors { get; set; }
    }
}
