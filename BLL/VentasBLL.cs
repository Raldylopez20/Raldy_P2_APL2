using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Raldy_P2_APL2.DAL;
using Raldy_P2_APL2.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Raldy_P2_APL2.BLL
{
    public class VentasBLL
    {

        //*********************************************************** BUSCAR*****************************************************************

        public static Ventas Buscar(int id)
        {
            Ventas venta = new Ventas();
            Contexto contexto = new Contexto();

            try
            {
                venta = contexto.Ventas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return venta;
        }

        //*********************************************************** LISTA*****************************************************************

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            List<Ventas> Lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Ventas.Where(venta).ToList();
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

        //*********************************************************** PENDIENTES*****************************************************************

        public static async Task<List<CobrosDetalle>> GetVentasPendiente(int clienteId)
        {
            var pendientes = new List<CobrosDetalle>();
            Contexto contexto = new Contexto();

            var ventas = await contexto.Ventas
                .Where(v => v.ClienteId == clienteId && v.Balance > 0)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in ventas)
            {
                pendientes.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0
                });
            }

            return pendientes;
        }

        //*********************************************************** COBRADAS*****************************************************************

        public static async Task<List<CobrosDetalle>> GetVentasCobradas(int clienteId)
        {
            var pendientes = new List<CobrosDetalle>();
            Contexto contexto = new Contexto();

            var ventas = await contexto.Ventas
                .Where(v => v.ClienteId == clienteId && v.Balance == 0)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in ventas)
            {
                pendientes.Add(new CobrosDetalle
                {
                    VentaId = item.VentaId,
                    Venta = item,
                    Cobrado = 0
                });
            }

            return pendientes;
        }

        //****************************************************************************************************************************

    }
}
