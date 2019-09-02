<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/MainSite.Master" CodeBehind="ConsultaUsuarios.aspx.cs" Inherits="ProyectoFinalA2.Consultas.ConsultaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="panel panel-primary">
        <div class="panel-heading">Consulta de Usuarios</div>
        <div class="panel-body">
    
            <div >
                <div class="col-md-2">
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Código</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Username</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-4">
                   <%-- <asp:Button ID="BuscarButton" CausesValidation="false" UseSubmitBehavior="false" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" /> --%>
                    <asp:LinkButton ID="btnBusquedaUsuarios" CausesValidation="false" UseSubmitBehavior="false" runat="server" Class="btn btn-success input-sm" Text="Buscar" >
                </div>
            </div>

            <%--GRID--%>
            <div class="col-md-12">
                <asp:GridView ID="DatosGridView"
                    runat="server"
                    class="table table-condensed table-bordered table-responsive"
                    CellPadding="4" ForeColor="#333333" GridLines="None">

                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="blue"
                            DataNavigateUrlFields="Id_User"
                            DataNavigateUrlFormatString="~/Mantenimientos/RegistroUsuarios.aspx?Id={0}"
                            Text="Editar"></asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
