using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace QuizBackEnd.Models
{
    public class PokemonModel
    {
        [Key]
        public int ID { get; set; }

        public int Numero { get; set; }

        public string Nombre { get; set; }

        public string TipoPrincipal { get; set; }

        public string TipoSecundario { get; set; }
    }
}