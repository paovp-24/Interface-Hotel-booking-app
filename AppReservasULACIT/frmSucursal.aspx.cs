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
    public partial class frmSucursal : System.Web.UI.Page
    {
        IEnumerable<Models.Sucursal> sucursal = new ObservableCollection<Models.Sucursal>();
        SucursalManager sucursalManager = new SucursalManager();
        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async private void InicializarControles()
        {
            try
            {
                sucursal = await sucursalManager.ObtenerSucursales(Session["TokenUsuario"].ToString());
                gvSucursal.DataSource = sucursal.ToList();
                gvSucursal.DataBind();
            }
            catch (Exception e)
            {
                lblResultado.Text = "Hubo un error al inicializar controles. Detalle: " + e.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        protected void gvSucursal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Nombre";
                e.Row.Cells[2].Text = "Ubicacion";
                e.Row.Cells[3].Text = "Correo";
                e.Row.Cells[4].Text = "Telefono";

            }

        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar())
                {
                    Models.Sucursal sucursalIngresado = new Models.Sucursal();
                    Models.Sucursal sucursal = new Models.Sucursal()
                    {

                        SUC_NOMBRE = txtNombre.Text,
                        SUB_UBICACION = txtUbicacion.Text,
                        SUC_CORREO = txtCorreo.Text,
                        SUC_TELEFONO = Convert.ToInt32(txtTelefono.Text)
                    };

                    sucursalIngresado = await sucursalManager.Ingresar(sucursal, Session["TokenUsuario"].ToString());

                    if (sucursalIngresado != null)
                    {
                        lblResultado.Text = "Sucursal ingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al crear la sucursal";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Hubo un error al ingresar el sucursal. Detalle: " + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                lblResultado.Text = "Debe ingresar el id";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblResultado.Text = "Debe ingresar el nombre";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtUbicacion.Text))
            {
                lblResultado.Text = "Debe ingresar la ubicacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                lblResultado.Text = "Debe ingresar correo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                lblResultado.Text = "Debe ingresar el telefono";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar() && (!string.IsNullOrEmpty(txtID.Text)))
            {
                Models.Sucursal sucursalModificado = new Models.Sucursal();
                Models.Sucursal sucursal = new Models.Sucursal()
                {
                    SUC_ID = Convert.ToInt32(txtID.Text),
                    SUC_NOMBRE = txtNombre.Text,
                    SUB_UBICACION = txtUbicacion.Text,
                    SUC_CORREO = txtCorreo.Text,
                    SUC_TELEFONO = Convert.ToInt32(txtTelefono.Text)
                };

                sucursalModificado = await sucursalManager.Actualizar(sucursal, Session["TokenUsuario"].ToString());

                if (sucursalModificado != null)
                {
                    lblResultado.Text = "Sucursal actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar la sucursal";
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
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await sucursalManager.Eliminar(txtID.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "sucursal eliminado con exito.";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar la sucursal.";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }

            }
            else
            {
                lblResultado.Text = "Debe ingresar el ID";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }
    }
}