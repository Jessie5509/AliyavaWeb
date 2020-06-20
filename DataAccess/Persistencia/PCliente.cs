using Common.DTO;
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


        public DtoCliente getDataCli()
        {
            DtoCliente dtoCli = new DtoCliente();


            return dtoCli;
        }

    }
}
