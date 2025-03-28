using GestorNotas1Q2025.ViewModels;

namespace GestorNotas1Q2025.Views;

public partial class MainView : ContentPage
{
	private MainViewModel viewModel;
	public MainView()
	{
		InitializeComponent();
		viewModel = new MainViewModel();
		BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		viewModel.GetAll();
	}
	
	
	
}