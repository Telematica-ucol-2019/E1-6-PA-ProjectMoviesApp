using MoviesApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesApp.Repositories
{
    public class ActorRepository
    {
        SQLiteConnection connection;

        public ActorRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Actor>();

        }

        public void Init()
        {
            connection.CreateTable<Actor>();
            AddFromStart("Jochue Benja", "Jamonero");
            AddFromStart("Juempoblo Jamones", "wempo");
            AddFromStart("Mario Alex", "Wiener");
            AddFromStart("Wis Edgardo", "wis");
            AddFromStart("Ivon Jardines", "CryptoBro");
            AddFromStart("Hector Bonifacio", "Arroyero");
            AddFromStart("Edgar Rojas", "Cupsk");
            AddFromStart("Silvio Carmona", "Chuyo");
            AddFromStart("Andrea Almendros", "Andry");
            AddFromStart("Kevin Ornelas", "Orneli");

        }


        private void AddFromStart(string name, string alias)
        {
            Actor actor = GetByName(name);

            if (actor == null)
            {
                InsertOrUpdate(new Actor() { Name = name, Alias = alias });
            }

        }

        public void InsertOrUpdate(Actor actor)
        {
            if (actor.Id == 0)
            {

                //connection.InsertWithChildren(actor);
                connection.Insert(actor);

            }
            else
            {

                connection.Update(actor);
                //App.ProducerDB.InsertOrUpdate(movie.Producer);

            }
        }

        public Actor GetById(int Id)
        {
            return connection.Table<Actor>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }

        public Actor GetByName(string Name)
        {
            return connection.Table<Actor>().FirstOrDefault(item => item.Name == Name);
        }

        public List<Actor> GetAll()
        {

            return connection.GetAllWithChildren<Actor>().ToList();
        }

        //public TableQuery<Actor> GetAllActors(Movie movie)
        //{

        //    //return connection.GetAllWithChildren<Actor>().ToList();
        //    var ActorTable = connection.Table<Actor>().Where(m => m.Id == movie.Id);
        //    return MovieTable;

        //}



        public void DeleteItem(int Id)
        {
            Actor actor = GetById(Id);
            connection.Delete(actor);
        }
    }


}
