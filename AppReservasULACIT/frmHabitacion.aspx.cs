using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppReservasULACIT.Models;
using AppReservasULACIT.Controllers;
using System.Collections.ObjectModel;

namespace AppReservasULACIT
{
    public partial class frmHabitacion : System.Web.UI.Page
    {
        HotelManager hotelManager = new HotelManager();
        IEnumerable<Models.Hotel> hoteles = new ObservableCollection<Models.Hotel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async void InicializarControles()
        {
            hoteles = await hotelManager.ObtenerHoteles(Session["TokenUsuario"].ToString());
            ddlHoteles.DataSource = hoteles.ToList();
            ddlHoteles.DataTextField = "HOT_NOMBRE";
            ddlHoteles.DataValueField = "HOT_CODIGO";
            ddlHoteles.DataBind();


            // Convert.ToInt32(ddlHoteles.SelectedValue)
        }
    }
}