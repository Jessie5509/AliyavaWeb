using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MCliente
    {
        public static DtoCliente MapToDto(Cliente entity)
        {
            DtoCliente dto = new DtoCliente();
            dto.Nombre = entity.Nombre;
            dto.Apellido = entity.Apellido;
            dto.NombreUsuario = entity.NombreUsuario;
            dto.contraseña = entity.contraseña;
            dto.Direccion = entity.Direccion;
            dto.email = entity.email;
            dto.Telefono = entity.Telefono;
     
            return dto;
        }

        public static Cliente MapToEntity(DtoCliente dto)
        {
            Cliente entity = new Cliente();
            entity.Nombre = dto.Nombre;
            entity.Apellido = dto.Apellido;
            entity.NombreUsuario = dto.NombreUsuario;
            entity.contraseña = dto.contraseña;
            entity.Direccion = dto.Direccion;
            entity.email = dto.email;
            entity.Telefono = dto.Telefono;

            return entity;
        }
    }
}
