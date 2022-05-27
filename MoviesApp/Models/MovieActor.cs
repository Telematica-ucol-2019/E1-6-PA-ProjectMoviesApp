using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    [Table("MoviesActors")]
    public class MovieActor
    {
        public int Id { get; set; }
       
        [ForeignKey(typeof(Movie))]
        public int FKMovieId { get; set; }
        
        [ForeignKey(typeof(Actor))]
        public int FKActorId { get; set; }

    }
}
