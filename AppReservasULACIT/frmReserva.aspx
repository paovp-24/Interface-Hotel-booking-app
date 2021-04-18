<%@ Page Async="true" Title="Mantenimiento de reserva" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReserva.aspx.cs" Inherits="AppReservasULACIT.frmReserva" %>

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
            <asp:Label ID="Label1" runat="server" Text="Mantenimiento de reserva"></asp:Label></h1>

        <asp:GridView Width="100%" ID="gvdReservas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvdReservas_RowDataBound">
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
                <asp:Label ID="Label3" runat="server" Text="Codigo Usuario"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigoUsuario" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Text="Habitación Código"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHabCodigo" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label5" runat="server" Text="Fecha Ingreso"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFecIngreso" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label6" runat="server" Text="Fecha Salida"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFecSalida" runat="server"></asp:TextBox>
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
