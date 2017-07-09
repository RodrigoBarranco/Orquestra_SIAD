<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskDecisionSupport.aspx.cs" Inherits="Orquestra3_SIAD.UI.TaskDecisionSupport" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    .charts > div {
      display: inline-block;
      vertical-align: top;
      margin-right: 1em;
    }
</style>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="Scripts/jquery-3.1.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <div class="panel-group">

                <div class="panel panel-warning" style="display:none">
                    <div class="panel-heading"></div>
                    <div class="panel-body">Não existem instâncias suficientes para executar o apoio à decisão nessa tarefa.</div>
                </div>

                <div class="panel panel-danger" style="display:none">
                    <div class="panel-heading"></div>
                    <div class="panel-body">A tarefa selecionada já foi executada.</div>
                </div>

                <div class="panel panel-info" style="display:none">
                    <div class="panel-heading"></div>
                    <div class="panel-body">O sistema de apoio à decisão ainda não foi executado para essa tarefa. 
                        <asp:Button ID="BtnExecute" runat="server" Text="Executar" /></div>
                </div>

                
                    <div class="panel-heading"></div>
                    
                        <div class="panel-body">
                            <asp:PlaceHolder ID="PhDecisionSupport" runat="server" Visible="true">    
                            <div>
                            
                                <div class="alert alert-info" role="alert">
                                    <p><b>Orquestra BPM SIAD: Sistema Inteligente de Apoio à Decisão</b></p>
                                    <p>Com base no histórico de execuções, com uma taxa de <%= this.Accuracy %>% de acerto, sugerimos que esta atividade seja concluída com a opção <b> <%= this.Suggestion %> </b> </p>
                                    <br />
                                    <!--<p><asp:HyperLink ID="HyperLink1" runat="server">Saiba mais</asp:HyperLink></p>-->
                                </div>


                            </div>
                            <asp:PlaceHolder ID="PhActvate" runat="server" Visible="true">
                                <div class="panel panel-info">
                                    <div class="panel-heading"></div>
                                    <div class="panel-body">Se desejar, você pode ativar a execução automática para essa tarefa.
                                        <asp:Button class="btn btn-success" ID="BtnActivate" runat="server" Text="Ativar" 
                                            onclick="BtnActivate_Click" /></div>
                                </div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="PhDeactivate" runat="server" Visible="false">
                                <div class="panel panel-info">
                                    <div class="panel-heading"></div>
                                    <div class="panel-body">Você ativou a execução automática para essa tarefa, se desejar pode desativar.
                                        <asp:Button class="btn btn-danger" ID="BtnDeactivate" runat="server" Text="Desativar" 
                                            onclick="BtnDeactivate_Click" /></div>
                                </div>
                            </asp:PlaceHolder>

                            <br />

                            <!-- 
                            <div class="charts">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <asp:Chart ID="Chart1" runat="server">
                                            <series>
                                            <asp:Series Name="Series1">
                                                </asp:Series>
                                            </series>
                                            <chartareas>
                                                <asp:ChartArea Name="ChartArea1">
                                                </asp:ChartArea>
                                            </chartareas>
                                        </asp:Chart>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <asp:Chart ID="Chart2" runat="server">
                                            <series>
                                                <asp:Series ChartType="Pie" Name="Series2">
                                                </asp:Series>
                                            </series>
                                            <chartareas>
                                                <asp:ChartArea Name="ChartArea2">
                                                </asp:ChartArea>
                                            </chartareas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                            -->
                            </asp:PlaceHolder>

                            <asp:PlaceHolder ID="PhAlertCantSuggest" runat="server" Visible="false">

                                <div>
                                    <div class="alert alert-danger" role="alert">
                                        <p><b>Orquestra BPM SIAD: Sistema Inteligente de Apoio à Decisão</b></p>
                                        <p>Não é possível sugerir uma ação para essa tarefa: Número insuficiente de execuções no histórico. </b> </p>
                                        <br />
                                    </div>
                                </div>

                            </asp:PlaceHolder>
                        </div>
            </div>

        </div>
        
    </form>
</body>
</html>
