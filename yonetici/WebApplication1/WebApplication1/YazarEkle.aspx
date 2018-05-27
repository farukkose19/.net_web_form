<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YazarEkle.aspx.cs" Inherits="WebApplication1.YazarEkle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Yazar Ekle</h1>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ad:" Width="100px"></asp:Label>&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Soyad:" Width="100px"></asp:Label>&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Doğum Yeri:" Width="100px"></asp:Label>&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Doğum Tarihi:" Width="100px"></asp:Label>&nbsp;
        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Varsa Ölüm Tarihi:" Width="100px"></asp:Label>&nbsp;
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click"/>
    </div>
</asp:Content>