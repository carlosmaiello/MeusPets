using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeusPets.Modelos;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace MeusPets.Dados
{
    public class PetDatabase
    {

        readonly SQLiteAsyncConnection _database;

        public PetDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pet>().Wait();
            _database.CreateTableAsync<Vacina>().Wait();
        }

        public Task<int> SalvarPetAsync(Pet pet)
        {
            if (pet.Id == 0)
            {
                return _database.InsertAsync(pet);
            }
            else
            {
                return _database.UpdateAsync(pet);
            }
        }

        public Task<List<Pet>> ConsultarPetTodosAsync()
        {
            return _database.GetAllWithChildrenAsync<Pet>();
        }

        public Task<Pet> ConsultarPetAsync(int id)
        {
            return _database.GetWithChildrenAsync<Pet>(id);
        }


        public Task<int> SalvarVacinaAsync(Vacina vacina)
        {
            if (vacina.Id == 0)
            {
                return _database.InsertAsync(vacina);
            }
            else
            {
                return _database.UpdateAsync(vacina);
            }
        }

        public Task<List<Vacina>> ConsultarVacinaTodosAsync()
        {
            return _database.GetAllWithChildrenAsync<Vacina>();
        }

        public Task<Vacina> ConsultarVacinaAsync(int id)
        {
            return _database.GetWithChildrenAsync<Vacina>(id);
        }
    }
}
