<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="VisualizarUsuarios.aspx.cs" Inherits="Pages_Sindico_VisualizarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container">
            <div class="row p-3">
                <div class="col-12">
                    <h4 class="mt-3 text-white font-weight-bolder">Usuarios Cadastrados</h4>
                </div>

                <div class="text-bg-light rounded p-5">
                    <asp:GridView ID="gdvUsuarios" AutoGenerateColumns="false" runat="server" CssClass="table table-striped Tabela" Visible="false" OnRowDataBound="gdvUsuarios_RowDataBound" OnRowCommand="gdvUsuarios_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="usu_id" HeaderText="#" />
                            <asp:BoundField DataField="pes_nome" HeaderText="Nome" />
                            <asp:BoundField DataField="pes_telefone" HeaderText="Telefone" />
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="stats" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>

                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>




</asp:Content>

