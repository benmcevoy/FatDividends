<%@ Page Title="ASX Quotes" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="IndexPage.aspx.cs" Inherits="Fat.Umbraco.Admin.IndexQuote.IndexPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div id="indexquotes">
        <h2>index | asx</h2>

        <ul class="metro-list">
        </ul>
        <div id="indexChart" class="widget">
            <section>
                <h4>Market Last <span id="displaycount">30</span> Days</h4>
                <div id="marketIndexChart"></div>
            </section>
        </div>

        <ul class="metro-list inline">
            <li><a class="quote-display-count" data-count="30">30</a></li>
            <li><a class="quote-display-count" data-count="60">60</a></li>
            <li><a class="quote-display-count" data-count="90">90</a></li>
            <li><a class="quote-display-count" data-count="365">365</a></li>
            <li><a class="quote-display-count" data-count="all">all</a></li>
            <li>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="download" ToolTip="download as csv" OnClick="Download_Click" /></li>
        </ul>

    </div>
    <asp:HiddenField runat="server" ClientIDMode="Static" ID="QuotesToShow" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.quote-display-count').click(function (e) {
                e.preventDefault();

                var data = $(this).data();
                var count = data.count;
                if (data.count == 'all') {
                    count = 100000;
                }

                $('#QuotesToShow').val(count);
                $('#displaycount').text(data.count);

                fat.charts.drawIndexChart(e, count);
            });
        });

        var fat = fat || {};

        fat.charts = (function ($) {
            var drawIndexChart = function (e, count) {
                if (count == undefined) {
                    count = 30;
                }

                $.ajax({
                    url: '/api/indexquote/get/' + count
                }).done(function (data) {

                    // reproject to google format (array of array)
                    data = $.map(data, function (value, key) { return [[value.FormattedDate, value.Price]]; });

                    var chartData = google.visualization.arrayToDataTable(data, true);
                    var chart = new google.visualization.LineChart(document.getElementById('marketIndexChart'));

                    chartData.addColumn('number', 'Price');

                    var chartOptions = {
                        curveType: 'function',
                        width: 360,
                        height: 180,
                        legend: 'none',
                        pointSize: 1,
                        colors: ['#17A9DA']
                    };

                    chart.draw(chartData, chartOptions);
                });
            };

            return {
                drawIndexChart: drawIndexChart
            };
        }(jQuery));

        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(fat.charts.drawIndexChart);

    </script>
</asp:Content>
