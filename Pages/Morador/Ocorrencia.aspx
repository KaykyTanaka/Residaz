<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Morador/MasterPageM.master" AutoEventWireup="true" CodeFile="Ocorrencia.aspx.cs" Inherits="Pages_Morador_Ocorrencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <!-- OCORRÊNCIAS -->

    <div class="content-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-12 d-flex align-items-center">
                    <h4 class="mt-4 altera-fonte-titulo">Ocorrências</h4>
                    <button type="button" class="btn btn-primary mt-3 ml-auto" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Nova Ocorrência</button>

                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5 altera-fonte-titulo" id="exampleModalLabel">Nova Ocorrência</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <div class="mb-3">
                                        <label for="recipient-name" class="col-form-label altera-fonte-titulo">Assunto</label>
                                        <input type="text" class="form-control" id="recipient-name">
                                    </div>
                                    <div class="mb-3">
                                        <label for="message-text" class="col-form-label altera-fonte-titulo">Descrição</label>
                                        <textarea class="form-control" id="message-text"></textarea>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Fechar</button>
                                    <button type="button" class="btn btn-primary">Enviar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 mt-4">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title altera-fonte-titulo font-weight-bold">Reparos</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                <!-- Buttons, labels, and many other things can be placed here! -->
                                <!-- Here is a label for example -->
                            </div>
                            <!-- /.card-tools -->
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            Gostaria de solicitar um reparo no meu apartamento (355)
                        relacionado à válvula de água do banheiro principal.
                        Notei vazamentos recentemente e acredito ser crucial
                        corrigir o problema o mais rápido possível para evitar danos maiores.
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer text-warning">
                            Em andamento
                        </div>
                        <!-- /.card-footer -->
                    </div>
                    <!-- /.card -->
                </div>

                <div class="col-4 mt-4">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title altera-fonte-titulo font-weight-bold">Lixo</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                <!-- Buttons, labels, and many other things can be placed here! -->
                                <!-- Here is a label for example -->
                            </div>
                            <!-- /.card-tools -->
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            Gostaria de solicitar o recolhimento de lixo no meu apartamento (203). Devido a um imprevisto,
                        não consegui colocar os resíduos para coleta regular no tempo previsto.
                        Seria possível enviar a equipe de limpeza para o recolhimento?
                        Estou disponível durante toda a semana para facilitar o acesso.
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer text-danger">
                            Pendente
                        </div>
                        <!-- /.card-footer -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>

