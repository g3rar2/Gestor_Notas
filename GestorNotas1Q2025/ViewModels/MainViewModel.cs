
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorNotas1Q2025.Models;
using GestorNotas1Q2025.Services;
using GestorNotas1Q2025.Views;

namespace GestorNotas1Q2025.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        [RelayCommand]
        private async Task GoToAddEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }


        [ObservableProperty]
        private ObservableCollection<NotaModel> notaCollection = new ObservableCollection<NotaModel>();

        [ObservableProperty]
        private string buscarNota; 

        private readonly NotaService _service;

        public MainViewModel()
        {
            _service = new NotaService();
        }

        
        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var list = _service.GetAll();


            if (list.Count>0)
            {
                NotaCollection.Clear();

                foreach (var nota in list)
                {
                    NotaCollection.Add(nota);
                }
            }
            
            
        }



        [RelayCommand]
        private async Task GoToAdEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }

        [RelayCommand]
        private async Task GoToEdit(NotaModel Nota)
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(Nota));
        }

        [RelayCommand]
        private async Task Select(NotaModel Nota)
        {
            try
            {
                const string ACTUALIZAR= "Actualizar";
                const string ELIMINAR= "Eliminar";
                
                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR,ELIMINAR);

                if (res==ACTUALIZAR)
                {
                    await GoToEdit(Nota);
                }
                else if (res == ELIMINAR)
                {
                    await Eliminar(Nota);
                }
                
                
                
                
            }
            catch (Exception ex)
            {
                Alerta("Error",ex.Message);
                throw;
            }
        }


        [RelayCommand]
        public void Buscar()
        {
            try
            {
                notaCollection.Clear();
                var resultado = _service.GetAll(BuscarNota); 

                foreach(var nota in resultado)
                {
                    notaCollection.Add(nota); 
                }

            }catch(Exception e)
            {
                Alerta("ERROR", e.Message); 
            }
        }

        partial void OnBuscarNotaChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                GetAll(); 
            }
            else
            {
                Buscar(); 
            }
        }

        private async Task Eliminar(NotaModel Nota)
        {
            try
            {
                bool respuesta=await App.Current!.MainPage.DisplayAlert("ELIMINAR PRODUCTO","Desea Eliminar el producto?", "Si", "No");

                if (respuesta)
                {
                    int del = _service.Delete(Nota);


                    if (del>0)
                    {
                        Alerta("ELIMINAR NOTA","Producto Eliminado Correctamente");
                        NotaCollection.Remove(Nota);
                    }
                } 
                
                
                
                
            }
            catch (Exception ex)
            {
                Alerta("Error",ex.Message);
                throw;
            }
        }
        
        
    }
}
