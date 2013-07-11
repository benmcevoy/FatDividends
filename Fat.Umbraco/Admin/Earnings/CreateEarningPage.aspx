<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateEarningPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Earnings.CreateEarningPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>create earning |
            <asp:Label runat="server" ID="StockCodeLabel" /></h2>

        <asp:PlaceHolder runat="server" ID="MessagePlaceHolder">
            <div id="messageholder">
                <asp:Label runat="server" ID="MessageLabel"></asp:Label>
            </div>
        </asp:PlaceHolder>

        <fieldset>

            <div class="field">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="ReportedDateTextBox">reported date</asp:Label>
                <asp:TextBox ID="ReportedDateTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ReportedDateTextBox"
                    Display="Dynamic" CssClass="field-validation-error"
                    ErrorMessage="reported date is required" EnableClientScript="True" />
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ReportedDateTextBox" Display="Dynamic"
                    ErrorMessage="reported date must be a date e.g. 23/07/2013" Type="Date" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="YearTextBox">year</asp:Label>
                <asp:TextBox ID="YearTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="YearTextBox" Display="Dynamic"
                    ErrorMessage="year must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label3" runat="server" AssociatedControlID="PeriodTextBox">period</asp:Label>
                <asp:TextBox ID="PeriodTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="PeriodTextBox" Display="Dynamic"
                    ErrorMessage="period must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label6" runat="server" AssociatedControlID="NPATTextBox">npat</asp:Label>
                <asp:TextBox ID="NPATTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="NPATTextBox" Display="Dynamic"
                    ErrorMessage="npat must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label4" runat="server" AssociatedControlID="MarginTextBox">margin</asp:Label>
                <asp:TextBox ID="MarginTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="MarginTextBox" Display="Dynamic"
                    ErrorMessage="margin must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label5" runat="server" AssociatedControlID="CashFlowTextBox">cash flow</asp:Label>
                <asp:TextBox ID="CashFlowTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="CashFlowTextBox" Display="Dynamic"
                    ErrorMessage="cash flow must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label7" runat="server" AssociatedControlID="EPSTextBox">eps</asp:Label>
                <asp:TextBox ID="EPSTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="EPSTextBox" Display="Dynamic"
                    ErrorMessage="eps must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label8" runat="server" AssociatedControlID="DPSTextBox">dps</asp:Label>
                <asp:TextBox ID="DPSTextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="DPSTextBox" Display="Dynamic"
                    ErrorMessage="dps must be numeric" Type="Double" Operator="DataTypeCheck"
                    CssClass="field-validation-error" EnableClientScript="True" />
            </div>

            <div class="field">
                <asp:Label ID="Label9" runat="server" AssociatedControlID="ROETextBox">roe</asp:Label>
                <asp:TextBox ID="ROETextBox" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="ROETextBox" Display="Dynamic"
                    ErrorMessage="roe must be numeric" Type="Double" Operator="DataTypeCheck"
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
