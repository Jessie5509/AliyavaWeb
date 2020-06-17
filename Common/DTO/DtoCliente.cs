using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCliente
    {
        public int idCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string email { get; set; }
        public int idDireccion { get; set; }
        public int idPedido { get; set; }


    }
}
