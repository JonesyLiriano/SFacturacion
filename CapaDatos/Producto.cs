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
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.DetalleFacturas = new HashSet<DetalleFactura>();
            this.DetalleNotaDeCreditoes = new HashSet<DetalleNotaDeCredito>();
            this.DetalleCotizaciones = new HashSet<DetalleCotizacione>();
        }
    
        public int ProductoID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> ProveedorID { get; set; }
        public Nullable<double> Existencia { get; set; }
        public Nullable<decimal> PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioVentaMin { get; set; }
        public decimal Descuento { get; set; }
        public bool ITBIS { get; set; }
        public bool Servicio { get; set; }
        public Nullable<double> CantMin { get; set; }
        public Nullable<double> CantMax { get; set; }
        public string CodigoBarra { get; set; }
        public string UnidadMedida { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleNotaDeCredito> DetalleNotaDeCreditoes { get; set; }
        public virtual Proveedore Proveedore { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCotizacione> DetalleCotizaciones { get; set; }
    }
}
