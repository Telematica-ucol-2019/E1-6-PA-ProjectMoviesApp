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
        public ICommand cmdDetailActor { get; set; }
        public ICommand cmdListActors { get; set; }
        


        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        private Actor actor;
        public Actor Actor
        {
            get { return actor; }
            set { actor = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Actor> Actors { get; set; }
        public ObservableCollection<MovieActor> MovieActors { get; set; }


        public MainViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            Actors = new ObservableCollection<Actor>();
            cmdAddMovie = new Command(() => cmdAddMovieMethod());
            cmdModifyMovie = new Command<Movie>((item) => cmdModifyMovieMethod(item));
            cmdDetailMovie = new Command<Movie>((item) => cmdDetailMovieMethod(item));
            cmdDetailActor = new Command<Actor>((item) => cmdDetailActorMethod(item));
            cmdListActors = new Command(() => cmdListActorsMethod());
        }

        private void cmdListActorsMethod()
        {
            App.Current.MainPage.Navigation.PushAsync(new ListActors(this));
        }

        private void cmdDetailActorMethod(Actor actor)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetailActor(actor, this));
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
                .RuleFor(c => c.Logo, f => f.Person.Avatar)
                .RuleFor(c => c.Name, f => f.Company.CompanyName());






            //var RandomNum = Randomizer();
            movie.Actors = new ObservableCollection<Actor>();

            Actors = new ObservableCollection<Actor>(App.ActorDB.GetAll());
            

            for(int i = 0; i < 3; i++)
            {
                var random = Randomizer();
                //Actors[random].Movies = new ObservableCollection<Movie>();
                Actors[random].Movies.Add(movie);
                movie.Actors.Add(Actors[random]);
            }

            //MovieActors = new ObservableCollection<MovieActor>(App.MovieActorDB.GetAll());


            //movie.Actors.Add(new Faker<Actor>()
            //            .RuleFor(c => c.Name, f => f.Name.FullName())
            //            .RuleFor(c => c.Alias, f => f.Name.LastName()));
            //movie.Actors[0].Movies = new ObservableCollection<Movie>();
            //movie.Actors[0].Movies.Add(movie);

            OnPropertyChanged();
            App.Current.MainPage.Navigation.PushAsync(new MaintMovie(movie));

        }

        private int Randomizer()
        {
            int totalItemActors = Actors.Count - 1;
            //int totalItemActors = 4;
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


        public void GetAllActors()
        {
            if (Actors != null)
            {
                Actors.Clear();
                App.ActorDB.GetAll().ForEach(item => Actors.Add(item));

            }
            else
            {
                Actors = new ObservableCollection<Actor>(App.ActorDB.GetAll());
            }
            OnPropertyChanged();
        }
    }
}
