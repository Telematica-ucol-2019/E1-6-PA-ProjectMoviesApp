using MoviesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MoviesApp.Repositories
{
    public class ProducerRepository
    {
        SQLiteConnection connection;

        public ProducerRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Producer>();
        }

        public void Init()
        {
            connection.CreateTable<Producer>();
        }

        public void InsertOrUpdate(Producer release)
        {
            if (release.Id == 0)
            {
                Debug.WriteLine($"Id before register {release.Id}");
                connection.Insert(release);
                Debug.WriteLine($"Id after register {release.Id}");
            }
            else
            {
                Debug.WriteLine($"Id before updating {release.Id}");
                connection.Update(release);
                Debug.WriteLine($"Id after updating {release.Id}");
            }
        }

        public Producer GetById(int Id)
        {
            return connection.Table<Producer>().FirstOrDefault(item => item.Id == Id);
        }

        public List<Producer> GetAll()
        {
            return connection.Table<Producer>().ToList();
        }

        public void DeleteItem(int Id)
        {
            Producer release = GetById(Id);
            connection.Delete(release);
        }
    }
}
