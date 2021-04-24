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
    public partial class frmVuelo : System.Web.UI.Page
    {
        IEnumerable<Models.Vuelo> vuelos = new ObservableCollection<Models.Vuelo>();
        VueloManager vueloManager = new VueloManager();


        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Vuelo vueloIngresado = new Models.Vuelo();
                Models.Vuelo vuelo = new Models.Vuelo()
                {
                    AV_ID = Convert.ToInt32(txtCodigoAvion.Text),
                    VUE_ORIGEN = txtVueloOrigen.Text,
                    VUE_DESTINO = txtVueloDestino.Text,
                    VUE_CANT_PASAJEROS = Convert.ToInt32(txtCantPasajeros.Text)
                };

                vueloIngresado = await vueloManager.Ingresar(vuelo, Session["TokenUsuario"].ToString());


                if (vueloIngresado != null)
                {
                    lblResultado.Text = "Vuelo ingresado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al crear Vuelo";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }
            }


        }

        async private void InicializarControles()
        {
            vuelos = await vueloManager.ObtenerVuelos(Session["TokenUsuario"].ToString());
            gvdVuelos.DataSource = vuelos.ToList();
            gvdVuelos.DataBind();

        }

        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtCodigoAvion.Text))
            {
                lblResultado.Text = "Debe ingresar el codigo del avion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtVueloOrigen.Text))
            {
                lblResultado.Text = "Debe ingresar el origen del vuelo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtVueloDestino.Text))
            {
                lblResultado.Text = "Debe ingresar el destino del vuelo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCantPasajeros.Text))
            {
                lblResultado.Text = "Debe ingresar la cantidad de pasajeros";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar() && (!string.IsNullOrEmpty(txtCodigo.Text)))
            {
                Models.Vuelo vueloModificado = new Models.Vuelo();
                Models.Vuelo vuelo = new Models.Vuelo()
                {
                    VUE_ID = Convert.ToInt32(txtCodigo.Text),
                    AV_ID = Convert.ToInt32(txtCodigoAvion.Text),
                    VUE_ORIGEN = txtVueloOrigen.Text,
                    VUE_DESTINO = txtVueloDestino.Text,
                    VUE_CANT_PASAJEROS = Convert.ToInt32(txtCantPasajeros.Text)
                };

                vueloModificado = await vueloManager.Actualizar(vuelo, Session["TokenUsuario"].ToString());

                if (vueloModificado != null)
                {
                    lblResultado.Text = "Vuelo actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar vuelo";
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

        async protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await vueloManager.Eliminar(txtCodigo.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Vuelo eliminado con éxito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el Vuelo";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }


            }
            else
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;

            }
        }

        protected void gvdVuelos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Código Vuelo";
                e.Row.Cells[1].Text = "Código Avión";
                e.Row.Cells[2].Text = "Vuelo Origen";
                e.Row.Cells[3].Text = "Vuelo Destino";
                e.Row.Cells[4].Text = "Cantidad Pasajeros";              
            }
        }
    }
}