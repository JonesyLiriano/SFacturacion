﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace CapaDatos
{
    public class FacturaOrdenCompraDatos
    {
        SFacturacionEntities modelDB = new SFacturacionEntities();
        ObjectParameter resultado = new ObjectParameter("resultado", typeof(bool));
        ObjectParameter facturaCompraID = new ObjectParameter("FacturaCompraID", typeof(int));

        public Tuple<bool, int> InsertarFacturaOrdenCompra( FacturasCompra facturaCompra)
        {
            modelDB.proc_InsertarFacturaCompra(facturaCompraID, facturaCompra.OrdenCompraID, facturaCompra.NCF, facturaCompra.FechaVencimiento, facturaCompra.FechaFactura, facturaCompra.TipoDePagoID, facturaCompra.SubTotal, facturaCompra.ITBIS,resultado);

            return Tuple.Create((bool)resultado.Value, (int)facturaCompraID.Value);
        }
    }
}
