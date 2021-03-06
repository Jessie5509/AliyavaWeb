﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCliente
    {
        public int idCliente { get; set; }

        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Telefono { get; set; }
       
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string NombreUsuario { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Apellido { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(75, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string email { get; set; }

        [DisplayName("Contraseña")]
        public string contraseña { get; set; }

        [DisplayName("Latitud")]
        public Nullable<decimal> latitud { get; set; }
        [DisplayName("Longitud")]
        public Nullable<decimal> longitud { get; set; }




    }
}
