using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoBarber.App.Components.Layout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryComponent : ContentView
    {
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
                                                         propertyName: "PlaceholderProperty",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(EntryComponent),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: SetPlaceholder);

        public static void SetPlaceholder(BindableObject bindable, object oldValue, object newValue)
        {
            var ui = (EntryComponent)bindable;
            ui.Entry.Placeholder = newValue.ToString();
        }

        public EntryComponent()
        {
            InitializeComponent();
        }
    }
}