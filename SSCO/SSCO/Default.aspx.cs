using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAD;
using DTO;

namespace SSCO___Crystal
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DTOSession session = new DTOSession();
            CADSession cadSession = new CADSession();
            session.User = Int64.Parse(txtUser.Text);
            session.Password = txtPassword.Text;

            int validation_value = cadSession.login(session);

            if(validation_value == 1){
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Usuario incorrecto');", true);
            }
            else if(validation_value == 2){
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Contraseña incorrecta');", true);
            }
            else if (validation_value == 3) {
                Response.Redirect("./html/usuarios.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrarMensaje", "alertify.alert('Sin más');", true);
            }
        }
    }
}