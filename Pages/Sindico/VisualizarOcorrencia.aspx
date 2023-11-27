<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="VisualizarOcorrencia.aspx.cs" Inherits="Pages_Sindico_VisualizarOcorrencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">


    <div class="content-wrapper">
        <div class="container">
            <div class="row p-3">
                <div class="col-12">
                    <h4 class="mt-3 altera-fonte-titulo">Ocorrências</h4>
                </div>
            </div>
            <asp:GridView ID="gdvOcorrencias" AutoGenerateColumns="false" runat="server" CssClass="table table-hover OcoTable" Visible="false" OnRowDataBound="gdvOcorrencias_RowDataBound" OnRowCommand="gdvOcorrencias_RowCommand">

                <Columns>
                    <asp:BoundField DataField="oco_id" HeaderText="#" />
                </Columns>
            </asp:GridView>

            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Codigo</th>

                        <th>Titulo</th>

                        <th>Categoria</th>

                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="lblLinhas" runat="server"></asp:Literal>
                </tbody>
            </table>

            <asp:Label ID="lblMsg" runat="server"></asp:Label>

        </div>
    </div>
</asp:Content>
