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
    public partial class frmAvion : System.Web.UI.Page
    {
        IEnumerable<Models.Avion> aviones = new ObservableCollection<Models.Avion>();
        AvionManager avionManager = new AvionManager();

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
                    Models.Avion avionIngresado = new Models.Avion();
                    Models.Avion avion = new Models.Avion()
                    {
                        AERO_ID = Convert.ToInt32(txtAeroId.Text),
                        AV_CAPACIDAD_TOTAL = Convert.ToInt32(txtCapacidad.Text),
                        AV_MARCA = txtMarca.Text,
                        AV_TIPO_AVION = txtTipo.Text,
                        AV_MODELO = txtModelo.Text
                    };

                    avionIngresado = await avionManager.Ingresar(avion, Session["TokenUsuario"].ToString());

                    if (avionIngresado != null)
                    {
                        lblResultado.Text = "Avion ingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al crear avion";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Error al ingresar avion. Detalle" + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }






        async private void InicializarControles()
        {
            try
            {

                aviones = await avionManager.ObtenerAviones(Session["TokenUsuario"].ToString());
                gdvAvion.DataSource = aviones.ToList();
                gdvAvion.DataBind();

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
            if (string.IsNullOrEmpty(txtAeroId.Text))
            {
                lblResultado.Text = "Debe ingresar el Id del Aeropuerto";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCapacidad.Text))
            {
                lblResultado.Text = "Debe ingresar la capacidad";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                lblResultado.Text = "Debe ingresar la Marca";
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
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                lblResultado.Text = "Debe ingresar el modelo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            return true;
        }

        protected void gdvAvion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Avion ID";
                e.Row.Cells[1].Text = "Aeropuerto ID";
                e.Row.Cells[2].Text = "Avion Capacidad";
                e.Row.Cells[3].Text = "Avion Marca";
                e.Row.Cells[4].Text = "Avion Tipo";
                e.Row.Cells[5].Text = "AvionModelo";
            }
        }








        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar() && (!string.IsNullOrEmpty(txtAvionID.Text)))
                {
                    Models.Avion avionModificado = new Models.Avion();
                    Models.Avion avion = new Models.Avion()
                    {
                        AV_ID = Convert.ToInt32(txtAvionID.Text),
                        AERO_ID = Convert.ToInt32(txtAeroId.Text),
                        AV_CAPACIDAD_TOTAL = Convert.ToInt32(txtCapacidad.Text),
                        AV_MARCA = txtMarca.Text,
                        AV_TIPO_AVION = txtTipo.Text,
                        AV_MODELO = txtModelo.Text
                    };

                    avionModificado = await avionManager.Actualizar(avion, Session["TokenUsuario"].ToString());

                    if (avionModificado != null)
                    {
                        lblResultado.Text = "Avion actualizado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al actualizar avion";
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

                lblResultado.Text = "Error al ingresar avion. Detalle" + ex.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtAvionID.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await avionManager.Eliminar(txtAvionID.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Avion eliminado con Exito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el avion";
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