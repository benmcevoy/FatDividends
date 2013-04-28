﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="Fat.Umbraco.usercontrols.FatDividends.Dashboard" %>
<%@ Register Assembly="controls" Namespace="umbraco.uicontrols" TagPrefix="umb" %>
<%@ Register Assembly="ClientDependency.Core" Namespace="ClientDependency.Core.Controls" TagPrefix="umb" %>

<umb:CssInclude runat="server" FilePath="propertypane/style.css" PathNameAlias="UmbracoClient" />

<link href="/css/dashboard.css" rel="stylesheet" />

<div id="fatdashboard" class="dashboardWrapper">
    <h2 class="title">Fat Dividends</h2>
    <img src="../css/Images/logo.png" alt="Fat Dividend Logo" class="dashboardIcon" />
    <h3>Manage Stock Data</h3>
    <p>TODO: add links to manage with CRUD for:</p>
    <ul>
        <li>Stocks</li>
        <li>Dividends</li>
        <li>Earnings</li>
    </ul>


</div>
