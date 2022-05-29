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
    public partial class ListActors : ContentPage
    {
        public ListActors(MainViewModel vm)
        {
            InitializeComponent();
            vm.GetAllActors();
            BindingContext = vm;
        }
    }
}