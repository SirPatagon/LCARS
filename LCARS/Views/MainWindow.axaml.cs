using Avalonia.Controls;
using LCARS.ViewModels;
using ReactiveUI;

namespace LCARS.Views
{
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(MainWindowViewModel viewModel) : this()
        {
            ViewModel = viewModel;
        }

        public MainWindowViewModel? ViewModel 
        { 
            get => DataContext as MainWindowViewModel;
            set => DataContext = value;
        }
        object? IViewFor.ViewModel 
        {
            get => DataContext;
            set => DataContext = value;
        }
    }
}