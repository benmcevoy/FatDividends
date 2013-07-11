<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="Fat.Umbraco.Admin.Earnings.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div>

        <h2>earnings |
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
            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="StockCode, ReportedDate">
            <EmptyDataTemplate>
                <div>
                    No earnings found. Return to <a href="/Admin/HomePage.aspx">stocks</a>
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

                <asp:TemplateField HeaderText="Reported Date" SortExpression="ReportedDate">
                    <ItemTemplate>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("ReportedDate", "{0:dd MMM yy}") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReportedDate") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Year">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Year") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="YearTextBox" runat="server" Text='<%# Bind("Year") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Period">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Period") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="PeriodTextBox" runat="server" Text='<%# Bind("Period") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NPAT">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("NPAT") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="NPATTextBox" runat="server" Text='<%# Bind("NPAT") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="100px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Margin">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Margin") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="MarginTextBox" runat="server" Text='<%# Bind("Margin") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cash Flow">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("CashFlow") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="CashFlowTextBox" runat="server" Text='<%# Bind("CashFlow") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EPS">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("EPS") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EPSTextBox" runat="server" Text='<%# Bind("EPS") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DPS">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("DPS") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="DPSTextBox" runat="server" Text='<%# Bind("DPS") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ROE">
                    <ItemTemplate>
                        <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("ROE") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="ROETextBox" runat="server" Text='<%# Bind("ROE") %>' />
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


        <asp:EntityDataSource runat="server" ID="StocksEntityDataSource"
            OnContextCreating="StocksEntityDataSource_OnContextCreating" EnableUpdate="True" EntitySetName="StockEarnings"
            Where="it.StockCode = @code">
            <WhereParameters>
                <asp:QueryStringParameter Type="String" Name="code" QueryStringField="code" />
            </WhereParameters>
        </asp:EntityDataSource>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
