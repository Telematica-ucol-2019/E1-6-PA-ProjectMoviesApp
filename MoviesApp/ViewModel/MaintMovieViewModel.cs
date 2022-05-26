using MoviesApp.Models;
using MoviesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace MoviesApp.ViewModel
{
    public class MaintMovieViewModel : BaseViewModel
    {
        public Movie Movie { get; set; }

        public ICommand cmdSaveMovie { get; set; }
        public MaintMovieViewModel(Movie movie)
        {
            Movie = movie;

            cmdSaveMovie = new Command<Movie>((item) => cmdSaveMovieMethod(item));
        }

        private void cmdSaveMovieMethod(Movie movie)
        {
            //Console.WriteLine(movie.Producer.Name);
            App.MovieDB.InsertOrUpdate(movie);
            //App.ProducerDB.InsertOrUpdate(movie.Producer);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
