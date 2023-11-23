using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {


        if (txtEmail.Text != "" && txtSenha.Text != "")
        {
            Usuario usuario = UsuariosBD.Login(txtEmail.Text, txtSenha.Text);

            if (usuario != null)
            {
                Session["USUARIO"] = usuario;
                Response.Redirect("Pages/Síndico/Home.aspx");
            }
            else
            {
                lblErr.Text = "Email ou senha invalidos! ";
            }

        }
        else
        {
            lblErr.Text = "Preencha os campos corretamente! ";
        }
    }
}
