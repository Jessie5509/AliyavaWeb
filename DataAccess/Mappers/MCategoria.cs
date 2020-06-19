using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MCategoria
    {

        public static DtoCategoria MapToDto(Categoria entity)
        {
            DtoCategoria dto = new DtoCategoria();
            dto.Nombre = entity.Nombre;
            dto.idProducto = entity.idProducto;

            return dto;
        }

        public static Categoria MapToEntity(DtoCategoria dto)
        {
            Categoria entity = new Categoria();
            entity.Nombre = dto.Nombre;
            entity.idProducto = dto.idProducto;

            return entity;
        }

    }
}
