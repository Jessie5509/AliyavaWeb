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
    public class PCategoria
    {

        public bool RegistrarCategoria(DtoCategoria dto)
        {
            bool msg;
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Categoria Cat = new Categoria();
                        Cat.Nombre = dto.Nombre;

                        context.Categoria.Add(Cat);
                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return msg = false;

                    }

                    return msg = true;
                }
                

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


        public void RemoveCategoria(int id)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Categoria cat = context.Categoria.FirstOrDefault(f => f.idCategoria == id);
                Producto pro = context.Producto.FirstOrDefault(f => f.idCategoria == cat.idCategoria);
                if (pro != null)
                {
                    pro.idCategoria = null;
                }

                context.Categoria.Remove(cat);
                context.SaveChanges();

            }


        }

        public void ModificarCategoria(DtoCategoria DtoCat)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria updatecat = context.Categoria.FirstOrDefault(f => f.idCategoria == DtoCat.idCategoria);
                updatecat.Nombre = DtoCat.Nombre;
         
                context.SaveChanges();
            }
        }


        public DtoCategoria GetCategoriaM(int id)
        {
            DtoCategoria dto = new DtoCategoria();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria cat = context.Categoria.FirstOrDefault(f => f.idCategoria == id);

                dto = MCategoria.MapToDto(cat);
            }
            return dto;
        }


        public List<DtoCategoria> getCat(string familia)
        {
            List<DtoCategoria> colCatego = new List<DtoCategoria>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Categoria> colCat = context.Categoria.Where(w=> w.Nombre == familia).ToList();

                foreach (Categoria item in colCat)
                {
                    DtoCategoria dto = MCategoria.MapToDto(item);
                    colCatego.Add(dto);
                }
            }

            return colCatego;
        }



    }
}
