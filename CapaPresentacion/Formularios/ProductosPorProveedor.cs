﻿using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class ProductosPorProveedor : Form
    {
        ProductosNegocio productosNegocio = new ProductosNegocio();
        List<proc_CargarProductosExistBajaPorProveedor_Result> proc_CargarProductosExistBajaPorProveedor_Results;
        List<proc_CargarProductosPorProveedor_Result> proc_BuscarProductosPorProveedor_Results;
        public static DataTable dtProductosMarcados;
        private int proveedorID;
        public ProductosPorProveedor(int proveedorID)
        {
            InitializeComponent();
            this.proveedorID = proveedorID;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicializarDataTable()
        {
            dtProductosMarcados = new DataTable();
            dtProductosMarcados.Columns.Add("ProductoID", typeof(int));
            dtProductosMarcados.Columns.Add("Descripcion", typeof(string));
            dtProductosMarcados.Columns.Add("UnidadMedida", typeof(string));
            dtProductosMarcados.Columns.Add("Existencia", typeof(double));
            dtProductosMarcados.Columns.Add("PrecioCompra", typeof(decimal));
            dtProductosMarcados.Columns.Add("CantMin", typeof(double));
            dtProductosMarcados.Columns.Add("CantMax", typeof(double));
            
        }

        private void CargarDataGridView()
        {
            if (checkBoxProdExistBaja.Checked == true)
            {
                proc_CargarProductosExistBajaPorProveedor_Results = productosNegocio.CargarProductosExistBajaPorProveedor(proveedorID).ToList();
                dgvProductos.DataSource = proc_CargarProductosExistBajaPorProveedor_Results;
            }
            else
            {
                proc_BuscarProductosPorProveedor_Results = productosNegocio.CargarProductosPorProveedor(proveedorID).ToList();
                dgvProductos.DataSource = proc_BuscarProductosPorProveedor_Results;
            }
            OrdenarColumnasDGV();
            
        }

        private void OrdenarColumnasDGV()
        {
            dgvProductos.Columns["Seleccionar"].DisplayIndex = 0;
            dgvProductos.Columns["ProductoID"].DisplayIndex = 1;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 2;
            dgvProductos.Columns["UnidadMedida"].DisplayIndex = 3;
            dgvProductos.Columns["Existencia"].DisplayIndex = 4;
            dgvProductos.Columns["PrecioCompra"].DisplayIndex = 5;
            dgvProductos.Columns["CantMin"].DisplayIndex = 6;
            dgvProductos.Columns["CantMax"].DisplayIndex = 7;

            dgvProductos.Columns["CantMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["CantMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Existencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["ProductoID"].ReadOnly = true;
            dgvProductos.Columns["Descripcion"].ReadOnly = true;
            dgvProductos.Columns["UnidadMedida"].ReadOnly = true;
            dgvProductos.Columns["Existencia"].ReadOnly = true;
            dgvProductos.Columns["PrecioCompra"].ReadOnly = true;
            dgvProductos.Columns["CantMin"].ReadOnly = true;
            dgvProductos.Columns["CantMax"].ReadOnly = true;
            dgvProductos.Refresh();
        }

        private void checkBoxProdExistBaja_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDataGridView();

            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: No se ha podido cargar los productos correctamente, intente de nuevo por favor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void ProductosPorProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarDataTable();
                CargarDataGridView();
                CargarCBFiltro();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se ha podido cargar los productos correctamente, intente de nuevo por favor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductos.Rows.Count > 0)
                {
                    MarcarODesmarcarTodo(true);
                }
                else
                {
                    MessageBox.Show("No hay productos en el carrito para marcar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }                
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: No se ha podido marcar los productos correctamente, intente de nuevo por favor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    MarcarODesmarcarTodo(false);
                }
                else
                {
                    MessageBox.Show("No hay productos en el carrito para desmarcar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }                

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se ha podido desmarcar los productos correctamente, intente de nuevo por favor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void MarcarODesmarcarTodo(bool valor)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
                row.Cells["Seleccionar"].Value = valor;

            dgvProductos.RefreshEdit();

        }

        private void ProductosMarcados()
        {
            dtProductosMarcados.Rows.Clear();
            foreach (DataGridViewRow rowMarcados in dgvProductos.Rows)
            {
                if (Convert.ToBoolean(rowMarcados.Cells["Seleccionar"].Value) == true)
                {
                    dtProductosMarcados.Rows.Add(
                          Convert.ToInt32(rowMarcados.Cells["ProductoID"].Value)
                        , Convert.ToString(rowMarcados.Cells["Descripcion"].Value)
                        , Convert.ToString(rowMarcados.Cells["UnidadMedida"].Value)
                        , Convert.ToString(rowMarcados.Cells["Existencia"].Value)
                        , Convert.ToDouble(rowMarcados.Cells["PrecioCompra"].Value)
                        , Convert.ToDouble(rowMarcados.Cells["CantMin"].Value)
                        , Convert.ToDouble(rowMarcados.Cells["CantMax"].Value));
                    }
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count > 0)
                {
                    ProductosMarcados();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No hay productos en el carrito para seleccionar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
           
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: No se ha podido seleccionar los productos correctamente, intente de nuevo por favor.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void CargarCBFiltro()
        {
            cbFiltro.Items.Add("ID");
            cbFiltro.Items.Add("Descripcion");
            cbFiltro.Items.Add("Unidad de Medida");
            cbFiltro.SelectedIndex = 2;
        }
        private void txtFiltro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                txtFiltro.Text = "Escriba para filtrar...";
                txtFiltro.ForeColor = Color.Gray;
            }
        }

        private void txtFiltro_Enter(object sender, EventArgs e)
        {
            if (txtFiltro.Text == "Escriba para filtrar...")
            {
                txtFiltro.Text = "";
                txtFiltro.ForeColor = Color.Black;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltro.Text != "Escriba para filtrar...")
                {
                    if(checkBoxProdExistBaja.Checked)
                    {
                        switch (cbFiltro.SelectedItem.ToString())
                        {
                            case "ID":
                                dgvProductos.DataSource = proc_CargarProductosExistBajaPorProveedor_Results.Where(p => p.ProductoID.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            case "Descripcion":
                                dgvProductos.DataSource = proc_CargarProductosExistBajaPorProveedor_Results.Where(p => p.Descripcion.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            case "Unidad de Medida":
                                dgvProductos.DataSource = proc_CargarProductosExistBajaPorProveedor_Results.Where(p => p.UnidadMedida.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (cbFiltro.SelectedItem.ToString())
                        {
                            case "ID":
                                dgvProductos.DataSource = proc_BuscarProductosPorProveedor_Results.Where(p => p.ProductoID.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            case "Descripcion":
                                dgvProductos.DataSource = proc_BuscarProductosPorProveedor_Results.Where(p => p.Descripcion.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            case "Unidad de Medida":
                                dgvProductos.DataSource = proc_BuscarProductosPorProveedor_Results.Where(p => p.UnidadMedida.ToString().ToLower().Contains(txtFiltro.Text.ToLower())).ToList();
                                break;
                            default:
                                break;
                        }
                    }                    
                }
                OrdenarColumnasDGV();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se ha podido realizar la busqueda, intente de nuevo por favor.",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void cbFiltro_Validating(object sender, CancelEventArgs e)
        {
            if (cbFiltro.SelectedIndex == -1 && cbFiltro.Items.Count > 0)
            {
                cbFiltro.Focus();
            }
        }
        private void MarcarProductoGrid()
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                dgvProductos.CurrentRow.Cells["Seleccionar"].Value = !Convert.ToBoolean(dgvProductos.CurrentRow.Cells["Seleccionar"].Value);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    txtFiltro.Focus();
                    return true;
                case Keys.F2:
                    dgvProductos.Focus();
                    return true;
                case Keys.F3:
                    checkBoxProdExistBaja.Checked = !checkBoxProdExistBaja.Checked;
                    return true;
                case Keys.F4:
                    MarcarProductoGrid();
                    return true;
                case Keys.F5:
                    btnSeleccionar.PerformClick();
                    return true;
                case Keys.F6:
                    btnMarcarTodos.PerformClick();
                    return true;
                case Keys.F7:
                    btnDesmarcarTodos.PerformClick();
                    return true;

                case Keys.Escape:
                    this.Close();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

        }
    }
}
