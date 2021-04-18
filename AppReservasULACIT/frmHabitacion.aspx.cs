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
    public partial class frmHabitacion : System.Web.UI.Page
    {

        IEnumerable<Models.Habitacion> habitaciones = new ObservableCollection<Models.Habitacion>();
        HabitacionManager habitacionManager = new HabitacionManager();

        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Habitacion habitacionIngresado = new Models.Habitacion();
                Models.Habitacion habitacion = new Models.Habitacion()
                {
                    HOT_CODIGO = Int32.Parse(txtCodigoHotel.Text),
                    HAB_NUMERO = Int32.Parse(txtNumero.Text),
                    HAB_CAPACIDAD = Int32.Parse(txtCapacidad.Text),
                    HAB_TIPO = txtTipo.Text,
                    HAB_DESCRIPCION = txtDescripcion.Text,
                    HAB_ESTADO = txtEstado.Text,
                    HAB_PRECIO = (decimal)Double.Parse(txtPrecio.Text)
                };

                habitacionIngresado = await habitacionManager.Ingresar(habitacion, Session["TokenUsuario"].ToString());

                if (habitacionIngresado != null)
                {
                    lblResultado.Text = "Habitacion ingresado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al crear habitacion";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }
            }
        }




        async private void InicializarControles()
        {
            try
            {
                habitaciones = await habitacionManager.ObtenerHabitaciones(Session["TokenUsuario"].ToString());
                gdvHabitacion.DataSource = habitaciones.ToList();
                gdvHabitacion.DataBind();
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


            if (string.IsNullOrEmpty(txtCodigoHotel.Text))
            {
                lblResultado.Text = "Debe ingresar el numero de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                lblResultado.Text = "Debe ingresar la capacidad de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCapacidad.Text))
            {
                lblResultado.Text = "Debe ingresar el tipo de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtTipo.Text))
            {
                lblResultado.Text = "Debe ingresar la descripcion de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblResultado.Text = "Debe ingresar el estado de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtEstado.Text))
            {
                lblResultado.Text = "Debe ingresar el nombre de la habitacion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                lblResultado.Text = "Debe ingresar la direccion";
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
                Models.Habitacion habitacionModificado = new Models.Habitacion();
                Models.Habitacion habitacion = new Models.Habitacion()
                {

                    HAB_CODIGO = Convert.ToInt32(txtCodigo.Text),
                    HOT_CODIGO = Convert.ToInt32(txtCodigoHotel.Text),
                    HAB_NUMERO = Convert.ToInt32(txtNumero.Text),
                    HAB_CAPACIDAD = Convert.ToInt32(txtCapacidad.Text),
                    HAB_TIPO = txtTipo.Text,
                    HAB_DESCRIPCION = txtDescripcion.Text,
                    HAB_ESTADO = txtEstado.Text,
                    HAB_PRECIO = Convert.ToDecimal(txtPrecio.Text)
                };

                habitacionModificado = await habitacionManager.Actualizar(habitacion, Session["TokenUsuario"].ToString());

                if (habitacionModificado != null)
                {
                    lblResultado.Text = "Habitacion actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar habitacion";
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
                codigoEliminado = await habitacionManager.Eliminar(txtCodigo.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Habitacion eliminado con Exito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el habitacion";
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

        protected void gdvHabitacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Codigo habitacion";
                e.Row.Cells[1].Text = "Codigo hotel";
                e.Row.Cells[2].Text = "Numero";
                e.Row.Cells[3].Text = "Capacidad";
                e.Row.Cells[4].Text = "Tipo";
                e.Row.Cells[5].Text = "Descripcion";
                e.Row.Cells[6].Text = "Estado";
                e.Row.Cells[7].Text = "Precio";
            }

        }
    }
}