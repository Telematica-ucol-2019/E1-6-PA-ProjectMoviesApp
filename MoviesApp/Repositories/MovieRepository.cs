using MoviesApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesApp.Repositories
{
    public class MovieRepository
    {
        SQLiteConnection connection;

        public MovieRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Movie>();
        }


        public void Init()
        {
            connection.CreateTable<Movie>();
        }
        public void InsertOrUpdate(Movie movie)
        {
            if (movie.Id == 0)
            {
                //New way
                App.ProducerDB.InsertOrUpdate(movie.Producer);
                movie.FKProducerId = movie.Producer.Id;
                connection.Insert(movie);

                foreach(Actor actor in movie.Actors)
                {
                    Console.WriteLine(actor.Movies[0].Title);
                    var relation = new MovieActor() { FKActorId = actor.Id, FKMovieId = movie.Id };
                    App.MovieActorDB.InsertOrUpdate(relation);
                    App.ActorDB.InsertOrUpdate(actor);
                    var a = relation;
                }


                //OldWay
                //connection.InsertWithChildren(movie);

            }
            else
            {

                connection.Update(movie);
                App.ProducerDB.InsertOrUpdate(movie.Producer);

            }
        }

        public Movie GetById(int Id)
        {
            return connection.Table<Movie>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }

        public List<Movie> GetAll()
        {

            return connection.GetAllWithChildren<Movie>().ToList();
        }


        public void DeleteItem(int Id)
        {
            Movie movie = GetById(Id);
            connection.Delete(movie);
        }
    }
}
