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
    public partial class frmAlquiler : System.Web.UI.Page
    {
        IEnumerable<Models.Alquiler> alquileres = new ObservableCollection<Models.Alquiler>();
        AlquilerManager alquilerManager = new AlquilerManager();
        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async private void InicializarControles()
        {
            try
            {
                alquileres = await alquilerManager.ObtenerAlquileres(Session["TokenUsuario"].ToString());
                gvAlquileres.DataSource = alquileres.ToList();
                gvAlquileres.DataBind();
            }
            catch (Exception e)
            {
                lblResultado.Text = "Hubo un error al inicializar controles. Detalle: " + e.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        protected void gvAlquileres_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Codigo alquiler";
                e.Row.Cells[1].Text = "Código usuario";
                e.Row.Cells[2].Text = "Código vehiculo";
                e.Row.Cells[3].Text = "Codigo pago";
                e.Row.Cells[4].Text = "Fecha entrega";
                e.Row.Cells[5].Text = "Fecha alquiler";
                e.Row.Cells[6].Text = "Precio por hora";
            }            
        
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsertar())
                {
                    Models.Alquiler alquilerIngresado = new Models.Alquiler();
                    Models.Alquiler alquiler = new Models.Alquiler()
                    {
                        ALQ_ID = Convert.ToInt32(txtALQ_ID.Text),
                        USU_CODIGO = Convert.ToInt32(txtUSU_CODIGO.Text),
                        VEH_ID = Convert.ToInt32(txtVEH_ID.Text),
                        PAGO_ID = Convert.ToInt32(txtPAGO_ID.Text),
                        ALQ_FECHA_ENTREGA = calFecEntrega.SelectedDate,
                        ALQ_FECHA_ALQUILER = calFecAlquiler.SelectedDate,
                        ALQ_PRECIOXHORA = Convert.ToInt32(txtPrecio.Text)
                    };

                    alquilerIngresado = await alquilerManager.Ingresar(alquiler, Session["TokenUsuario"].ToString());

                    if (alquilerIngresado != null)
                    {
                        lblResultado.Text = "Alquiler ingresado correctamente";
                        lblResultado.ForeColor = Color.Green;
                        lblResultado.Visible = true;
                        InicializarControles();
                    }
                    else
                    {
                        lblResultado.Text = "Error al crear el alquiler";
                        lblResultado.ForeColor = Color.Maroon;
                        lblResultado.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                lblResultado.Text = "Hubo un error al ingresar el alquiler. Detalle: " + exc.Message;
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
            }

        }

        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtALQ_ID.Text))
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtUSU_CODIGO.Text))
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtVEH_ID.Text))
            {
                lblResultado.Text = "Debe ingresar el código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtPAGO_ID.Text))
            {
                lblResultado.Text = "Debe ingresar código";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                lblResultado.Text = "Debe ingresar el precio por hora";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            return true;
        }

        async protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar() && (!string.IsNullOrEmpty(txtALQ_ID.Text)))
            {
                Models.Alquiler alquilerModificado = new Models.Alquiler();
                Models.Alquiler alquiler = new Models.Alquiler()
                {
                    ALQ_ID = Convert.ToInt32(txtALQ_ID.Text),
                    USU_CODIGO = Convert.ToInt32(txtUSU_CODIGO.Text),
                    VEH_ID = Convert.ToInt32(txtVEH_ID.Text),
                    PAGO_ID = Convert.ToInt32(txtPAGO_ID.Text),
                    ALQ_FECHA_ENTREGA = calFecEntrega.SelectedDate,
                    ALQ_FECHA_ALQUILER = calFecAlquiler.SelectedDate,
                    ALQ_PRECIOXHORA = Convert.ToInt32(txtPrecio.Text)
                };

                alquilerModificado = await alquilerManager.Actualizar(alquiler, Session["TokenUsuario"].ToString());

                if (alquilerModificado != null)
                {
                    lblResultado.Text = "Alquiler actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar el alquiler";
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
            if (!string.IsNullOrEmpty(txtALQ_ID.Text))
            {
                string codigoEliminado = string.Empty;
                codigoEliminado = await alquilerManager.Eliminar(txtALQ_ID.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Alquiler eliminado con exito.";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el alquiler.";
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
    }
}