using MoviesApp.Models;
using MoviesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailMovie : ContentPage
    {
        public DetailMovie(Movie movie, MainViewModel vm)
        {
            InitializeComponent();
            vm.Movie = new Movie();
            vm.Movie = movie;
            this.BindingContext = vm;
            //BindingContext = new DetailMovieViewModel(movie);


        }
    }
}