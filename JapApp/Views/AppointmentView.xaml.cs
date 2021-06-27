using System;
using System.Collections.Generic;
using JapApp.Models;
using JapApp.ViewModels;
using Xamarin.Forms;

namespace JapApp.Views
{
    public partial class AppointmentView : ContentPage
    {
        public AppointmentView(AppointmentViewModel viewModel
            )
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;

        }
    }
}
