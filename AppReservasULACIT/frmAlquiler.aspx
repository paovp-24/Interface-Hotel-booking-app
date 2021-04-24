<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAlquiler.aspx.cs" Inherits="AppReservasULACIT.frmAlquiler" %>
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
        <br /><br />
 <h1><asp:Label ID="Label1" runat="server" Text="Mantenimiento de Alquiler"></asp:Label></h1>
        <asp:GridView Width="100%" ID="gvAlquileres" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvAlquileres_RowDataBound">
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
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Código Alquiler"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtALQ_ID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Código Usuario"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUSU_CODIGO" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="vehiculo" runat="server" Text="Código Vehiculo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVEH_ID" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Código Pago</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPAGO_ID" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">Precio por hora</td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style2">Seleccione fecha de entrega</td>           
                <asp:Calendar ID="calFecEntrega" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" Visible="True">
                    <dayheaderstyle backcolor="#CCCCCC" font-bold="True" font-size="7pt" forecolor="#333333" height="10pt" />
                    <daystyle width="14%" />
                    <nextprevstyle font-size="8pt" forecolor="White" />
                    <othermonthdaystyle forecolor="#999999" />
                    <selecteddaystyle backcolor="#CC3333" forecolor="White" />
                    <selectorstyle backcolor="#CCCCCC" font-bold="True" font-names="Verdana" font-size="8pt" forecolor="#333333" width="1%" />
                    <titlestyle backcolor="Black" font-bold="True" font-size="13pt" forecolor="White" height="14pt" />
                    <todaydaystyle backcolor="#CCCC99" />
                </asp:Calendar>
            </tr>
            <tr>
                <td class="auto-style2">Seleccione fecha de alquiler</td>           
                <asp:Calendar ID="calFecAlquiler" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" Visible="True">
                    <dayheaderstyle backcolor="#CCCCCC" font-bold="True" font-size="7pt" forecolor="#333333" height="10pt" />
                    <daystyle width="14%" />
                    <nextprevstyle font-size="8pt" forecolor="White" />
                    <othermonthdaystyle forecolor="#999999" />
                    <selecteddaystyle backcolor="#CC3333" forecolor="White" />
                    <selectorstyle backcolor="#CCCCCC" font-bold="True" font-names="Verdana" font-size="8pt" forecolor="#333333" width="1%" />
                    <titlestyle backcolor="Black" font-bold="True" font-size="13pt" forecolor="White" height="14pt" />
                    <todaydaystyle backcolor="#CCCC99" />
                </asp:Calendar>
            </tr>
            
            
        </table>
        <br />
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-success" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"/>
        <br />
        <asp:Label ID="lblResultado" runat="server" Text="Resultado" Visible="false"></asp:Label>

   </div>
</asp:Content>
