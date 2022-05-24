using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoviesApp.Constants
{
    public static class Constants
    {
        public const string DatabaseFilename = "db.Movies.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Open the database in the read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite | 
            // Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create | 
            // Enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
