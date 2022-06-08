<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlumnosDelUpd.aspx.cs" Inherits="WebApp01.AlumnosDelUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>cibertec.edu.pe</title>
    <link href="images/pi-favicon.gif" rel="shortcut icon" />
    <link href="jq/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="jq/bootstrap/bootstrap-icons.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-4">
            <div class="col-2"></div>
            <div class="col-8">
                <form id="form1" runat="server">
                    <asp:HiddenField id="accion" runat="server"/>
                    <asp:HiddenField id="idalumno" runat="server"/>

                    <!-- TITULO DE LA PAGINA -->
                    <div class="row mb-4">
                        <div class="col-12 text-center">
                            <h3> 
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>

                    <!-- EL ALUMNO A DEL/UPD -->
                    <div class="row mb-4">
                        <div class="col-12">
                            <label for="TextBox1">Alumno</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <!-- BOTONES CANCELAR/ACEPTAR -->
                    <div class="row mb-4">
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="bi-save"></i> Aceptar</asp:LinkButton>
                            <a href="Main.aspx" class="btn btn-primary"><i class="bi-house-door"></i> Cancelar</a>
                        </div>
                    </div>

                </form>
            </div>
            <div class="col-2"></div>
        </div>
    </div>
    
</body>
</html>
