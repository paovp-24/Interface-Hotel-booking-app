using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppReservasULACIT.Models;
using AppReservasULACIT.Controllers;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AppReservasULACIT
{
    public partial class frmAeropuerto : System.Web.UI.Page
    {


        IEnumerable<Models.Aeropuerto> aeropuertos = new ObservableCollection<Models.Aeropuerto>();
        AeropuertoManager aeropuertoManager = new AeropuertoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();

        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar())
                {
                    Models.Aeropuerto aeropuertoIngresado = new Models.Aeropuerto();
                    Models.Aeropuerto aeropuerto = new Models.Aeropuerto()
                    {
                        AERO_NOMBRE = txtNombre.Text,
                        AERO_PAIS = txtPais.Text,
                        AERO_CIUDAD = txtCiudad.Text,
                        AERO_TIPO = txtTipo.Text,

                    };

                    aeropuertoIngresado = await aeropuertoManager.Ingresar(aeropuerto, Session["TokenUsuario"].ToString());

                    if (aeropuertoIngresado != null)
                    {
                        lblResultado.Text = "Aeropuertoingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al crear aeropuerto";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Error al ingresar aeropuerto. Detalle" + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }



        async private void InicializarControles()
        {
            try
            {

                aeropuertos = await aeropuertoManager.ObtenerHoteles(Session["TokenUsuario"].ToString());
                gdvAero.DataSource = aeropuertos.ToList();
                gdvAero.DataBind();

            }
            catch (Exception e)
            {

                lblResultado.Text = "Error al inicializar controles. Detalles: " + e.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;

            }
        }




        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblResultado.Text = "Debe ingresar el nombre";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtPais.Text))
            {
                lblResultado.Text = "Debe ingresar el pais";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCiudad.Text))
            {
                lblResultado.Text = "Debe ingresar la ciudad";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtTipo.Text))
            {
                lblResultado.Text = "Debe ingresar el tipo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }

        protected void gdvAero_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Aeropuerto ID";
                e.Row.Cells[1].Text = "Aeropuerto Nombre";
                e.Row.Cells[2].Text = "Aeropuerto Pais";
                e.Row.Cells[3].Text = "Aeropuerto Ciudad";
                e.Row.Cells[4].Text = "Aeropuerto Tipo";

            }

        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar() && (!string.IsNullOrEmpty(txtId.Text)))
                {
                    Models.Aeropuerto aeropuertoModificado = new Models.Aeropuerto();
                    Models.Aeropuerto aeropuerto = new Models.Aeropuerto()
                    {
                        AERO_ID = Convert.ToInt32(txtId.Text),
                        AERO_NOMBRE = txtNombre.Text,
                        AERO_PAIS = txtPais.Text,
                        AERO_CIUDAD = txtCiudad.Text,
                        AERO_TIPO = txtTipo.Text,
                    };

                    aeropuertoModificado = await aeropuertoManager.Actualizar(aeropuerto, Session["TokenUsuario"].ToString());

                    if (aeropuertoModificado != null)
                    {
                        lblResultado.Text = "Aeropuerto actualizado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al actualizar aeropuerto";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
                else
                {
                    lblResultado.Text = "Debe ingresar todos los datos";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }
            }
            catch (Exception ex)
            {

                lblResultado.Text = "Error al ingresar aeropuerto. Detalle" + ex.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }



        async protected void btnEliminar_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtId.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await aeropuertoManager.Eliminar(txtId.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Aeropuerto eliminado con Exito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el aeropuerto";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }


            }
            else
            {
                lblResultado.Text = "Debe ingresar el codigo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;

            }

        }






    }

}