using Bogus;
using MoviesApp.Models;
using MoviesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviesApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        public ICommand cmdAddMovie { get; set; }
        public ICommand cmdModifyMovie { get; set; }
        public ICommand cmdDetailMovie { get; set; }


        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Actor> Actors { get; set; }


        public MainViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            cmdAddMovie = new Command(() => cmdAddMovieMethod());
            cmdModifyMovie = new Command<Movie>((item) => cmdModifyMovieMethod(item));
            cmdDetailMovie = new Command<Movie>((item) => cmdDetailMovieMethod(item));
        }

        private void cmdDetailMovieMethod(Movie movie)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetailMovie(movie, this));
        }

        private void cmdModifyMovieMethod(Movie movie)
        {
            App.Current.MainPage.Navigation.PushAsync(new MaintMovie(movie));
        }

        private void cmdAddMovieMethod()
        {
            Movie movie = new Faker<Movie>()
                .RuleFor(c => c.Coverpage, f => f.Person.Avatar)
                .RuleFor(c => c.Title, f => f.Commerce.ProductName())
                .RuleFor(c => c.Synopsis, f => f.Commerce.ProductDescription());

            movie.Producer = new Faker<Producer>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName());

            Actors = new ObservableCollection<Actor>(App.ActorDB.GetAll());

            movie.Actors = new ObservableCollection<Actor>();
            var RandomNum = Randomizer();
            movie.Actors.Add(new Actor() { Name = Actors[RandomNum].Name, Alias = Actors[RandomNum].Alias });
            var RandomNum2 = Randomizer();
            movie.Actors.Add(new Actor() { Name = Actors[RandomNum2].Name, Alias = Actors[RandomNum2].Alias });
            var RandomNum3 = Randomizer();
            movie.Actors.Add(new Actor() { Name = Actors[RandomNum2].Name, Alias = Actors[RandomNum2].Alias });
            OnPropertyChanged();
            App.Current.MainPage.Navigation.PushAsync(new MaintMovie(movie));

        }

        private int Randomizer()
        {
            //int totalItemActors = Actors.Count - 1;
            int totalItemActors = 4;
            Random rnd = new Random();
            int i = rnd.Next(0, 32000) % totalItemActors;
            return i;

        }

        public void GetAll()
        {
            if(Movies != null)
            {
                Movies.Clear();
                App.MovieDB.GetAll().ForEach(item => Movies.Add(item));
            }
            else
            {
                Movies = new ObservableCollection<Movie>(App.MovieDB.GetAll());
            }
            OnPropertyChanged();
        }
    }
}
