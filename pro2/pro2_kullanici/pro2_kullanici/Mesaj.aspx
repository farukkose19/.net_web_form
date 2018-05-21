<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesaj.aspx.cs" Inherits="pro2_kullanici.Mesaj" %>

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

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"   >
            <Columns>
                 <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"
                            Text="ceavpla" CommandArgument='<%# Eval("KullaniciAdi") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="KullaniciAdi" HeaderText="Kullanıcı Adı" />
                <asp:BoundField DataField="Baslik" HeaderText="Kullanıcı Adı" />
                <asp:BoundField DataField="Tarih" HeaderText="Tarih" />
                <asp:BoundField DataField="Mesaj" HeaderText="Mesaj" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>