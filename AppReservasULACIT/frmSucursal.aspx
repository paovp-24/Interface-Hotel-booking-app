<%@ Page Async="true" Title="Sucursal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSucursal.aspx.cs" Inherits="AppReservasULACIT.frmSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style8 {
            width: 194px;
        }
        .auto-style9 {
            width: 341px
        }
        .auto-style13 {
            margin-bottom: 84px;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container">
             <h1 style="margin-top: 50px"><asp:Label ID="Label1" runat="server" Text="Mantenimiento de sucursal"></asp:Label></h1>
       <asp:GridView Width="100%" ID="gvSucursal" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvSucursal_RowDataBound" CssClass="auto-style13">
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

</div>

     <table class="nav-justified">
            <tr>
               <td class="auto-style8">ID</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style8">Nombre</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style8">Ubicacion</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
               </td>
               <td>&nbsp;</td>
              
           </tr>
            <tr>
               <td class="auto-style8">Correo</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
           </tr>
            <tr>
               <td class="auto-style8">Telefono</td>
               <td class="auto-style9">
                   <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
               <td>&nbsp;</td>
        
       
       </table>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"  CssClass="btn btn-primary" OnClick="btnIngresar_Click"  />
     <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-success" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"/>
        <br />
        <asp:Label ID="lblResultado" runat="server" Text="Resultado" Visible="false"></asp:Label>





    </div>





</asp:Content>
