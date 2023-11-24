<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Morador/MasterPageM.master" AutoEventWireup="true" CodeFile="Historico.aspx.cs" Inherits="Pages_Morador_Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">


    <div class="content-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h4 class="mt-3 altera-fonte-titulo">Histórico de Ocorrências</h4>
                </div>




                <asp:Repeater ID="lblCard" runat="server">
                    <ItemTemplate>
                        <div class="col-4 mt-4">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title altera-fonte-titulo font-weight-bold"><%# Eval("oco_titulo") %></h3>
                                    <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                    </div>
                                </div>

                                <div class="card-body descricao">
                                    <p><%# Eval("oco_descricao") %></p>
                                </div>
                                <div class="card-footer text-success">
                                    <p><%# Eval("oco_status") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>



            </div>
        </div>
    </div>
</asp:Content>

