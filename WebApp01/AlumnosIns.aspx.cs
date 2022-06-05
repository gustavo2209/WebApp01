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
    public partial class AlumnosIns : System.Web.UI.Page
    {

        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombre = Request["TextBox1"];
            
            if(nombre.Trim().Length > 0)
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = "INSERT INTO alumnos2 VALUES('" + TextBox1.Text + "')"; // PUEDE SER LA VARIABLE 'NOMBRE'

                cn.Open();
                
                cm.ExecuteNonQuery();
                cn.Close();

                Response.Redirect("Main.aspx");
            }
            else
            {
                Session["msg"] = "Debe ingresar nombre del Alumno";
                Response.Redirect("Mensajes.aspx");
            }
        }
    }
}