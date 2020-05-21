using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MeusPets.Dados;
using MeusPets.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusPets.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPage : ContentPage
    {
        public ListaPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            String dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MeusPets.db3"
            );

            var petDatabase = new PetDatabase(dbPath);  
            
            List<Pet> lista = await petDatabase.ConsultarPetTodosAsync();

            PetsLista.ItemsSource = lista;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FormPage());
        }
    }
}