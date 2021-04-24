using AppReservasULACIT.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppReservasULACIT
{
    public partial class frmVehiculo : System.Web.UI.Page
    {
        IEnumerable<Models.Vehiculo> vehiculos = new ObservableCollection<Models.Vehiculo>();
        VehiculoManager vehiculoManager = new VehiculoManager();
        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar())
                {
                    Models.Vehiculo vehiculoIngresado = new Models.Vehiculo();
                    Models.Vehiculo vehiculo = new Models.Vehiculo()
                    {
                        VEH_ID = Convert.ToInt32(txtVEH_ID.Text),
                        SUC_ID = Convert.ToInt32(txtSUC_ID.Text),
                        VEH_PLACA = txtVEH_PLACA.Text,
                        VEH_MARCA = txtVEH_MARCA.Text,
                        VEH_MODELO = txtVEH_MODELO.Text,
                        VEH_ESTADO = txtVEH_ESTADO.Text,
                        VEH_TIPO = txtVEH_TIPO.Text,
                        VEH_TRACCION = txtVEH_TRACCION.Text,
                        VEH_CANT_PASAJEROS = Convert.ToInt32(txtVEH_CANT_PASAJEROS.Text),
                        VEH_TRANSMISION = txtVEH_TRANSMISION.Text,
                    };

                    vehiculoIngresado = await vehiculoManager.Ingresar(vehiculo, Session["TokenUsuario"].ToString());

                    if (vehiculoIngresado != null)
                    {
                        lblResultado.Text = "Vehiculo ingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al crear vehiculo";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Hubo un error al ingresar el vehiculo. Detalle: " + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        async private void InicializarControles()
        {
            try
            {
                vehiculos = await vehiculoManager.ObtenerVehiculos(Session["TokenUsuario"].ToString());
                gvVehiculos.DataSource = vehiculos.ToList();
                gvVehiculos.DataBind();
            }
            catch (Exception e)
            {
                lblResultado.Text = "Hubo un error al inicializar controles. Detalle: " + e.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtVEH_ID.Text))
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtSUC_ID.Text))
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtVEH_PLACA.Text))
            {
                lblResultado.Text = "Debe ingresar la placa";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtVEH_MARCA.Text))
            {
                lblResultado.Text = "Debe ingresar la marca";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_MODELO.Text))
            {
                lblResultado.Text = "Debe ingresar el modelo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_ESTADO.Text))
            {
                lblResultado.Text = "Debe ingresar el estado";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_TIPO.Text))
            {
                lblResultado.Text = "Debe ingresar el tipo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_TRACCION.Text))
            {
                lblResultado.Text = "Debe ingresar la tracción";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_CANT_PASAJEROS.Text))
            {
                lblResultado.Text = "Debe ingresar la cantidad de pasajeros";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtVEH_TRANSMISION.Text))
            {
                lblResultado.Text = "Debe ingresar la transmisión";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }

        protected void gvVehiculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Codigo vehiculo";
                e.Row.Cells[1].Text = "Codigo sucursal";
                e.Row.Cells[2].Text = "Placa";
                e.Row.Cells[3].Text = "Marca";
                e.Row.Cells[4].Text = "Modelo";
                e.Row.Cells[5].Text = "Estado";
                e.Row.Cells[6].Text = "Tipo";
                e.Row.Cells[7].Text = "Tracción";
                e.Row.Cells[8].Text = "Cantidad pasajeros";
                e.Row.Cells[9].Text = "Transmisión";
            }
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar() && (!string.IsNullOrEmpty(txtVEH_ID.Text)))
            {
                Models.Vehiculo vehiculoModificado = new Models.Vehiculo();
                Models.Vehiculo vehiculo = new Models.Vehiculo()
                {
                    VEH_ID = Convert.ToInt32(txtVEH_ID.Text),
                    SUC_ID = Convert.ToInt32(txtSUC_ID.Text),
                    VEH_PLACA = txtVEH_PLACA.Text,
                    VEH_MARCA = txtVEH_MARCA.Text,
                    VEH_MODELO = txtVEH_MODELO.Text,
                    VEH_ESTADO = txtVEH_ESTADO.Text,
                    VEH_TIPO = txtVEH_TIPO.Text,
                    VEH_TRACCION = txtVEH_TRACCION.Text,
                    VEH_CANT_PASAJEROS = Convert.ToInt32(txtVEH_CANT_PASAJEROS.Text),
                    VEH_TRANSMISION = txtVEH_TRANSMISION.Text,
                };

                vehiculoModificado = await vehiculoManager.Actualizar(vehiculo, Session["TokenUsuario"].ToString());

                if (vehiculoModificado != null)
                {
                    lblResultado.Text = "Vehiculo actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar vehiculo";
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
            if (!string.IsNullOrEmpty(txtVEH_ID.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await vehiculoManager.Eliminar(txtVEH_ID.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Vehiculo eliminado con exito.";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el vehiculo.";
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