using MoviesApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesApp.Repositories
{
    public class MovieActorRepository
    {
        //Uto josue
        SQLiteConnection connection;

        public MovieActorRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<MovieActor>();
        }


        public void Init()
        {
            connection.CreateTable<MovieActor>();
        }
        public void InsertOrUpdate(MovieActor movieActor)
        {
            if (movieActor.Id == 0)
            {

                connection.InsertWithChildren(movieActor);

            }
            else
            {
                connection.InsertOrReplaceWithChildren(movieActor);
                //connection.Update(movieActor);
                //App.ProducerDB.InsertOrUpdate(movieActor.Producer);

            }
        }

        public MovieActor GetById(int Id)
        {
            return connection.Table<MovieActor>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }

        public List<MovieActor> GetAll()
        {

            return connection.GetAllWithChildren<MovieActor>().ToList();
        }


        public void DeleteItem(int Id)
        {
            MovieActor movieActor = GetById(Id);
            connection.Delete(movieActor);
        }
    }

}
