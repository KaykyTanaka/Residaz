<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Sindico_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <<div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container">
            <section class="container d-flex align-items-center">
                <h3 class="mt-3 text-white font-weight-bolder">Dashboard</h3>
            </section>
            <hr class="ml-3 text-white linha">

            <div class="row p-5">
                <div class="col-md-6 mb-5">
                    <!-- Quadrado pequeno para o gráfico de rosquinha -->
                    <div class="bg-white p-3">
                        <canvas id="rosquinha"></canvas>
                    </div>
                </div>

                <div class="justify-content-center align-items-center d-flex col-3">
                    <div class="caixinha-container bg-white d-flex" style="width: 200px;">
                        <div class="texto m-3">
                            <p class="font-weight-bold text-black" style="font-weight: bold;">Ocorrências</p>
                            <h1 class="font-weight-bold text-black" style="font-weight: bold; font-size: 60px;"><asp:Label ID="QntOcorr" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>
                <div class="justify-content-center align-items-center d-flex col-3">
                    <div class="caixinha-container bg-white" style="width: 200px;">
                        <div class="texto m-3">
                            <p class="font-weight-bold text-black" style="font-weight: bold;">Moradores</p>
                            <h1 class="font-weight-bold text-black" style="font-weight: bold; font-size: 60px;"><asp:Label ID="QntMora" runat="server"></asp:Label></h1>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <!-- Gráfico maior abaixo -->
                    <div class="bg-white p-3">
                        <canvas id="grafico"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>

        function ExibirRosquinha(dados, categorias) {
            var ctx = document.getElementById('rosquinha').getContext('2d');
            ctx.canvas.width = 300;
            ctx.canvas.height = 300;
            var myChart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: categorias,
                    datasets: [{
                        label: 'Dados do Banco de Dados',
                        data: dados,
                        borderColor: '#f5f5f5',
                        backgroundColor: ['#0CA0EE', '#00B4B8', '#9EFCF6'],
                        borderWidth: 0
                    }]
                },
                options: {
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            position: 'left'// Posição dos rótulos (esquerda)
                        }
                    }
                }
            });
        }



        function ExibirGrafico(dados, categorias) {
            var ctx = document.getElementById('grafico').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: categorias,
                    datasets: [{
                        label: 'Dados do Banco de Dados',
                        data: dados,
                        borderColor: '#f5f5f5',
                        backgroundColor: '#0CA0EE',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
    </script>
</asp:Content>

