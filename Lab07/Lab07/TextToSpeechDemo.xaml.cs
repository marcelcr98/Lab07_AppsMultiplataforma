
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab07
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextToSpeechDemo : ContentPage
    {
        public TextToSpeechDemo()
        {
            InitializeComponent();
            var stack = new StackLayout();


            // Text-to-Speech
            var speak = new Button
            {
                Text = "Hola, Todos (Presioname) !",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            speak.Clicked += (sender, e) =>
            {
                DependencyService.Get<ITextToSpeech>().Speak("Hola de Xamarin Forms por Vilcapoma");
            };
            stack.Children.Add(speak);

            Content = speak;
        }
    }
}