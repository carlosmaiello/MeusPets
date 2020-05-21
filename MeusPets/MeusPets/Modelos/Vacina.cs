using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeusPets.Modelos
{
    public class Vacina
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Descricao {get; set;}
        public DateTime Data { get; set; }
        [ForeignKey(typeof(Pet))]
        public int PetId { get; set; }
        [ManyToOne]
        public Pet Pet { get; set; }
    }
}
