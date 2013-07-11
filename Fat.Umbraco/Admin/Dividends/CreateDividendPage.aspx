<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateDividendPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Dividends.CreateDividendPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>create dividend |
            <asp:Label runat="server" ID="StockCodeLabel" /></h2>

        <asp:PlaceHolder runat="server" ID="MessagePlaceHolder">
            <div id="messageholder">
                <asp:Label runat="server" ID="MessageLabel"></asp:Label>
            </div>
        </asp:PlaceHolder>

        <fieldset>

            <div class="field">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="ExDateTextBox">ex date</asp:Label>
                <asp:TextBox ID="ExDateTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExDateTextBox"
                    Display="Dynamic" CssClass="field-validation-error"
                    ErrorMessage="ex date is required" EnableClientScript="True" />
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ExDateTextBox" Display="Dynamic"
                    ErrorMessage="ex date must be a date e.g. 23/07/2013" Type="Date" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="AmountTextBox">amount</asp:Label>
                <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="AmountTextBox" Display="Dynamic" CssClass="field-validation-error"
                    ErrorMessage="amount is required" EnableClientScript="True" />
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="AmountTextBox" Display="Dynamic"
                    ErrorMessage="amount must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label3" runat="server" AssociatedControlID="FrankedTextBox">franked</asp:Label>
                <asp:TextBox ID="FrankedTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator runat="server" ControlToValidate="FrankedTextBox" Display="Dynamic"
                    ErrorMessage="franked must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label4" runat="server" AssociatedControlID="RecordDateTextBox">record date</asp:Label>
                <asp:TextBox ID="RecordDateTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="RecordDateTextBox" Display="Dynamic"
                    ErrorMessage="record date must be a date e.g. 23/07/2013" Type="Date" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label5" runat="server" AssociatedControlID="PayableDateTextBox">payable date</asp:Label>
                <asp:TextBox ID="PayableDateTextBox" runat="server" />
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="PayableDateTextBox" Display="Dynamic"
                    ErrorMessage="payable date must be a date e.g. 23/07/2013" Type="Date" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label6" runat="server" AssociatedControlID="FrankingCreditTextBox">franking credit</asp:Label>
                <asp:TextBox ID="FrankingCreditTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="FrankingCreditTextBox" Display="Dynamic"
                    ErrorMessage="franking credit must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="commands">
                <ul class="metro-list inline">
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="Cancel_Click">cancel</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" OnClick="Create_Click">create</asp:LinkButton></li>
                </ul>
            </div>

        </fieldset>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
