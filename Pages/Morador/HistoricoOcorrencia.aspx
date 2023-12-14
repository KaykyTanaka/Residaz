<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Morador/MasterPageM.master" AutoEventWireup="true" CodeFile="HistoricoOcorrencia.aspx.cs" Inherits="Pages_Morador_Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">


    <div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container">
            <div class="row p-3">
                <div class="col-12">
                    <h4 class="mt-3 text-white font-weight-bolder">Ocorrências</h4>
                </div>


            </div>

            <div class="row">
                <asp:Repeater ID="lblCard" runat="server">
                    <ItemTemplate>
                        <div class="col-4 mt-4">

                            <div class="card">
                                <div class='<%# CardCor(Eval("oco_status").ToString()) %>'>
                                    <h6 class="card-title altera-fonte-titulo font-weight-bold "><%# Eval("oco_categoria") %></h6>
                                    <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                    </div>
                                </div>

                                <div class="card-body descricao">
                                    <p class="fw-bold">Status:   <span class="fw-normal"><%# GetStatusText(Convert.ToInt32(Eval("oco_status"))) %></span></p>
                                    <p class="fw-bold limite-caracteres2">Descrição:   <span class="fw-normal"><%# Eval("oco_descricao") %></span></p>

                                    <br>

                                    <button type="button" class="btn btn-outline-dark" data-bs-toggle="modal" data-bs-target='<%# "#modalVisualizar_" + Eval("oco_id") %>'>
                                        Ver Detalhes
                                    </button>
                                </div>

                                <asp:Label ID="lblStatus" runat="server" CssClass="card-footer" />

                            </div>
                        </div>
                        <%--<div class="col-3 mb-3 mb-sm-0">

                            <div class='<%# CardCor(Eval("oco_status").ToString()) %>'>
                                <div class="card-body">
                                    <div class="d-flex justify-content-between">
                                        <h5 class="card-text altera-ocorrencia text-bold"><%# Eval("oco_categoria") %></h5>
                                        <h6 class="card-text text-end altera-ocorrencia text-bold"><%# GetStatusText(Convert.ToInt32(Eval("oco_status"))) %></h6>
                                    </div>

                                    <p class="card-text altera-fonte "><%# Eval("oco_descricao") %></p>
                                    <button type="button" class="btn btn-outline-light" data-bs-toggle="modal" data-bs-target='<%# "#modalVisualizar_" + Eval("oco_id") %>'>
                                        Ver Detalhes
                                    </button>
                                </div>
                            </div>
                        </div>--%>





                        <div class="modal fade" id='<%# "modalVisualizar_" + Eval("oco_id") %>' tabindex="-1" aria-labelledby='<%# "modalLabel_" + Eval("oco_id") %>' aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title  altera-ocorrencia text-bold fs-5" id="exampleModalLabel"><%# Eval("oco_categoria") %></h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <p><span class="text-bold">Data e hora: </span><%# Eval("oco_data") %></p>
                                        <br>
                                        <p><span class="text-bold">Descrição: </span><%# Eval("oco_descricao") %></p>
                                        <br>
                                        <p><span class="text-bold">Providencias: </span><%# Eval("oco_providencias") %></p>
                                        <br>
                                    </div>
                                    <div class="modal-footer">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>




</asp:Content>

