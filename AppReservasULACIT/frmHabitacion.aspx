<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHabitacion.aspx.cs" Inherits="AppReservasULACIT.frmHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style5 {
            height: 20px;
        }
        .auto-style6 {
            width: 341px;
            height: 20px;
        }
        .auto-style7 {
            height: 20px;
            width: 194px;
        }
        .auto-style8 {
            width: 194px;
        }
        .auto-style9 {
            width: 341px
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container">
             <h1 style="margin-top: 50px"><asp:Label ID="Label1" runat="server" Text="Mantenimiento de habitacion"></asp:Label></h1>
       <asp:GridView Width="100%" ID="gdvHabitacion" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gdvHabitacion_RowDataBound">
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           <EditRowStyle BackColor="#999999" />
           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#E9E7E2" />
           <SortedAscendingHeaderStyle BackColor="#506C8C" />
           <SortedDescendingCellStyle BackColor="#FFFDF8" />
           <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
             </asp:GridView>

       <table class="nav-justified">
            <tr>
               <td class="auto-style8">Código habitacion</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style8">Código hotel</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtCodigoHotel" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style8">Número</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
              
           </tr>
            <tr>
               <td class="auto-style8">Capacidad</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
            <tr>
               <td class="auto-style8">Tipo</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
            <tr>
               <td class="auto-style8">Descripcion</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
            <tr>
               <td class="auto-style8">Estado</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
            <tr>
               <td class="auto-style8">Precio</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
       </table>
      
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"  CssClass="btn btn-primary" OnClick="btnIngresar_Click"  />
     <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-success" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"/>
        <br />
        <asp:Label ID="lblResultado" runat="server" Text="Resultado" Visible="false"></asp:Label>





    </div>





</asp:Content>