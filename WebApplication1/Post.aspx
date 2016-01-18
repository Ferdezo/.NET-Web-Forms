<%@ Page Title="Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Post.aspx.cs" Inherits="WebApplication1.Post" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>Posty</p>
        <asp:GridView ID="postGrid" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="postGrid_PageIndexChanged" OnPageIndexChanged="postGrid_PageIndexChanged" PageSize="5" runat="server" Width="743px">
            <Columns>
                <asp:BoundField DataField="content" HeaderText="Nazwa" />
                <asp:BoundField DataField="createdAt" HeaderText="Utworzono" />
                <asp:BoundField DataField="author" HeaderText="Autor" />
                <asp:ImageField DataImageUrlField="avatar" HeaderText="Avatar" />
                <%--<asp:ImageField DataImageUrlField="imageURL" HeaderText="Avatar" />--%>
            </Columns>
        </asp:GridView>
        <asp:TextBox ID="tbAdd" runat="server" Width="482px"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Dodaj" OnClick="btnAdd_Click" />
        <br />
    </div>

    <div class="row">
        
    </div>

</asp:Content>
