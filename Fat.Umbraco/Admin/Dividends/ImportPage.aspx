<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ImportPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Dividends.ImportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>import dividends</h2>

        <div class="notice">
            <p>
                CSV must be in the format: StockCode, ExDate, Amount, Franked, FrankingCredit, PayableDate
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
                <asp:FileUpload ID="DividendFileUpload" runat="server" size="60" />
                <asp:RequiredFieldValidator runat="server"
                    EnableClientScript="True" CssClass="field-validation-error"
                    ControlToValidate="DividendFileUpload" ErrorMessage="file to upload is required" />
            </div>

            <div class="commands">
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="Cancel_Click">cancel</asp:LinkButton>
                <asp:LinkButton runat="server" CausesValidation="true" OnClick="Import_Click">import</asp:LinkButton>
            </div>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
