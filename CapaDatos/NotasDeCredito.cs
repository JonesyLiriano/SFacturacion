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
    
    public partial class NotasDeCredito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NotasDeCredito()
        {
            this.DetalleNotaDeCreditoes = new HashSet<DetalleNotaDeCredito>();
        }
    
        public int NotaDeCreditoID { get; set; }
        public int FacturaID { get; set; }
        public int FacturaAplicarID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int UserID { get; set; }
        public string NCF { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public decimal ValorAplicado { get; set; }
        public bool ITBIS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleNotaDeCredito> DetalleNotaDeCreditoes { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual User User { get; set; }
    }
}