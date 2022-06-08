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
    public partial class NotasInsDelUpd : System.Web.UI.Page
    {

        private SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");

            string accion = Request["accion"];

            if (accion == "INS")
            {
                string alumno = Request["alumno"];
                int idalumno = Convert.ToInt32(Request["idalumno"]);

                Label1.Text = "Nueva Nota para alumno/a " + alumno;
                Idalumno.Value = "" + idalumno; // para insertar nota con idalumno
            }
            else // DEL - UPD
            {
                int idnota = Convert.ToInt32(Request["idnota"]);

                string sql = "SELECT nota, nombre FROM notas INNER JOIN alumnos2 ON notas.idalumno=alumnos2.idalumno WHERE idnota = " + idnota;

                SqlCommand cm = new SqlCommand(sql, cn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0].ItemArray.ElementAt(0).ToString(); // nota
                string alumno = dt.Rows[0].ItemArray.ElementAt(1).ToString(); // nombre

                switch (accion)
                {
                    case "DEL":
                        Label1.Text = "Retirar nota de " + alumno;
                        break;
                    case "UPD":
                        Label1.Text = "Cambiar nota de " + alumno;
                        break;
                }

                Accion.Value = accion; // PONER ACCION EN EL HIDDEN DEL FORMULARIO PARA EL CLIC EN EL BOTON ACEPTAR
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string accion = Request["Accion"];
            string snota = Request["TextBox1"];

            try
            {
                int nota = Convert.ToInt32(snota);

                if(nota < 0 || nota > 20)
                {
                    Session["msg"] = "Nota debe estar entre [0, 20]";
                    Response.Redirect("Mensajes.aspx");
                }
                else
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = cn;

                    switch (accion)
                    {
                        case "INS":
                            int idalumno = Convert.ToInt32(Request["Idalumno"]);
                            cm.CommandText = "INSERT INTO notas(idalumno, nota) VALUES(" + idalumno + ", " + nota + ")";
                            break;
                        case "UPD":
                            int idnota = Convert.ToInt32(Request["Idnota"]);
                            cm.CommandText = "UPDATE notas SET nota = " + nota + " WHERE idnota = " + idnota;
                            break;
                        case "DEL":
                            idnota = Convert.ToInt32(Request["Idnota"]);
                            cm.CommandText = "DELETE FROM notas WHERE idnota = " + idnota;
                            break;
                    }

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();

                    Response.Redirect("Main.aspx");
                }
            }
            catch(FormatException ex)
            {
                Session["msg"] = "Nota Incorrecta";
                Response.Redirect("Mensajes.aspx");
            }
        }
    }
}