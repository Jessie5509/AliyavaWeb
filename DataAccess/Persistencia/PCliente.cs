using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PCliente
    {
        public void RegistrarCliente(DtoCliente dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.Nombre = dto.Nombre;
                nuevoCliente.Apellido = dto.Apellido;
                nuevoCliente.Direccion = dto.Direccion;
                nuevoCliente.email = dto.email;
                nuevoCliente.NombreUsuario = dto.NombreUsuario;
                nuevoCliente.Telefono = dto.Telefono;
            
                context.Cliente.Add(nuevoCliente);
                context.SaveChanges();

            }
        }

    }
}
