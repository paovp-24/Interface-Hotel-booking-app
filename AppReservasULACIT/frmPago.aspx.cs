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
    public partial class frmPago : System.Web.UI.Page
    {
        IEnumerable<Models.Pago> pagos = new ObservableCollection<Models.Pago>();
        PagoManager pagoManager = new PagoManager();

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
                    Models.Pago pagoIngresado = new Models.Pago();
                    Models.Pago pago = new Models.Pago()
                    {
                        PAGO_FECHA = calPago.SelectedDate,
                        PAGO_TOTAL = Convert.ToDecimal(txtTotal.Text),
                        PAGO_ESTADO = txtEstado.Text,
                        PAGO_DESCRIPCION = txtDescripcion.Text

                    };

                    pagoIngresado = await pagoManager.Ingresar(pago, Session["TokenUsuario"].ToString());

                    if (pagoIngresado != null)
                    {
                        lblResultado.Text = "Pago ingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al ingresar pago";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Hubo un error al ingresar el pago. Detalle: " + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }

        async private void InicializarControles()
        {
            try
            {
                pagos = await pagoManager.ObtenerPagos(Session["TokenUsuario"].ToString());
                gvPago.DataSource = pagos.ToList();
                gvPago.DataBind();
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
            if (string.IsNullOrEmpty(txtPID.Text))
            {
                lblResultado.Text = "Debe ingresar el nombre";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                lblResultado.Text = "Debe ingresar el email";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtEstado.Text))
            {
                lblResultado.Text = "Debe ingresar el estado";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblResultado.Text = "Debe ingresar la descripcion";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }
        protected void gvPago_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Id";
                e.Row.Cells[1].Text = "Fecha";
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = "Estado";
                e.Row.Cells[4].Text = "Descripcion";

            }
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            Models.Pago pagoModificado = new Models.Pago();
            Models.Pago pago = new Models.Pago()
            {
                PAGO_ID = Convert.ToInt32(txtPID.Text),
                PAGO_FECHA = calPago.SelectedDate,
                PAGO_TOTAL = Convert.ToDecimal(txtTotal.Text),
                PAGO_ESTADO = txtEstado.Text,
                PAGO_DESCRIPCION = txtDescripcion.Text
            };

            pagoModificado = await pagoManager.Actualizar(pago, Session["TokenUsuario"].ToString());

            if (pagoModificado != null)
            {
                lblResultado.Text = "pago actualizado correctamente";
                lblResultado.ForeColor = Color.Green;
                lblResultado.Visible = true;
                InicializarControles();
            }
            else
            {
                lblResultado.Text = "Error al actualizar el pago";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;

            }

        }
        async protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPID.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await pagoManager.Eliminar(txtPID.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Pago eliminado con exito.";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el pago.";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }

            }
            else
            {
                lblResultado.Text = "Debe ingresar el id";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }
        }
    }
}

