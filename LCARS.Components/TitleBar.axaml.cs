using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace LCARS.Components
{
    public class TitleBar : TemplatedControl
    {
        public static readonly StyledProperty<string> NodeNameProperty =
            AvaloniaProperty.Register<TitleBar, string>(nameof(NodeName), "FooBar");
        public string NodeName
        {
            get => GetValue(NodeNameProperty);
            set => SetValue(NodeNameProperty, value?.ToUpper());
        }
    }
}
