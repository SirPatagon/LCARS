using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DryIoc;
using LCARS.Views;
using Splat.DryIoc;

namespace LCARS
{
    public partial class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            var container = new Container()
                .With(c => c.WithAutoConcreteTypeResolution());

            container.RegisterViewsAndViewModels();
            container.UseDryIocDependencyResolver();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = container.Resolve<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}