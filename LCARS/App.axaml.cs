using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DryIoc;
using LCARS.ViewModels;
using LCARS.Views;
using ReactiveUI;
using Splat.DryIoc;
using System.Linq;

namespace LCARS
{
    public partial class App : Application
    {
        private IContainer fContainer;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            fContainer = new Container().With(r => r.WithConcreteTypeDynamicRegistrations());

            // Maybe Later Implement something like this so 
            //fContainer.RegisterMany(new[] { typeof(App).Assembly }, (t) =>
            //{
            //    if (!t.IsGenericTypeDefinition)
            //    {
            //        var interfaces = t.GetInterfaces();

            //        var iView = interfaces.Where(i => i.IsGenericType && typeof(IViewFor<>).Equals(i.GetGenericTypeDefinition())).FirstOrDefault();
            //        if (iView != null)
            //            return interfaces;
            //    }
            //    return null;
            //});

            fContainer.Register(typeof(IViewFor<MainWindowViewModel>), typeof(MainWindow), made: Made.Of(FactoryMethod.ConstructorWithResolvableArguments));
            fContainer.Register(typeof(MainWindowViewModel));

            fContainer.UseDryIocDependencyResolver();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {            
                desktop.MainWindow = fContainer.Resolve<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}