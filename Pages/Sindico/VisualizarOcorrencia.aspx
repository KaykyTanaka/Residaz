<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="VisualizarOcorrencia.aspx.cs" Inherits="Pages_Sindico_VisualizarOcorrencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">


    <div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container">
            <div class="row p-3">
                <div class="col-12">
                    <h4 class="mt-3 text-white font-weight-bolder">Ocorrências</h4>
                </div>

                <div class="text-bg-light rounded p-5">

                    <asp:GridView ID="gdvOcorrencias" AutoGenerateColumns="false" runat="server" CssClass="table table-striped Tabela" Visible="false" OnRowDataBound="gdvOcorrencias_RowDataBound" OnRowCommand="gdvOcorrencias_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="oco_id" HeaderText="#" />
                            <asp:BoundField DataField="oco_titulo" HeaderText="titulo" />
                            <asp:BoundField DataField="oco_categoria" HeaderText="categoria" />
                            <asp:BoundField DataField="oco_status" HeaderText="status" />
                            <asp:TemplateField HeaderText="Detalhes">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Editar" CommandArgument='<%# Bind("oco_id") %>' ID="lbeditar" CssClass="btn btn-default" title="Editar Usuario" data-toggle="tooltip" runat="server"></asp:LinkButton>
                                    <asp:LinkButton CommandName="Visualizar" CommandArgument='<%# Bind("oco_id")%>' ID="lkbVisualizar" CssClass="btn btn-default" data-toggle="tooltip" runat="server"></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>



                        </Columns>
                    </asp:GridView>

                </div>

                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="modalVisualizar" tabindex="-1" aria-labelledby="modalVisualizar" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>
                        <span class="text-bold">Data e hora: </span>
                        <asp:Label ID="lblData" runat="server"></asp:Label>
                        <br>
                    </p>
                    <p>
                        <span class="font-weight-bolder">Categoria: </span>
                        <asp:Label ID="lblCat" runat="server"></asp:Label>
                        <br>
                    </p>
                    <p>
                        <span class="text-bold">Descrição: </span>
                        <asp:Label ID="lblDesc" runat="server"></asp:Label>
                    </p>
                    <br>
                    <br>
                    <div class="input-group mb-3">
                        <span class="input-group-text">Providencias</span>
                        <asp:TextBox ID="txtProvidencias" runat="server" placeholder="Descricao" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                    <asp:LinkButton ID="btnRegistrar" runat="server" CssClass="btn btn-primary" OnClick="btnRegistrar_Click">
                        Registrar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
