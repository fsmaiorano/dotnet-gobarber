using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoBarber.App.Components.Layout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryComponent : ContentView
    {
        public bool isPassword = false;

        public EntryComponent()
        {
            InitializeComponent();
            //this.Entry_Unfocused(CustomEntry, null);
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
                                                      propertyName: "IsPasswordProperty",
                                                      returnType: typeof(bool),
                                                      declaringType: typeof(EntryComponent),
                                                      defaultValue: false,
                                                      defaultBindingMode: BindingMode.TwoWay,
                                                      propertyChanged: SetIsPassword);



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
            ui.CustomEntry.TextColor = (Color)App.Current.Resources["PrimaryColor"];
        }

        public static void SetPlaceholderColor(BindableObject bindable, object oldColor, object newColor)
        {
            var ui = (EntryComponent)bindable;
            ui.CustomEntry.PlaceholderColor = (Color)App.Current.Resources["PrimaryColor"];
        }

        public static void SetIsPassword(BindableObject bindable, object oldValue, object newValue)
        {
            var ui = (EntryComponent)bindable;
            ui.CustomEntry.IsPassword = (bool)newValue;
        }

        public async void Entry_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            var entry = sender as Entry;
        }

        private async void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            var entry = sender as Entry;
            entry.TextColor = (Color)App.Current.Resources["PrimaryColor"];
            entry.PlaceholderColor = (Color)App.Current.Resources["SecondaryColor"];
        }
    }
}