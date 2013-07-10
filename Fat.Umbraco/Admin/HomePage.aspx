<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Fat.Umbraco.Admin.HomePage" %>

<%@ Register Src="~/Admin/Stock/List.ascx" TagPrefix="fat" TagName="StockList" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadPlaceHolder"></asp:Content>
<asp:Content runat="server" ID="Body" ContentPlaceHolderID="BodyPlaceHolder">
    
    <fat:StockList runat="server" ID="List" />


</asp:Content>
