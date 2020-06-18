using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PProducto
    {

        public void RegistarProducto(DtoProducto dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto nProducto = new Producto();
                nProducto.Codigo = dto.Codigo;
                nProducto.Descripcion = dto.Descripcion;
                nProducto.Familia = dto.Familia;
                nProducto.PrecioVenta = dto.PrecioVenta;
                

                context.Producto.Add(nProducto);
                context.SaveChanges();

            }
        }

/*
        public List<DtoProducto> GetProducto()
        {
            List<DtoProducto> colDtoProducto = new List<DtoProducto>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Producto> colProducto = context.Producto.Select(s => s).ToList();

                foreach (Producto pro in colProducto)
                {
                    DtoProducto dto = MProducto.MapToDto(pro);
                    colDtoProducto.Add(dto);
                }
            }
            return colDtoProducto;
        }*/

    }
}
