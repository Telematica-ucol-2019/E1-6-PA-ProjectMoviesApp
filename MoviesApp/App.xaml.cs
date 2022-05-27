using MoviesApp.Repositories;
using MoviesApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp
{
    public partial class App : Application
    {
        #region Repository
        
        private static ProducerRepository _producerDB;
        public static ProducerRepository ProducerDB
        {
            get
            {
                if (_producerDB == null)
                {
                    _producerDB = new ProducerRepository();
                }
                return _producerDB;
            }
        }


        private static MovieRepository _movieDB;
        public static MovieRepository MovieDB
        {
            get
            {
                if (_movieDB == null)
                {
                    _movieDB = new MovieRepository();
                }
                return _movieDB;
            }
        }


        private static ActorRepository _actorDB;
        public static ActorRepository ActorDB
        {
            get
            {
                if (_actorDB == null)
                {
                    _actorDB = new ActorRepository();
                }
                return _actorDB;
            }
        }

        private static MovieActorRepository _movieActorDB;
        public static MovieActorRepository MovieActorDB
        {
            get
            {
                if (_movieActorDB == null)
                {
                    _movieActorDB = new MovieActorRepository();
                }
                return _movieActorDB;
            }
        }



        #endregion

        public App()
        {
            InitializeComponent();

            ProducerDB.Init();
            MovieDB.Init();
            ActorDB.Init();
            MovieActorDB.Init();

            MainPage = new NavigationPage(new Main());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
