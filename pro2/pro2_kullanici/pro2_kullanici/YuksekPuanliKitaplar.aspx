<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YuksekPuanliKitaplar.aspx.cs" Inherits="pro2_kullanici.YuksekPuanliKitaplar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <table style="width:20%; padding:0px; float:left "  >
            <tr >
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Kitap Ara" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Kullanıcı Ara" style="width:200px" />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Yazar Ara" style="width:200px"  />
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Popüler Kitaplar" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Yüksek Puanlı Kitaplar" style="width:200px"/>
                </td>
            </tr>
            <tr>
                <td><br /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="Popüler Yazarlar" style="width:200px"/>
                </td>
            </tr>
        </table>
    </div>

    <div style="width:80%; padding:0px; float:right; height:100% " >

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                 <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"
                            Text="Sec" CommandArgument='<%# Eval("KitapID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="50px"
                            ImageUrl='<%# "data:Image/png;base64,"
                            + Convert.ToBase64String((byte[])Eval("Resim")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KitapAdi" HeaderText="Kitap Adı" />
                <asp:BoundField DataField="ort" HeaderText="Ortalama Puan" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>