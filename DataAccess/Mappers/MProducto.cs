using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MProducto
    {

        public static DtoProducto MapToDto(Producto entity)
        {
            DtoProducto dto = new DtoProducto();
            dto.Codigo = entity.Codigo;
            dto.Descripcion = entity.Descripcion;
            dto.Familia = entity.Familia;
            dto.PrecioVenta = entity.PrecioVenta;
            dto.codigoBarras = entity.codigo_barras;
            dto.ProDescripcion = entity.ProDescripcion;
            dto.CantidadPreparar = entity.CantidadPreparar;
            dto.ImagenPro = entity.ImagenPro;

            return dto;
        }



        public static Producto MapToEntity(DtoProducto dto)
        {
            Producto entity = new Producto();
            entity.Codigo = dto.Codigo;
            entity.Descripcion = dto.Descripcion;
            entity.Familia = dto.Familia;
            entity.PrecioVenta = dto.PrecioVenta;
            entity.codigo_barras = dto.codigoBarras;
            entity.ProDescripcion = dto.ProDescripcion;
            entity.CantidadPreparar = dto.CantidadPreparar;
            entity.ImagenPro = dto.ImagenPro;

            return entity;
        }

    }
}
