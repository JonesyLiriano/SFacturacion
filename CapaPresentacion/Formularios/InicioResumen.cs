﻿using CapaPresentacion;
using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFacturacion
{
    public partial class InicioResumen : Form
    {
        ProductosNegocio productosNegocio = new ProductosNegocio();
        SistemaResumenNegocio sistemaResumenNegocio = new SistemaResumenNegocio();
        List<proc_ResumenSistema_Result> proc_ResumenSistema_Results;
        List<proc_CargarProductosMasVendidos_Result> proc_CargarProductosMasVendidos_Results;
        public InicioResumen()
        {
            InitializeComponent();
        }

        private void InicioResumen_Load(object sender, EventArgs e)
        {
            InicicializarLabelSistemaResumen();
            CargarProductoExistenciaBajaDGV();
            CargarProductosMasVendidosChart();
        }

        private void CargarProductosMasVendidosChart()
        {
            proc_CargarProductosMasVendidos_Results = productosNegocio.CargarProductosMasVendidos().ToList();
            chartProductosMasVendidos.Series["Series1"].IsValueShownAsLabel = true;
            foreach (proc_CargarProductosMasVendidos_Result producto in proc_CargarProductosMasVendidos_Results)
            {
                chartProductosMasVendidos.Series["Series1"].Points.AddXY(producto.Descripcion, producto.CantidadVendida);
            }           

        }
        private void CargarProductoExistenciaBajaDGV()
        {

            dgvProductos.DataSource = productosNegocio.CargarProductosExistBaja();
            dgvProductos.Columns["ProductoID"].DisplayIndex = 0;
            dgvProductos.Columns["CodigoBarra"].DisplayIndex = 1;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 2;
            dgvProductos.Columns["Proveedor"].DisplayIndex = 3;
            dgvProductos.Columns["UnidadMedida"].DisplayIndex = 4;
            dgvProductos.Columns["Existencia"].DisplayIndex = 5;
            dgvProductos.Columns["CantMin"].DisplayIndex = 6;
            dgvProductos.Columns["CantMax"].DisplayIndex = 7;

            dgvProductos.Columns["Existencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["CantMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["CantMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void InicicializarLabelSistemaResumen()
        {
            try
            {
                proc_ResumenSistema_Results = sistemaResumenNegocio.ResumenSistema().ToList();
                labelClientes.Text = proc_ResumenSistema_Results.FirstOrDefault().Clientes.ToString();
                labelProveedores.Text = proc_ResumenSistema_Results.FirstOrDefault().Proveedores.ToString();
                labelProductos.Text = proc_ResumenSistema_Results.FirstOrDefault().Productos.ToString();
                labelVentas.Text = proc_ResumenSistema_Results.FirstOrDefault().Ventas.ToString();
                labelCompras.Text = proc_ResumenSistema_Results.FirstOrDefault().Compras.ToString();
                labelCotizaciones.Text = proc_ResumenSistema_Results.FirstOrDefault().Cotizaciones.ToString();
                labelNotasCredito.Text = proc_ResumenSistema_Results.FirstOrDefault().NotasCreditos.ToString();
                labelCXC.Text = proc_ResumenSistema_Results.FirstOrDefault().CXC.ToString();
                labelCXP.Text = proc_ResumenSistema_Results.FirstOrDefault().CXP.ToString();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: El resumen del sistema no pudo ser cargado correctamente, intente de nuevo por favor." + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }
    }
}
