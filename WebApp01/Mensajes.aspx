<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="WebApp01.Mensajes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                    <div class="alert alert-warning">
                        <h4><i class="bi-exclamation-square-fill"></i> Advertencia</h4>
                        <hr />
                        <p class="text-center">
                            <% Response.Write(Convert.ToString(Session["msg"])); %>
                        </p>
                    </div>
                </form>
            </div>
            <div class="col-2"></div>
        </div>
    </div>

    <div class="row mt-4">
        <div class="col-12 text-center">
            <a href="Main.aspx" class="btn btn-primary"><i class="bi-house-door"></i> Home</a>
        </div>
    </div>

    <script src="jq/jquery-3.6.0.min.js"></script>
    <script src="jq/bootstrap/bootstrap.bundle.min.js"></script>
</body>
</html>
