using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HCategoria
    {

        private static HCategoria _instance;
        public static HCategoria getInstace()
        {
            if (_instance == null)
            {
                _instance = new HCategoria();
            }

            return _instance;
        }

        public void AddCategoria(DtoCategoria dto)
        {
            PCategoria pc = new PCategoria();
            pc.RegistrarCategoria(dto);
        }

        public List<DtoCategoria> GetCategoria()
        {
            PCategoria pc = new PCategoria();
            return pc.GetCategoria();
        }

        public void RemoveCategoria(int id)
        {
            PCategoria ps = new PCategoria();
            ps.RemoveCategoria(id);
        }

        public void ModificarCategoria(DtoCategoria dto)
        {
            PCategoria pc = new PCategoria();
            pc.ModificarCategoria(dto);
        }

        public DtoCategoria GetCategoriaM(int id)
        {
            PCategoria pc = new PCategoria();
            return pc.GetCategoriaM(id);
        }

    }
}
