using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizBackEnd.Models
{
    public class ItemModel
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Efecto { get; set; }


    }
}