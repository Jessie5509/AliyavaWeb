using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PCategoria
    {

        public void RegistrarCategoria(DtoCategoria dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria Cat = new Categoria();
                Cat.nombre = dto.Nombre;
                Cat.idProducto = dto.idProducto;


                context.Categoria.Add(Cat);
                context.SaveChanges();

            }
        }


        public List<DtoCategoria> GetCategoria()
        {
            List<DtoCategoria> coldtoCat = new List<DtoCategoria>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Categoria> colCategoria = context.Categoria.Select(s => s).ToList();

                foreach (Categoria cat in colCategoria)
                {
                    DtoCategoria dto = MCategoria.MapToDto(cat);
                    coldtoCat.Add(dto);
                }
            }
            return coldtoCat;
        }


        public void RemoveCategoria(DtoCategoria dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Categoria cat = MCategoria.MapToEntity(dto);

                context.Stock.Remove(cat);
                context.SaveChanges();

            }


        }

        public DtoProducto GetCategoriaM(int Codigo)
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
                updatePro.Codigo = DtoProdu.Codigo;
                updatePro.Descripcion = DtoProdu.Descripcion;
                updatePro.Familia = DtoProdu.Familia;
                updatePro.PrecioVenta = DtoProdu.PrecioVenta;
                context.SaveChanges();
            }
        }

    }
}
