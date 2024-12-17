using PokemonApp.Models;
using PokemonApp.ViewModels;

namespace PokemonApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
                
            BindingContext = vm;
         }
    }

}
