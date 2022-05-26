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
    public partial class MaintMovie : ContentPage
    {
        public MaintMovie(Movie movie)
        {
            InitializeComponent();
            BindingContext = new MaintMovieViewModel(movie);
        }
    }
}