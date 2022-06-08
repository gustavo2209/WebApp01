using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace WebApp01
{
    public partial class Main : System.Web.UI.Page
    {
        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");
            consulta();
        }

        private void consulta()
        {
            SqlCommand cm = new SqlCommand("SELECT idalumno ID, nombre Alumno FROM alumnos2", cn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);

            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = e.CommandName; // viene DEL o UPD

            // PARA TOMAR EL IDALUMNO

            int index = Convert.ToInt32(e.CommandArgument); // el indice de la fila
            GridViewRow row = GridView1.Rows[index];
            int idalumno = Convert.ToInt32(row.Cells[0].Text); // esta en la columna 0

            Response.Redirect("AlumnosDelUpd.aspx?accion=" + accion + "&idalumno=" + idalumno);
        }
    }
}