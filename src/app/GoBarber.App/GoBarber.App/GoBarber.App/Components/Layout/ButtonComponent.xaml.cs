using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoBarber.App.Components.Layout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonComponent : ContentView
    {
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly BindableProperty LabelProperty = BindableProperty.Create(
                                                         propertyName: "LabelProperty",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(ButtonComponent),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: SetLabel);

        public ButtonComponent()
        {
            InitializeComponent();
        }

        public static void SetLabel(BindableObject bindable, object oldValue, object newValue)
        {
            var ui = (ButtonComponent)bindable;
            ui.Btn.Text = newValue.ToString();
        }
    }
}