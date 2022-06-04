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
            SqlCommand cm = new SqlCommand("SELECT idalumno ID, nombre Alumno FROM alumnos", cn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);

            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}