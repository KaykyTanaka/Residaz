<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="VisualizarUsuarios.aspx.cs" Inherits="Pages_Sindico_VisualizarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">

    <div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container p-5">
            <div class="row">
                <div class=" mb-4 col-6">
                    <h4 class=" text-white font-weight-bolder">Usuarios Cadastrados</h4>
                </div>

                <div class=" mb-4 col-6 text-end">
                    <asp:LinkButton ID="btnNewUsuario" runat="server" CssClass="btn btn-outline-light rounded-5" OnClick="btnNewUsuario_Click">
                     Novo Usuario
                    </asp:LinkButton>
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
    <!-- Modal -->
    <div class="modal fade" id="modalNovoUsu" tabindex="-1" aria-labelledby="modalNovoUsu" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5">Cadastrar</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <ul class="nav nav-tabs mb-3" id="pills-tab" role="tablist">
                        <li class="nav-item" role="presentation">
                            <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Pessoa</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Usuario</button>
                        </li>
                    </ul>
                    <div class="tab-content" id="pills-tabContent">

                        <!--Pessoa-->
                        <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab" tabindex="0">

                            <!--Nome-->
                            <div class="mb-3">
                                <label for="txtNome" class="form-label">Nome</label>
                                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>

                            <!--CPF-->
                            <div class="mb-3">
                                <label for="txtCpf" class="form-label">CPF</label>
                                <asp:TextBox ID="txtCpf" runat="server" placeholder="Ex: 000.000.000-00" CssClass="form-control" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                            </div>

                            <!--Telefone-->
                            <div class="mb-3">
                                <label for="telefone" class="form-label">Telefone</label>
                                <asp:TextBox ID="txtTelefone" runat="server" placeholder="Ex: (00)00000-0000" CssClass="form-control" ClientIDMode="Static" TextMode="Phone"></asp:TextBox>
                            </div>
                            <!--Registrar-->
                            <asp:LinkButton ID="btnRegistrar" runat="server" CssClass="btn btn-primary" OnClick="btnRegistrar_Click">
                                Registrar
                            </asp:LinkButton>
                        </div>

                        <!--Usuario-->
                        <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab" tabindex="0">

                            <div class="mb-3">
                                <label for="ddPessoa" class="form-label">Pessoa </label>
                                <asp:DropDownList ID="ddPessoa" runat="server" CssClass="form-select"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label for="txtEmail" class="form-label">Email address</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="email" CssClass="form-control" ClientIDMode="Static" TextMode="Email"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtSenha" class="form-label">Senha</label>
                                <asp:TextBox ID="txtSenha" runat="server" placeholder="senha" CssClass="form-control" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                            </div>

                            <asp:RadioButton ID="rbSindico" runat="server" Text="Síndico" GroupName="tipoUsuario" />
                            <asp:RadioButton ID="rbMorador" runat="server" Text="Morador" GroupName="tipoUsuario" />
                            <asp:RadioButton ID="rbPorteiro" runat="server" Text="Porteiro" GroupName="tipoUsuario" />
                            <asp:RadioButton ID="rbZelador" runat="server" Text="Zelador" GroupName="tipoUsuario" />


                            <div class="mb-3">
                                <label for="txtApartamento" class="form-label">Apartamento</label>
                                <asp:TextBox ID="txtApartamento" runat="server" placeholder="apartamento" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>




                            <asp:LinkButton ID="btnCadastrar" runat="server" CssClass="btn btn-primary" OnClick="btnCadastrar_Click">
                                Cadastrar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

