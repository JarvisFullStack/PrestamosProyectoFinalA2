using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Mantenimientos
{
    public partial class RegistroUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {       

                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    BLL.BaseRepository<User> repositorio = new BLL.BaseRepository<User>();
                    var user = repositorio.Get(id);

                    if (user == null)
                    {
                        MostrarMensaje("error", "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(user);                       
                    }
                }
            } 
            

            

            /*void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }*/
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.BaseRepository<User> repositorio = new BLL.BaseRepository<User>();
            User user = new User();
            bool paso = false;
            
            LlenaClase(user);

            bool esUnico = true;
            if (user.Id_User == 0)
                paso = repositorio.Save(user);
            else
            {
                var ant = new BLL.BaseRepository<User>().Get(user.Id_User);
                esUnico = new BLL.BaseRepository<User>().GetList(x => x.UserName == x.UserName).Count() <= 0 || user.UserName == ant.UserName;
                if(esUnico)
                {
                    user.Password = ant.Password;
                    paso = repositorio.Modify(user);
                } else
                {
                    paso = false;
                }
                
            }
                

            if (paso)
            {
                MostrarMensaje("success", "Transaccion Exitosa!");
                Limpiar();
            }
            else
            {
                string mensaje = "No fue posible terminar la transacción";
                if(!esUnico)
                {
                    mensaje += " porque el nombre de usuario esta en uso.";
                }
                MostrarMensaje("error", mensaje);
            }

            

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.BaseRepository<User> repositorio = new BLL.BaseRepository<User>();
            int id = Utils.ToInt(IdTextBox.Text);

            var User = repositorio.Get(id);

            if (User == null)
            {
                MostrarMensaje("error", "Registro no encontrado");
            }                
            else
            {
                repositorio.Delete(id);
            }
                
        }

        private void LlenaClase(User user)
        {
            user.Id_User = Utils.ToInt(IdTextBox.Text);
            user.Name = NamesTextBox.Text;
            user.UserName = UsernameTextBox.Text;
            user.LastName = ApellidosTextBox.Text;
            user.Password = PasswordTextBox.Text;
            user.Nivel = (Enums.NivelUsuario)this.TipoUsuarioDropDownList.SelectedIndex;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.IdTextBox.Text = "";
            this.NamesTextBox.Text = "";
            this.ApellidosTextBox.Text = "";
            this.TipoUsuarioDropDownList.SelectedIndex = 0;
            this.PasswordTextBox.Text = "";
            this.UsernameTextBox.Text = "";
        }

        private void LlenaCampos(User user)
        {
            this.IdTextBox.Text = user.Id_User.ToString();
            this.NamesTextBox.Text = user.Name;
            this.ApellidosTextBox.Text = user.LastName;
            this.TipoUsuarioDropDownList.SelectedIndex = (int)user.Nivel;
            this.PasswordTextBox.Text = user.Password;            
            this.PasswordLabel.Visible = false;
            this.PasswordTextBox.Visible = false;
            this.RequiredFieldValidator3.Enabled = false;            
            this.UsernameTextBox.Text = user.UserName;            

        }

        void MostrarMensaje(string tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == "success")
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }
    }
}