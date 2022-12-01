using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MaestroDetalleWindowsForm
{
    public class Concepto
    {
      /*clase para representar elementos de lista en sql, solo sirve de estructura*/

        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
