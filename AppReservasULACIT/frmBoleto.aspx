<%@ Page Async="true" Title="Mantenimiento de boleto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBoleto.aspx.cs" Inherits="AppReservasULACIT.frmBoleto" %>

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
            <asp:Label ID="Label1" runat="server" Text="Mantenimiento de boleto"></asp:Label></h1>

        <asp:GridView Width="100%" ID="gvdBoletos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvdBoletos_RowDataBound">
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
                <asp:Label ID="Label7" runat="server" Text="Codigo Vuelo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigoVuelo" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label8" runat="server" Text="Codigo Pago"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigoPago" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label6" runat="server" Text="Precio Boleto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrecioBoleto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label9" runat="server" Text="Asiento Boleto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAsientoBoleto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label10" runat="server" Text="Terminal Boleto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTerminalBoleto" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Text="Fecha Ida"></asp:Label>
            </td>
            <td>
               <asp:Calendar ID="calFecIda" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" Visible="True">
                    <dayheaderstyle backcolor="#CCCCCC" font-bold="True" font-size="7pt" forecolor="#333333" height="10pt" />
                    <daystyle width="14%" />
                    <nextprevstyle font-size="8pt" forecolor="White" />
                    <othermonthdaystyle forecolor="#999999" />
                    <selecteddaystyle backcolor="#CC3333" forecolor="White" />
                    <selectorstyle backcolor="#CCCCCC" font-bold="True" font-names="Verdana" font-size="8pt" forecolor="#333333" width="1%" />
                    <titlestyle backcolor="Black" font-bold="True" font-size="13pt" forecolor="White" height="14pt" />
                    <todaydaystyle backcolor="#CCCC99" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label5" runat="server" Text="Fecha Vuelta"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="calFecVuelta" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" Visible="True">
                    <dayheaderstyle backcolor="#CCCCCC" font-bold="True" font-size="7pt" forecolor="#333333" height="10pt" />
                    <daystyle width="14%" />
                    <nextprevstyle font-size="8pt" forecolor="White" />
                    <othermonthdaystyle forecolor="#999999" />
                    <selecteddaystyle backcolor="#CC3333" forecolor="White" />
                    <selectorstyle backcolor="#CCCCCC" font-bold="True" font-names="Verdana" font-size="8pt" forecolor="#333333" width="1%" />
                    <titlestyle backcolor="Black" font-bold="True" font-size="13pt" forecolor="White" height="14pt" />
                    <todaydaystyle backcolor="#CCCC99" />
                </asp:Calendar>
            </td>
        </tr>
    </table>

    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-success" OnClick="btnModificar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
    <br />
    <asp:Label ID="lblResultado" runat="server" Text="Resultado" Visible="false"></asp:Label>
</asp:Content>
