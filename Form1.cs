using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controldeventas
{
    public partial class frmVentas : Form
    {
        static string[] produtos = { "Teclado", "Impresora", "Monitor", "Bocinas", "Mouses" };

        
        ArrayList aProducto = new ArrayList(produtos);

        ventas objV = new ventas();

        double total;

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            MostrarFecha();
            MostrarHora();
            LimpiarCampos();
            LLenarProducto();
            lblTotalNeto.Text = "0.00";
            LimpiarCampos();



        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            objV.Producto = cobProducto.Text;
            objV.Cantidad = int.Parse(txtCantidad.Text);


            ListViewItem fila = new ListViewItem(objV.Producto);
            fila.SubItems.Add(objV.Cantidad.ToString());
            fila.SubItems.Add(objV.AsignarPrecio().ToString("C"));
            fila.SubItems.Add(objV.CalcularSubTotal().ToString("C"));
            fila.SubItems.Add(objV.CalcularDescuento().ToString("C"));
            fila.SubItems.Add(objV.CalcularNeto().ToString("C"));

            lvRegistro.Items.Add(fila);


            total += objV.CalcularNeto();


            lblTotalNeto.Text = total.ToString("C");


            LimpiarCampos();


        }

        private void cobProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            objV.Producto = cobProducto.Text;
            lblPrecio.Text = objV.AsignarPrecio().ToString("C");

        }

        private void MostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void LimpiarCampos()
        {
            txtCliente.Clear();
            cobProducto.Text = "Selecccione un producto";
            txtCantidad.Clear();
            lblPrecio.Text = "0.00";
            txtCliente.Focus();
        }

        private void LLenarProducto()
        {
            foreach (var p in aProducto)
            {
                cobProducto.Items.Add(p);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea salir..?", "Ventas", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                LimpiarCampos();
            }
        }

        

    }
}
