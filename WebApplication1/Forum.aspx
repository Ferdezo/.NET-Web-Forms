<%@ Page Title="Topics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Forum.aspx.cs" Inherits="WebApplication1.Forum" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>Tematy</p>
        <asp:GridView ID="forumGrid" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" runat="server" Width="743px">
            <Columns>
            <asp:hyperlinkfield datatextfield="title"
            datatextformatstring="{0:c}"
            datanavigateurlfields="topID"
            datanavigateurlformatstring="~\Post.aspx?topID={0}"          
            headertext="Nazwa"
            target="_blank" />
                <asp:BoundField DataField="title" HeaderText="Nazwa" />
                <asp:BoundField DataField="createdAt" HeaderText="Utworzono" />
                <asp:BoundField DataField="author" HeaderText="Autor" />
                <asp:ImageField DataImageUrlField="avatar" HeaderText="Avatar" />
                <%--<asp:ImageField DataImageUrlField="imageURL" HeaderText="Avatar" />--%>
            </Columns>
        </asp:GridView>
        <asp:TextBox ID="tbAdd" runat="server" Width="482px"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Dodaj" OnClick="btnAdd_Click" />
    </div>

    <div class="row">
        
    </div>

</asp:Content>
