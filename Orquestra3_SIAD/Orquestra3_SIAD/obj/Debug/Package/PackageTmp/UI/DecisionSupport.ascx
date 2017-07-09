<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecisionSupport.ascx.cs" Inherits="Orquestra3_SIAD.UI.DecisionSupport" %>
<link href="css/bootstrap.min.css" rel="stylesheet">
<div class="alert alert-info" role="alert">
    <p><b>Orquestra BPM: Sistema Inteligente de Apoio à Decisão</b></p>
    <p>Com base no histórico de execuções, com uma taxa de XX % de acerto, sugerimos que esta atividade seja concluída com a opção <b> <%= this.Suggestion %> </b> </p>
</div>
