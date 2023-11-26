<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Morador/MasterPageM.master" AutoEventWireup="true" CodeFile="RegistrarOcorrencia.aspx.cs" Inherits="Pages_Morador_Ocorrencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <!-- OCORRÊNCIAS -->

    <div class="content-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-12 d-flex align-items-center">
                    <h4 class="mt-4 altera-fonte-titulo">Nova Ocorrência</h4>
                </div>
            </div>
            <div class="row mt-3 p-3">
                <div class="col-6 offset-3 align-items-center mt-3">
                    <label for="txtTitulo" class="form-label">Titulo</label>
                    <asp:TextBox ID="txtTitulo" runat="server" placeholder="Titulo" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>

                <div class="col-6 offset-3 align-items-center mt-3">
                    <label for="ddCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList ID="ddCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col-6 offset-3 align-items-center mt-3">
                    <label for="txtDescricao" class="form-label">Descrição</label>
                    <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descricao" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                </div>

                <div class="col-4 offset-7 align-items-center mt-3">
                    <asp:LinkButton ID="btnCadastrar" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnCadastrar_Click">
                        Enviar
                    </asp:LinkButton>

                </div>

            </div>
        </div>
    </div>
</asp:Content>

