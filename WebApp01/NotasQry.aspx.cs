using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace WebApp01
{
    public partial class NotasQry : System.Web.UI.Page
    {

        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");

            Label1.Text = "Notas de " + Request["nombre"];
            int idalumno = Convert.ToInt32(Request["idalumno"]);

            SqlCommand cm = new SqlCommand("SELECT idnota, nota FROM notas WHERE idalumno = " + idalumno, cn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = e.CommandName; // viene DEL o UPD

            // PARA TOMAR EL IDNOTA

            int index = Convert.ToInt32(e.CommandArgument); // el indice de la fila
            GridViewRow row = GridView1.Rows[index];
            int idnota = Convert.ToInt32(row.Cells[0].Text); // esta en la columna 0

            Response.Redirect("NotasInsDelUpd.aspx?accion=" + accion + "&idnota=" + idnota);
        }
    }
}