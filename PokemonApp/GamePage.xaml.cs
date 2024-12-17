namespace PokemonApp.ViewModels;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel gameVM)
	{
		InitializeComponent();
		BindingContext = gameVM;
        gameVM.Title = "Who's that Pokémon?";
    }
}