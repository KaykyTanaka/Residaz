using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
    }

    protected void btnEntrar_Click(object sender, EventArgs e)
    {

        if (txtEmail.Text != "" && txtSenha.Text != "")
        {
            Usuario usuario = UsuariosBD.Login(txtEmail.Text, txtSenha.Text);

            if (usuario != null)
            {
                Session["USUARIO"] = usuario;
                Usuario temp = (Usuario)Session["USUARIO"];
                Usuario verifUsu = UsuariosBD.TipoLogin(Convert.ToInt32(temp.id.ToString()));
                if (verifUsu.redirecionar == "Pages/Sindico/VisualizarOcorrencia.aspx")
                {
                    Session["SINDICO"] = Session["USUARIO"];
                    Session["MORADOR"] = null;
                    Session.Remove("USUARIO");
                }
                else
                if (verifUsu.redirecionar == "Pages/Morador/HistoricoOcorrencia.aspx")
                {
                    Session["MORADOR"] = Session["USUARIO"];
                    Session["SINDICO"] = null;
                    Session.Remove("USUARIO");
                }
                Response.Redirect(verifUsu.redirecionar);
                
            }

        }
        else
        {
            lblErr.Text = "Preencha os campos corretamente! ";
        }



    }
}
