﻿using MoviesApp.Models;
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
    public partial class DetailActor : ContentPage
    {
        public DetailActor(Actor actor, MainViewModel vm)
        {
            InitializeComponent();
            //Console.WriteLine(actor.Movies[0].Title);
            vm.Actor = new Actor();
            vm.Actor = actor;
            this.BindingContext = vm;
        }
    }
}