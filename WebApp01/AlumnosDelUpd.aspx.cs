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
    public partial class AlumnosDelUpd : System.Web.UI.Page
    {

        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");

            string accion = Request["accion"];
            int idalumno = Convert.ToInt32(Request["idalumno"]);

            string sql = "SELECT idalumno, nombre FROM alumnos2 WHERE idalumno = " + idalumno;
            SqlCommand cm = new SqlCommand(sql, cn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);

            // tomando el nombre del alumno

            TextBox1.Text = dt.Rows[0].ItemArray.ElementAt(1).ToString();

            // poniendo titulo a la pagina AlumnosDelUpd.aspx

            switch (accion)
            {
                case "DEL":
                    Label1.Text = "Retirar Alumno";
                    break;
                case "UPD":
                    Label1.Text = "Actualizar datos de Alumno";
                    break;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string accion = Request["accion"];
            int idalumno = Convert.ToInt32(Request["idalumno"]);
            string nombre = Request["TextBox1"];

            if (nombre.Trim().Length > 0)
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;

                switch (accion)
                {
                    case "DEL":
                        cm.CommandText = "DELETE FROM alumnos2 WHERE idalumno = " + idalumno;
                        break;
                    case "UPD":
                        cm.CommandText = "UPDATE alumnos2 SET nombre = '" + nombre + "' WHERE idalumno = " + idalumno;
                        break;
                }

                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

                Response.Redirect("Main.aspx");
            }
            else
            {
                Session["msg"] = "Debe ingresar nombre de Alumno";
                Response.Redirect("Mensajes.aspx");
            }
        }
    }
}