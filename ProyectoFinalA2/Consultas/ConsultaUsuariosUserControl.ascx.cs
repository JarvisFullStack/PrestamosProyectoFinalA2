using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Consultas
{
    public partial class ConsultaUsuariosUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarButton_Click((object)this.BuscarButton, new EventArgs());
           
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<User, bool>> filtro = x => true;
            BLL.BaseRepository<User> repositorio = new BLL.BaseRepository<User>();  
            int id;
            if (!string.IsNullOrEmpty(FiltroTextBox.Text))
            {


                switch (BuscarPorDropDownList.SelectedIndex)
                {
                    case 0://ID
                        id = Utils.ToInt(FiltroTextBox.Text);
                        filtro = c => c.Id_User == id;
                        break;
                    case 1:// nombre
                        filtro = c => c.Name.Contains(FiltroTextBox.Text);
                        break;
                }
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }
    }
}