using DryIoc;
using DryIoc.ImTools;
using ReactiveUI;
using System.Linq;

namespace LCARS
{
    internal static class ContainerConfig
    {
        public static void RegisterViewsAndViewModels(this IContainer container)
        {
            typeof(App).Assembly.GetTypes().ForEach(type =>
            {
                var inter = type.GetInterfaces();
                if (inter.Any())
                {
                    if (inter.Any(i => i == typeof(IReactiveObject)))
                    {
                        container.Register(type);
                        return;
                    }

                    var iViewFor = inter.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewFor<>));
                    if (iViewFor != null)
                    {
                        container.Register(iViewFor, type, made: Made.Of(FactoryMethod.ConstructorWithResolvableArguments));
                        return;
                    }
                }
            });
        }
    }
}
