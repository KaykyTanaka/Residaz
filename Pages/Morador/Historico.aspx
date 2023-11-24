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

                <div class="col-4 mt-4">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title altera-fonte-titulo font-weight-bold">Iluminação</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                <!-- Buttons, labels, and many other things can be placed here! -->
                                <!-- Here is a label for example -->
                            </div>
                            <!-- /.card-tools -->
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body descricao">
                            Gostaria de relatar um problema de iluminaçãoo no meu apartamento (144)
                            que precisa de atenção. Algumas lampadas estão piscando constantemente e
                            outras simplesmente não acendem.
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer text-success">
                            Solucionado
                        </div>
                        <!-- /.card-footer -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.card-footer -->
            </div>
            <!-- /.card -->
        </div>
    </div>
</asp:Content>

