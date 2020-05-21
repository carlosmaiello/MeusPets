using MeusPets.Dados;
using MeusPets.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeusPets.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormPage : ContentPage
    {
        private PetDatabase petDatabase;
        public FormPage()
        {
            InitializeComponent();

            String dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "MeusPets.db3"
            );

            petDatabase = new PetDatabase(dbPath);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            Pet pet = new Pet();
            pet.Nome = NomeEntry.Text;
            pet.Raca = RacaEntry.Text;
            pet.Nascimento = NascimentoPicker.Date;

            await petDatabase.SalvarPetAsync(pet);

            await Navigation.PopModalAsync();

        }
    }
}