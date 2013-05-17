<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="Fat.Umbraco.usercontrols.FatDividends.Stock.List" %>

<div>
    <asp:Label runat="server" AssociatedControlID="SearchTextBox" Text="Code or Name Starts With:" />
    <asp:TextBox runat="server" ID="SearchTextBox" Text="" />
    <asp:Button runat="server" Text="Filter" OnClick="FilterButton_Click" />
</div>

<asp:GridView runat="server" DataSourceID="StocksEntityDataSource"
    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="Code">
    <Columns>
        <asp:CommandField ShowEditButton="True">
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" />
        </asp:CommandField>

        <asp:TemplateField HeaderText="Code" SortExpression="Code">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("Code") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("Code") %>' />
            </EditItemTemplate>
            <ItemStyle Width="10%" />
            <HeaderStyle Width="10%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Name" SortExpression="Name">
            <ItemTemplate>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Industry" SortExpression="Industry">
            <ItemTemplate>
                <asp:Label ID="IndustryLabel" runat="server" Text='<%# Bind("Industry") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="IndustryTextBox" runat="server" Text='<%# Bind("Industry") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Last Refresh">
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("LastRefreshDateTime") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("LastRefreshDateTime") %>' />
            </EditItemTemplate>
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Active?" SortExpression="IsActive">
            <ItemTemplate>
                <asp:Label ID="IsActiveLabel" runat="server" Text='<%# Bind("IsActive") %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="IsActiveCheckBox" runat="server" Checked='<%# Bind("IsActive") %>' />
            </EditItemTemplate>
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" />
        </asp:TemplateField>

        <asp:HyperLinkField HeaderText="Dividends" Text="Dividends">
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" />
        </asp:HyperLinkField>
        <asp:HyperLinkField HeaderText="Earnings" Text="Earnings">
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" />
        </asp:HyperLinkField>

    </Columns>
</asp:GridView>

<asp:EntityDataSource runat="server" ID="StocksEntityDataSource"
    OnContextCreating="StocksEntityDataSource_OnContextCreating"
    EntitySetName="Stocks">
</asp:EntityDataSource>

<asp:QueryExtender ID="SearchQueryExtender" runat="server"
    TargetControlID="StocksEntityDataSource">
    <asp:SearchExpression SearchType="StartsWith" DataFields="Code, Name">
        <asp:ControlParameter ControlID="SearchTextBox" />
    </asp:SearchExpression>
    <asp:OrderByExpression DataField="Code" Direction="Ascending" />
</asp:QueryExtender>
