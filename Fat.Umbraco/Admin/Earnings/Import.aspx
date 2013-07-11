<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="Fat.Umbraco.Admin.Earnings.Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>import earnings</h2>

        <div class="notice">
            <p>
                CSV must be in the format: StockCode, Year, Period, ReportedDate, NPAT, Margin, CashFlow, EPS, DPS, ROE
            </p>
            <p>
                CSV must include the headings row (first row is skipped).
            </p>
            <p>
                If a record already exists for that row it will be skipped.
            </p>
        </div>

        <asp:PlaceHolder runat="server" ID="MessagePlaceHolder">
            <div id="messageholder">
                <asp:Label runat="server" ID="MessageLabel"></asp:Label>
            </div>
        </asp:PlaceHolder>

        <fieldset>
            <div class="field">
                <asp:FileUpload ID="EarningFileUpload" runat="server" size="60" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    EnableClientScript="True" CssClass="field-validation-error"
                    ControlToValidate="EarningFileUpload" ErrorMessage="file to upload is required" />
            </div>

            <div class="commands">
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="Cancel_Click">cancel</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" OnClick="Import_Click">import</asp:LinkButton>
            </div>
        </fieldset>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
