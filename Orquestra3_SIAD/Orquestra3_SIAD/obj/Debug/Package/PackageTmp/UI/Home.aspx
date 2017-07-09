<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Orquestra3_SIAD.UI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix="UserControl" TagName="Header" Src="DecisionSupport.ascx" %> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
        form 
        { 
            margin: 0 auto; 
            width:1000px;
            vertical-align: middle;
        }
        
    </style>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/Global.css" rel="stylesheet">
    <script type="text/javascript" src="Scripts/jquery-3.1.0.min.js"></script>
    <script type="text/javascript" src="Scripts/util.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>

</head>

<body>

    <div class="page-header">
        <center><h1>Orquestra BPM SIAD<small> Sistema inteligente de apoio à decisão</small></h1></center>
    </div>

    <form id="form1" runat="server">
    <div>

        
        <asp:Repeater ID="RptPendingTasks" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>    
                            <th>Nº do Processo</th>
                            <th>Nº da Tarefa</th>
                            <th>Nome da Tarefa</th>
                            <th>Expira em</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                        <tr>
                            <td><%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[0].InnerText %></td>
                            <td><%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[1].InnerText %></td>
                            <td><%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[5].InnerText %></td>
                            <td><%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[9].InnerText %></td>
                            <td>
                                <asp:LinkButton 
                                    ID="lkTaskDecisionSupport" 
                                    runat="server" 
                                    Font-Underline="false" 
                                    CausesValidation="false" 
                                    CommandName="Acessar" 
                                    CommandArgument="<%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[1].InnerText %>" 
                                    OnClick="lkTaskDecisionSupport_Click"
                                    Text="Acessar" />
                            </td>
                            <td style="visibility:hidden"><%# ((System.Xml.XmlNode)Container.DataItem).ChildNodes[4].InnerText %></td>
                        </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
    </div>

    <div>
        <table class="table table-bordered table-striped" width="500px">
            <caption>Tarefas autorizadas para execução automática</caption>
            <thead>
                <tr>    
                    <th>Tarefa</th>
                    <th>Autorizado em</th>
                    <th>Número de tarefas executadas automaticamente</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tarefa 1</td>
                    <td>27/07/2016</td>
                    <td>2</td>
                </tr>
            </tbody>
        </table>
    </div>

    <div>
        <table class="table table-bordered table-striped" width="500px">
            <caption>Histórico de execução automática</caption>
            <thead>
                <tr>    
                    <th>Tarefa</th>
                    <th>Autorizado em</th>
                    <th>Número de tarefas executadas automaticamente</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tarefa 1</td>
                    <td>27/07/2016</td>
                    <td>2</td>
                </tr>
            </tbody>
        </table>
    </div>

    </form>

</body>
</html>
