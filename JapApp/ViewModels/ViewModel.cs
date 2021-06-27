using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace JapApp.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
        }

        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
