<%@ Page Async="true" Title="Mantenimiento de vuelo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVuelo.aspx.cs" Inherits="AppReservasULACIT.frmVuelo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/jquery-3.4.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 156px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Container">
        <h1 style="margin-top: 50px">
            <asp:Label ID="Label1" runat="server" Text="Mantenimiento de vuelo"></asp:Label></h1>

        <asp:GridView Width="100%" ID="gvdVuelos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvdVuelos_RowDataBound">
            <alternatingrowstyle backcolor="White" forecolor="#284775" />
            <editrowstyle backcolor="#999999" />
            <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
            <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
            <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
            <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
            <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
            <sortedascendingcellstyle backcolor="#E9E7E2" />
            <sortedascendingheaderstyle backcolor="#506C8C" />
            <sorteddescendingcellstyle backcolor="#FFFDF8" />
            <sorteddescendingheaderstyle backcolor="#6F8DAE" />
        </asp:GridView>




    </div>
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label3" runat="server" Text="Codigo Avion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigoAvion" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label7" runat="server" Text="Vuelo Origen"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVueloOrigen" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label8" runat="server" Text="Vuelo Destino"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVueloDestino" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Text="Cantidad de pasajeros"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCantPasajeros" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-success" OnClick="btnModificar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
    <br />
    <asp:Label ID="lblResultado" runat="server" Text="Resultado" Visible="false"></asp:Label>
</asp:Content>
