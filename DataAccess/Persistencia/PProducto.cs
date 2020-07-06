using Common.DTO;
using DataAccess.Mappers;
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
                int idcat = context.Categoria.FirstOrDefault(f => f.Nombre == dto.Familia).idCategoria;

                Producto nProducto = new Producto();
                nProducto.Codigo = dto.Codigo;
                nProducto.idCategoria = idcat;
                nProducto.Descripcion = dto.Descripcion;
                nProducto.Familia = dto.Familia;
                nProducto.PrecioVenta = dto.PrecioVenta;
                nProducto.codigo_barras = dto.codigoBarras;
                nProducto.ProDescripcion = dto.ProDescripcion;
                nProducto.ImagenPro = dto.ImagenPro;

                context.Producto.Add(nProducto);
                context.SaveChanges();

            }
        }


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
        }

        public DtoProducto GetProductoCarrito(int id)
        {
            DtoProducto dto = new DtoProducto();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto Producto = context.Producto.FirstOrDefault(f => f.Codigo == id);
                Producto.CantidadPreparar = 1;
                dto = MProducto.MapToDto(Producto);
                 
                
            }

            return dto;
      
        }




        public DtoProducto GetProductoInfo(int id)
        {
            DtoProducto dto = new DtoProducto();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto Producto = context.Producto.FirstOrDefault(f => f.Codigo == id);
                dto = MProducto.MapToDto(Producto);
                

            }

            return dto;

        }




        public void RemoveProducto(int Codigo)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Producto prod = context.Producto.FirstOrDefault(f => f.Codigo == Codigo );
                context.Producto.Remove(prod);
                context.SaveChanges();

            }


        }





        public DtoProducto GetProductoM(int Codigo)
        {
            DtoProducto dto = new DtoProducto();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto prod = context.Producto.FirstOrDefault(f => f.Codigo == Codigo);

                dto = MProducto.MapToDto(prod);
            }
            return dto;
        }

        public void ModificarProducto(DtoProducto DtoProdu)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto updatePro = context.Producto.FirstOrDefault(f => f.Codigo == DtoProdu.Codigo);
                updatePro.Descripcion = DtoProdu.Descripcion;
                updatePro.Familia = DtoProdu.Familia;
                updatePro.PrecioVenta = DtoProdu.PrecioVenta;
                updatePro.ProDescripcion = DtoProdu.ProDescripcion;
                updatePro.ImagenPro = DtoProdu.ImagenPro;
        
                context.SaveChanges();
            }
        }

    }
}
