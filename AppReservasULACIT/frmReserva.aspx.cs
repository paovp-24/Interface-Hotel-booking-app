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
    public partial class frmReserva : System.Web.UI.Page
    {
        IEnumerable<Models.Reserva> reservas = new ObservableCollection<Models.Reserva>();
        ReservaManager reservaManager = new ReservaManager();


        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Reserva reservaIngresado = new Models.Reserva();
                Models.Reserva reserva = new Models.Reserva()
                {
                    USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                    HAB_CODIGO = Convert.ToInt32(txtHabCodigo.Text),
                    RES_FECHA_INGRESO = Convert.ToDateTime(txtFecIngreso.Text),
                    RES_FECHA_SALIDA = Convert.ToDateTime(txtFecSalida.Text)

                };

                reservaIngresado = await reservaManager.Ingresar(reserva, Session["TokenUsuario"].ToString());


                if (reservaIngresado != null)
                {
                    lblResultado.Text = "Reserva ingresado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al crear reserva";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }
            }


        }

        async private void InicializarControles()
        {
            reservas = await reservaManager.ObtenerReservas(Session["TokenUsuario"].ToString());
            gvdReservas.DataSource = reservas.ToList();
            gvdReservas.DataBind();

        }

        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtCodigoUsuario.Text))
            {
                lblResultado.Text = "Debe ingresar el nombre";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtHabCodigo.Text))
            {
                lblResultado.Text = "Debe ingresar el email";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtFecIngreso.Text))
            {
                lblResultado.Text = "Debe ingresar el telefono";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtFecSalida.Text))
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
                Models.Reserva reservaModificado = new Models.Reserva();
                Models.Reserva reserva = new Models.Reserva()
                {
                    RES_CODIGO = Convert.ToInt32(txtCodigo.Text),
                    USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                    HAB_CODIGO = Convert.ToInt32(txtHabCodigo.Text),
                    RES_FECHA_INGRESO = Convert.ToDateTime(txtFecIngreso.Text),
                    RES_FECHA_SALIDA = Convert.ToDateTime(txtFecSalida.Text)
                };

                reservaModificado = await reservaManager.Actualizar(reserva, Session["TokenUsuario"].ToString());

                if (reservaModificado != null)
                {
                    lblResultado.Text = "Reserva actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar reserva";
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
                codigoEliminado = await reservaManager.Eliminar(txtCodigo.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Reserva eliminado con éxito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el reserva";
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

        protected void gvdReservas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Código Reserva:";
                e.Row.Cells[1].Text = "Código Usuario:";
                e.Row.Cells[2].Text = "Código Habitación:";
                e.Row.Cells[3].Text = "Fecha Ingreso:";
                e.Row.Cells[4].Text = "Fecha Salida:";
            }
        }
    }
}