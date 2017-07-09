<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Orquestra3_SIAD.UI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <style>
        form 
        { 
            margin: 0 auto; 
            width:500px;
            vertical-align: middle;
        }
    </style>
    <script src="js/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.0.min.js"></script>
 

</head>
<body>
    <form id="form1" runat="server">
        <div style="max-width: 600px;">
            <div class="panel panel-default">
            
            <div class="panel-heading h2 text-info text-center">Orquestra BPM SIAD</div>
                <div class="panel-heading h4 text-primary text-center">Login</div>
                <div class="panel-body">
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtUserName">Usuário</label>
                                <div class="col-sm-10">
                                    <asp:textbox class="form-control" id="txtUserName" placeholder="Nome de usuário" runat="server"></asp:textbox>
                                </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtPassword">Senha</label>
                            <div class="col-sm-10">
                                <asp:textbox class="form-control" id="txtPassword" placeholder="Senha" runat="server" textmode="Password"></asp:textbox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:label cssclass="label label-danger" id="lblMsg" runat="server"></asp:label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:button cssclass="btn btn-success" id="btnLogin" onclick="btnLogin_Click" runat="server" text="Entrar"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</form>
</body>
</html>
