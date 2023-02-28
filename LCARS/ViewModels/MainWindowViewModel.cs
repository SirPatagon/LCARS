using ReactiveUI;
using System;

namespace LCARS.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; }

        public MainWindowViewModel(/*Func<SampleViewModel>*/)
        {
            Router = new RoutingState();
            //Router.Navigate.Execute(SampleViewModelFunc());
        }

        public string Greeting => "Welcome to Avalonia!";
    }
}