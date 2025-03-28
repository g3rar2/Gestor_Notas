using GestorNotas1Q2025.Models;
using GestorNotas1Q2025.ViewModels;

namespace GestorNotas1Q2025.Views;

public partial class AddEditView : ContentPage
{
	
	AddEditViewModel viewModel;
	public AddEditView()
	{
		InitializeComponent();
		viewModel = new AddEditViewModel();
		BindingContext = viewModel;
	}
	
	public AddEditView(NotaModel Nota)
	{
		InitializeComponent();
		viewModel = new AddEditViewModel(Nota);
		BindingContext = viewModel;
	}	
	
	
	
	
}