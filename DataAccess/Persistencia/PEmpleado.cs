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
    public class PEmpleado
    {
        public bool existeEmpleado(DtoEmpleado dto)
        {
            bool existe = false;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                existe = context.Empleado.Any(a => a.idEmpleado == dto.idEmpleado &&
                a.NombreUsuario == dto.NombreUsuario && a.contraseña == dto.contraseña);

            }

            return existe;
        }

        public void RegistrarEmpleado(DtoEmpleado dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Empleado nuevoEmpleado = new Empleado();
                        nuevoEmpleado.NombreUsuario = dto.NombreUsuario;
                        nuevoEmpleado.contraseña = dto.contraseña;
                        nuevoEmpleado.email = dto.email;
    
                        context.Empleado.Add(nuevoEmpleado);
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


    }
}
