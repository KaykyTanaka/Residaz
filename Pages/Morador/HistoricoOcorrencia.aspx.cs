﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_Morador_Historico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["MORADOR"] != null)
            {
                LoadCard();
            }
        }
    }

    void LoadCard()
    {
        Usuario usuario = (Usuario)Session["MORADOR"];
        DataSet ds = OcorrenciasBD.SelectOcorrencias(usuario.id); //substituir o numero pelo codigo do morador que estará na session;

        if (ds != null)
        {
            lblCard.DataSource = ds;
            lblCard.DataBind();
        }
    }
    protected string GetStatusText(int statusNumber)
    {
        switch (statusNumber)
        {
            case 0:
                return "Pendente";
            case 1:
                return "Em Andamento";
            case 2:
                return "Solucionado";
            default:
                return "Desconhecido";
        }
    }
    protected string CardCor(string status)
    {
        switch (status.ToLower())
        {
            case "0":
                return "card-header bg-danger ";
            case "1":
                return "card-header bg-secondary ";
            case "2":
                return "card-header bg-success ";
            default:
                return "card-header"; // classe padrão
        }
    }


}