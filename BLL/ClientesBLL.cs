using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Raldy_P2_APL2.DAL;
using Raldy_P2_APL2.Models;
using System.Linq.Expressions;

namespace Raldy_P2_APL2.BLL
{
    public class ClientesBLL
    {

        //*********************************************************** LISTA*****************************************************************

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Clientes.Where(cliente).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }


        //****************************************************************************************************************************
    }
}
