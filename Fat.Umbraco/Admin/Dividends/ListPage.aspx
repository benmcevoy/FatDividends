<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Dividends.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>
        <h2>dividends |
            <asp:Label runat="server" ID="StockCodeLabel" /></h2>

        <ul class="metro-list inline">
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="create" ToolTip="create new stock" OnClick="Create_Click" /></li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" Text="download" ToolTip="download as csv" OnClick="Download_Click" /></li>
            <li>
                <asp:LinkButton ID="LinkButton3" runat="server" Text="import" ToolTip="import csv" OnClick="Import_Click" /></li>
        </ul>

        <asp:GridView ID="GridView1" runat="server" DataSourceID="StocksEntityDataSource"
            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="StockCode, ExDate">
            <EmptyDataTemplate>
                <div>
                    No dividends found. Return to <a href="/Admin/HomePage.aspx">stocks</a>
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:CommandField ShowEditButton="True">
                    <HeaderStyle Width="50px" />
                    <ItemStyle Width="50px" />
                </asp:CommandField>

                <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("StockCode") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("StockCode") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ex Date" SortExpression="ExDate">
                    <ItemTemplate>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("ExDate", "{0:dd MMM yy}") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ExDate") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Amount") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Franked">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Franked") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="FrankedTextBox" runat="server" Text='<%# Bind("Franked") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Record Date" SortExpression="RecordDate">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("RecordDate", "{0:dd MMM yy}") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="RecordDateTextBox" runat="server" Text='<%# Bind("RecordDate") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Payable Date" SortExpression="PayableDate">
                    <ItemTemplate>
                        <asp:Label ID="PayableDateTextBox" runat="server" Text='<%# Bind("PayableDate", "{0:dd MMM yy}") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="PayableDateTextBox" runat="server" Text='<%# Bind("PayableDate") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Franking Credit">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("FrankingCredit") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="FrankingCreditTextBox" runat="server" Text='<%# Bind("FrankingCredit") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Closing Price">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("ClosingPrice") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="ClosingPriceTextBox" runat="server" Text='<%# Bind("ClosingPrice") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


        <asp:EntityDataSource runat="server" ID="StocksEntityDataSource"
            OnContextCreating="StocksEntityDataSource_OnContextCreating" EnableUpdate="True" EntitySetName="StockDividends"
            Where="it.StockCode = @code">
            <WhereParameters>
                <asp:QueryStringParameter Type="String" Name="code" QueryStringField="code" />
            </WhereParameters>
        </asp:EntityDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
