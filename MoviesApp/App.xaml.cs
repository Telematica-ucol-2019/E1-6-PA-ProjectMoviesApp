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



        #endregion

        public App()
        {
            InitializeComponent();

            ProducerDB.Init();
            MovieDB.Init();

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
