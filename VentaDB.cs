using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MaestroDetalleWindowsForm
{
    public class VentaDB
    {
        private string ConnectionString =/*nombre de cadena de coneccion a base de datos*/
            "Data Source=winserv2019\\server2019;Initial Catalog=Nueva Bulonera;User ID=sa;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void Add(string Cliente,List<Concepto>lst) /*add insertar un cliente y en lista conceptos*/

            {
              

                 var dt = new DataTable(); /*pasa los parametros a datetable, que es un tipo de tabla */
                 dt.Columns.Add("Id");/**/
                 dt.Columns.Add("Cantidad");
                 dt.Columns.Add("Nombre");
                 dt.Columns.Add("precio");

                 int i = 1;
                 foreach (var oElement in lst)
                 {
                     dt.Rows.Add(i, oElement.Cantidad, oElement.Nombre, oElement.Precio);
                         
                            i++;
                 }


                 using (SqlConnection connection = new SqlConnection(ConnectionString))
                 {
                     SqlCommand command = new SqlCommand ("spGuardarVenta", connection); /*wjwcutar el procedimiento almacenado*/
                     
                    var parametroLista = new SqlParameter("@lstConceptos", SqlDbType.Structured);/**/
                     parametroLista.TypeName = "dbo.Detail";/*ejecuta esta tabla de parametros*/
                     parametroLista.Value = dt;/*evalua los dt*/

                     command.CommandType = System.Data.CommandType.StoredProcedure;/* ejecuta los procedimiento almacenado*/
                    command.Parameters.Add(parametroLista);/*mandar parametros a tal lista*/
                    command.Parameters.AddWithValue("@Cliente", Cliente); /*mandar parametros a tal variable */
                connection.Open();/*abre  la conecion de base de datos*/
                command.ExecuteNonQuery();/*ejecuta las consultas*/
                connection.Close();/*cierra  la conecion de base de datos*/

            }
        }

    
    }
}


