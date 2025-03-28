

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorNotas1Q2025.Models;
using GestorNotas1Q2025.Services;

namespace GestorNotas1Q2025.ViewModels
{
    public partial class AddEditViewModel:ObservableObject
    {

        [ObservableProperty]
        private int id;
        
        [ObservableProperty]
        private string titulo;
        
        [ObservableProperty]
        private string descripcion;
        
        
        private NotaService _service;
        
        
        
        public AddEditViewModel()
        {
            _service = new NotaService();
        }
            
        public AddEditViewModel(NotaModel Nota)
        {
            _service = new NotaService();
            Id = Nota.Id;
            Titulo=Nota.Titulo;
            Descripcion=Nota.Descripcion;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        
        
        private bool Validar(NotaModel Nota)
        {
            if (Nota.Titulo is null || Nota.Titulo=="")
            {
                Alerta("ADVERTENCIA","Ingrese el titulo de la nota");
                return false;
            }
            else if (Nota.Descripcion is null || Nota.Descripcion == "" )
            {
                Alerta("ADVERTENCIA","Ingrese la descripcion de la nota");
                return false;
            }
            
            return true;
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                NotaModel Nota = new NotaModel()
                {
                    Id = Id,
                    Titulo = Titulo,
                    Descripcion = Descripcion
                };

                if (Validar(Nota))
                {
                    if (Id==0)
                    {
                        _service.Insert(Nota);
                    }
                    else
                    {
                        _service.Update(Nota);
                    }

                    await App.Current!.MainPage!.Navigation.PopAsync();

                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR",ex.Message);
                throw;
            }
        }
        
        
    }
}
