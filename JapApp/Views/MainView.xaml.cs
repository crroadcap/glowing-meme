using System;
using System.Collections.Generic;

using Xamarin.Forms;
using JapApp.ViewModels;

namespace JapApp.Views
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}
