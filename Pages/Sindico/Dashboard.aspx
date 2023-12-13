<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sindico/MasterPageS.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Sindico_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <<div class="content-wrapper" style="background: linear-gradient(180deg, #0077B6 0%, #00B4B8 100%);">
        <div class="container">
            <div class="row p-3">
                <div class="col-12">
                    <h4 class="mt-3 text-white font-weight-bolder">Dashboard</h4>
                </div>
            </div>

            <div class="row p-5">
                <div class="col-md-6 mb-5">
                    <!-- Quadrado pequeno para o gráfico de rosquinha -->
                    <div class="bg-white p-3">
                        <canvas id="rosquinha"></canvas>
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

        function ExibirRosquinha(dados) {
            var ctx = document.getElementById('rosquinha').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ['Dado 1', 'Dado 2', 'Dado 3', 'Dado 4', 'Dado 5'],
                    datasets: [{
                        label: 'Dados do Banco de Dados',
                        data: dados,
                        borderColor: '#f5f5f5',
                        backgroundColor: ['#0CA0EE', '#00B4B8', '#9EFCF6'],
                        borderWidth: 1
                    }],
                    hoverOffset: 4
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            display: true,
                            position: 'left', // Posição dos rótulos (esquerda)
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }



        function ExibirGrafico(dados) {
            var ctx = document.getElementById('grafico').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Dado 1', 'Dado 2', 'Dado 3', 'Dado 4', 'Dado 5'],
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

