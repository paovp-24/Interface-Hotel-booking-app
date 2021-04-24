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
    public partial class frmBoleto : System.Web.UI.Page
    {
        IEnumerable<Models.Boleto> boletos = new ObservableCollection<Models.Boleto>();
        BoletoManager boletoManager = new BoletoManager();


        async protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarInsertar())
            {
                Models.Boleto boletoIngresado = new Models.Boleto();
                Models.Boleto boleto = new Models.Boleto()
                {
                    USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                    VUE_ID = Convert.ToInt32(txtCodigoVuelo.Text),
                    PAGO_ID = Convert.ToInt32(txtCodigoPago.Text),
                    BOL_FEC_IDA = calFecIda.SelectedDate,
                    BOL_FEC_VUELTA = calFecVuelta.SelectedDate,
                    BOL_PRECIO = Convert.ToDecimal(txtPrecioBoleto.Text),
                    BOL_ASIENTO = txtAsientoBoleto.Text,
                    BOL_TERMINAL = txtTerminalBoleto.Text

                };

                boletoIngresado = await boletoManager.Ingresar(boleto, Session["TokenUsuario"].ToString());


                if (boletoIngresado != null)
                {
                    lblResultado.Text = "Boleto ingresado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al crear boleto";
                    lblResultado.ForeColor = Color.Maroon;
                    lblResultado.Visible = true;
                }
            }


        }

        async private void InicializarControles()
        {
            boletos = await boletoManager.ObtenerBoletos(Session["TokenUsuario"].ToString());
            gvdBoletos.DataSource = boletos.ToList();
            gvdBoletos.DataBind();

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

            if (string.IsNullOrEmpty(txtCodigoVuelo.Text))
            {
                lblResultado.Text = "Debe ingresar el id del vuelo";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtCodigoPago.Text))
            {
                lblResultado.Text = "Debe ingresar el id del pago";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }           

            if (string.IsNullOrEmpty(txtPrecioBoleto.Text))
            {
                lblResultado.Text = "Debe ingresar el precio del boleto";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtAsientoBoleto.Text))
            {
                lblResultado.Text = "Debe ingresar el asiento del boleto";
                lblResultado.ForeColor = Color.Maroon;
                lblResultado.Visible = true;
                return false;
            }

            if (string.IsNullOrEmpty(txtTerminalBoleto.Text))
            {
                lblResultado.Text = "Debe ingresar la terminal del boleto";
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
                Models.Boleto boletoModificado = new Models.Boleto();
                Models.Boleto boleto = new Models.Boleto()
                {
                    BOL_ID = Convert.ToInt32(txtCodigo.Text),
                    USU_CODIGO = Convert.ToInt32(txtCodigoUsuario.Text),
                    VUE_ID = Convert.ToInt32(txtCodigoVuelo.Text),
                    PAGO_ID = Convert.ToInt32(txtCodigoPago.Text),
                    BOL_FEC_IDA = calFecIda.SelectedDate,
                    BOL_FEC_VUELTA = calFecVuelta.SelectedDate,
                    BOL_PRECIO = Convert.ToDecimal(txtPrecioBoleto.Text),
                    BOL_ASIENTO = txtAsientoBoleto.Text,
                    BOL_TERMINAL = txtTerminalBoleto.Text
                };

                boletoModificado = await boletoManager.Actualizar(boleto, Session["TokenUsuario"].ToString());

                if (boletoModificado != null)
                {
                    lblResultado.Text = "Boleto actualizado correctamente";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                    InicializarControles();
                }
                else
                {
                    lblResultado.Text = "Error al actualizar boleto";
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
                codigoEliminado = await boletoManager.Eliminar(txtCodigo.Text, Session["TokenUsuario"].ToString());

                if (!string.IsNullOrEmpty(codigoEliminado))
                {
                    InicializarControles();
                    lblResultado.Text = "Boleto eliminado con éxito";
                    lblResultado.ForeColor = Color.Green;
                    lblResultado.Visible = true;
                }
                else
                {
                    lblResultado.Text = "Hubo un error al eliminar el boleto";
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

        protected void gvdBoletos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Código Boleto";
                e.Row.Cells[1].Text = "Código Usuario";
                e.Row.Cells[2].Text = "Código Vuelo";
                e.Row.Cells[3].Text = "Código Pago";
                e.Row.Cells[4].Text = "Fecha Ida";
                e.Row.Cells[5].Text = "Fecha Vuelta";
                e.Row.Cells[6].Text = "Precio Boleto";
                e.Row.Cells[7].Text = "Asiento Boleto";
                e.Row.Cells[8].Text = "Terminal Boleto";
            }
        }
    }
}