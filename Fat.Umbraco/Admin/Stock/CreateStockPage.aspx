﻿<%@ Page Title="Create Stock" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateStockPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Stock.CreateStockPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>create stock</h2>

        <fieldset>

            <div class="field">
                <asp:Label runat="server" AssociatedControlID="CodeTextBox">code</asp:Label>
                <asp:TextBox ID="CodeTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CodeTextBox"
                     Display="Dynamic" CssClass="field-validation-error"
                    ErrorMessage="code is required" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="NameTextBox">name</asp:Label>
                <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="NameTextBox" Display="Dynamic" CssClass="field-validation-error"
                    ErrorMessage="name is required" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="IndustryTextBox">industry</asp:Label>
                <asp:TextBox ID="IndustryTextBox" runat="server"></asp:TextBox>

            </div>

            <div class="commands">
               <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="Cancel_Click">cancel</asp:LinkButton>
               <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"  OnClick="Create_Click">create</asp:LinkButton>

            </div>

        </fieldset>


    </div>
</asp:Content>
