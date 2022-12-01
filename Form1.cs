using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MaestroDetalleWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) /*boton de guardar*/
        {
            
         
               string Cantidad = txtCantidad.Text;  /*mostrar en grilla los escrito de los texbox*/
             string Nombre = txtNombre.Text;
            
            string Precio = txtPrecio.Text;

             dgvConceptos.Rows.Add(new object[] /*nombre de la grilla, Row:trae columnas de grilla, Add=insertar dato en esas columnas crea un objeto "new object"*/
             { 
                 Cantidad,Nombre,Precio,"Eliminar"/*declara los elementos, parametros,en el boton solo el texto */

        });

            txtCantidad.Text = ""; /*espacio de textbox en blanco*/
            txtNombre.Text = "";
            txtPrecio.Text = "";
             txtCantidad.Focus();/*al tocar enter pasa de un texbox al siguiente, arranca desde cantidad*/
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            try
                {
                List<Concepto>lst= new List<Concepto>();

                //llenado de elemento detalles

                foreach(DataGridViewRow dr in dgvConceptos.Rows)
                {
                    Concepto oConcepto = new Concepto();
                    oConcepto.Cantidad = int.Parse(dr.Cells[0].Value.ToString());
                    oConcepto.Nombre = dr.Cells[1].Value.ToString();
                    oConcepto.Precio = decimal.Parse(dr.Cells[2].Value.ToString());
                    lst.Add(oConcepto);


                }
                VentaDB oVenta = new VentaDB(); /*creo evento*/
                oVenta.Add(txtCliente.Text,lst);/*trae elementos de evento creado el evento recibe lo de txt y lista*/


                MessageBox.Show("venta realizada");/*mensaje */

                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);/*mensaje */
            }
    
        
        }
}
}
