//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    
    public partial class proc_CargarFacturasCFiscalPFecha_Result
    {
        public int FacturaID { get; set; }
        public string Usuario { get; set; }
        public int ClienteID { get; set; }
        public Nullable<decimal> DescuentoCliente { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TipoDePago { get; set; }
        public string TipoFactura { get; set; }
        public Nullable<int> Cotizacion { get; set; }
        public string NCF { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> ITBIS { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public string RNC { get; set; }
        public string Entidad { get; set; }
        public string Cliente { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
    }
}