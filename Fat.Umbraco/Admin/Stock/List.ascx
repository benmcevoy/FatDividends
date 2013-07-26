<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="Fat.Umbraco.Admin.Stock.List" %>

<div id="stock">
    <h2>stocks</h2>

    <ul class="metro-list inline">
        <li>
            <asp:TextBox runat="server" ID="FilterTextBox"></asp:TextBox>
            <asp:Button runat="server" Text="filter" OnClick="FilterButton_Click" />
        </li>
        <li>
            <asp:LinkButton runat="server" Text="create" ToolTip="create new stock" OnClick="Create_Click" /></li>
        <li>
            <asp:LinkButton runat="server" Text="download" ToolTip="download as csv" OnClick="Download_Click" /></li>
    </ul>

    <asp:GridView runat="server" DataSourceID="StocksEntityDataSource"
        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="Code">
        <Columns>
            <asp:CommandField ShowEditButton="True">
                <HeaderStyle Width="50px" />
                <ItemStyle Width="50px" />
            </asp:CommandField>

            <asp:TemplateField HeaderText="Code" SortExpression="Code">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Code") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Code") %>' />
                </EditItemTemplate>
                <ItemStyle Width="50px" />
                <HeaderStyle Width="50px" />
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
                    <asp:DropDownList ID="IndustryDropDownList" runat="server"
                        DataSourceID="IndustryDataSource"
                        DataTextField="Industry" DataValueField="Industry" SelectedValue='<%# Bind("Industry") %>' />
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

            <asp:HyperLinkField HeaderText="Dividends" Text="Dividends"
                DataNavigateUrlFields="code,name" DataNavigateUrlFormatString="/admin/dividends/listpage.aspx?code={0}&name={1}">
                <HeaderStyle Width="10%" />
                <ItemStyle Width="10%" />
            </asp:HyperLinkField>
            <asp:HyperLinkField HeaderText="Earnings" Text="Earnings"
                DataNavigateUrlFields="code,name" DataNavigateUrlFormatString="/admin/earnings/listpage.aspx?code={0}&name={1}">
                <HeaderStyle Width="10%" />
                <ItemStyle Width="10%" />
            </asp:HyperLinkField>

        </Columns>
    </asp:GridView>
    
    

    <asp:EntityDataSource runat="server" ID="StocksEntityDataSource"
        OnContextCreating="StocksEntityDataSource_OnContextCreating" EnableUpdate="True" EnableInsert="True"
        EntitySetName="Stocks">
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server" ID="IndustryDataSource"
        OnContextCreating="StocksEntityDataSource_OnContextCreating"
        EntitySetName="Stocks" Select="it.Industry" GroupBy="it.Industry">
    </asp:EntityDataSource>

    <asp:QueryExtender ID="SearchQueryExtender" runat="server"
        TargetControlID="StocksEntityDataSource">
        <asp:SearchExpression SearchType="StartsWith" DataFields="Code, Name">
            <asp:ControlParameter ControlID="FilterTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression DataField="Code" Direction="Ascending" />
    </asp:QueryExtender>
</div>
