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
        public EntryComponent()
        {
            InitializeComponent();
        }

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

        public string PlaceholderColor
        {
            get { return (string)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
                                                 propertyName: "PlaceholderColorProperty",
                                                 returnType: typeof(string),
                                                 declaringType: typeof(EntryComponent),
                                                 defaultValue: "",
                                                 defaultBindingMode: BindingMode.TwoWay,
                                                 propertyChanged: SetPlaceholderColor);

        public static void SetPlaceholder(BindableObject bindable, object oldValue, object newValue)
        {
            var ui = (EntryComponent)bindable;
            ui.CustomEntry.Placeholder = newValue.ToString();
        }

        public static void SetPlaceholderColor(BindableObject bindable, object oldColor, object newColor)
        {
            var ui = (EntryComponent)bindable;
            ui.CustomEntry.PlaceholderColor = (Color)(Color)Application.Current.Resources["SecondaryColor"];
        }
    }
}