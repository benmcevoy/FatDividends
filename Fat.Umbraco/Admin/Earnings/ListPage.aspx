<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Earnings.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>

        <h2>earnings|<asp:Label runat="server" ID="StockCodeLabel" /></h2>

        <ul class="metro-list inline">
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="create" ToolTip="create new stock" OnClick="Create_Click" /></li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" Text="download" ToolTip="download as csv" OnClick="Download_Click" /></li>
            <li>
                <asp:LinkButton ID="LinkButton3" runat="server" Text="import" ToolTip="import csv" OnClick="Import_Click" /></li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
