<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Residaz</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->

    <link href="Assets/plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="assets/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link href="Assets/css/adminlte/adminlte.min.css" rel="stylesheet" />
    <link href="Assets/css/style.css" rel="stylesheet" />
    <link href="Assets/css/styleLogin.css" rel="stylesheet" />
</head>

<body class="hold-transition login-page">
    <section class="bloco container d-flex align-items-center justify-content-center ">
        <div class="login">
            <div class="loguinho mx-auto">
                <img src="assets/images/Logo-Cor-Nova.png" class="loguinho mt-5">
            </div>
            <h1 class="text-center mt-5 altera-fonte">Olá! Bem vindo</h1>
            <div class="text-center ">
                <asp:Label ID="lblErr" runat="server" CssClass="text-danger"></asp:Label>
            </div>
            <div class="mb-3">
                <form class="m-5" runat="server" defaultbutton="btnEntrar">
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label altera-fonte">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail" CssClass="form-control"
                            ClientIDMode="Static" TextMode="Email">
                        </asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtSenha" class="form-label altera-fonte">Senha</label>
                        <asp:TextBox ID="txtSenha"
                            runat="server" placeholder="Senha" CssClass="form-control"
                            ClientIDMode="Static" TextMode="Password">
                        </asp:TextBox>
                    </div>
                    <div class="mb-3 form-check">
                        <input type="checkbox" class="form-check-input" id="CheckUsuario">
                        <label class="form-check-label lembrar" for="CheckUsuario">Lembrar usuário</label>
                    </div>
                    <div class="d-flex align-items-center justify-content-center">
                        <asp:LinkButton ID="btnEntrar" runat="server" CssClass="btn btn-primary entrar"
                            OnClick="btnEntrar_Click"> ENTRAR <i class="fa fa-arrow-circle-o-right"> </i>
                        </asp:LinkButton>
                    </div>
                </form>
            </div>
        </div>
    </section>


    <!-- jQuery
    <script src="assets/plugins/jquery/jquery.min.js"></script> -->
    <script src="assets/js/bootstrap/bootstrap.bundle.min.js"></script>
</body>
</html>
