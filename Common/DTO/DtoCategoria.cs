﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCategoria
    {

             
        public int idCategoria { get; set; }

        [DisplayName("Nombre categoría")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido!")]
        [StringLength(50, ErrorMessage = "El {0}  no debe superar los {1} caracteres")]
        public string Nombre { get; set; }


    }
}
