using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MeusPets.Modelos
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public String Nome { get; set; }
        [MaxLength(30)]
        public String Raca { get; set; }
        public DateTime Nascimento { get; set; }
        [OneToMany]
        public List<Vacina> Vacinas { get; set; }
    }
}