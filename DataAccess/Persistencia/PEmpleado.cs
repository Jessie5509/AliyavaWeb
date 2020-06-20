using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
