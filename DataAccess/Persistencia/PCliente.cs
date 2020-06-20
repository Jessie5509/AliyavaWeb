using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PCliente
    {
        public void RegistrarCliente(DtoCliente dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                { 
                    try
                    {
                        Cliente nuevoCliente = new Cliente();
                        nuevoCliente.Nombre = dto.Nombre;
                        nuevoCliente.Apellido = dto.Apellido;
                        nuevoCliente.Direccion = dto.Direccion;
                        nuevoCliente.email = dto.email;
                        nuevoCliente.NombreUsuario = dto.NombreUsuario;
                        nuevoCliente.Telefono = dto.Telefono;
                        nuevoCliente.contraseña = dto.contraseña;

                        context.Cliente.Add(nuevoCliente);
                        context.SaveChanges();

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }

            }
        }


        public DtoCliente getDataCli(string password)
        {
            DtoCliente dtoCli = new DtoCliente();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente clienteByPassword = context.Cliente.FirstOrDefault(f => f.contraseña == password);
                dtoCli = MCliente.MapToDto(clienteByPassword);
            }

                return dtoCli;
        }

        public void UpdateCliente(DtoCliente dtoCliente)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente updateCliente = context.Cliente.FirstOrDefault(f => f.contraseña == dtoCliente.contraseña && f.idCliente == dtoCliente.idCliente);
                updateCliente.Nombre = dtoCliente.Nombre;
                updateCliente.Apellido = dtoCliente.Apellido;
                updateCliente.NombreUsuario = dtoCliente.NombreUsuario;
                updateCliente.Direccion = dtoCliente.Direccion;
                updateCliente.Telefono = dtoCliente.Telefono;
                updateCliente.email = dtoCliente.email;
                updateCliente.contraseña = dtoCliente.contraseña;
               
                context.SaveChanges();
            }
        }


    }
}
