// ******************************************************************************
// ** 
// **  Yahoo! Managed
// **  Written by Marius H�usler 2012
// **  It would be pleasant, if you contact me when you are using this code.
// **  Contact: YahooFinanceManaged@gmail.com
// **  Project Home: http://code.google.com/p/yahoo-finance-managed/
// **  
// ******************************************************************************
// **  
// **  Copyright 2012 Marius H�usler
// **  
// **  Licensed under the Apache License, Version 2.0 (the "License");
// **  you may not use this file except in compliance with the License.
// **  You may obtain a copy of the License at
// **  
// **    http://www.apache.org/licenses/LICENSE-2.0
// **  
// **  Unless required by applicable law or agreed to in writing, software
// **  distributed under the License is distributed on an "AS IS" BASIS,
// **  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// **  See the License for the specific language governing permissions and
// **  limitations under the License.
// ** 
// ******************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using MaasOne.Xml;
using MaasOne.Finance.YahooFinance;


namespace MaasOne.Finance.YahooScreener.Criterias
{

	public class EarningsGrowthPast5YearsCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Earnings Growth (past 5 years) Criteria"; }
		}

		public override string CriteriaName {
			get { return "Earnings Growth (past 5 years)"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.EarningsGrowth_Past5Years}; }
		}

		public EarningsGrowthPast5YearsCriteria() : base("8v")
		{
		}
	}

	public class RevenueEstimateThisQuarterCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Revenue Estimate (this quarter) Criteria"; }
		}

		public override string CriteriaName {
			get { return "Revenue Estimate (this quarter)"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.RevenueEstimate_ThisQuarter}; }
		}

		public RevenueEstimateThisQuarterCriteria() : base("9a")
		{
		}
	}

	public class RevenueEstimateNextQuarterCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Revenue Estimate (next quarter) Criteria"; }
		}

		public override string CriteriaName {
			get { return "Revenue Estimate (next quarter)"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.RevenueEstimate_NextQuarter}; }
		}

		public RevenueEstimateNextQuarterCriteria() : base("8q")
		{
		}
	}

	public class SalesGrowthEstNextQuarterCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Sales Growth Estimate (next quarter) Criteria"; }
		}

		public override string CriteriaName {
			get { return "Sales Growth Estimate (next quarter)"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.SalesGrowthEstimate_NextQuarter}; }
		}

		public SalesGrowthEstNextQuarterCriteria() : base("8s")
		{
		}
	}

	public class SalesGrowthEstThisYearCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Sales Growth Estimate (this year) Criteria"; }
		}

		public override string CriteriaName {
			get { return "Sales Growth Estimate (this year)"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.SalesGrowthEstimate_ThisYear}; }
		}

		public SalesGrowthEstThisYearCriteria() : base("8t")
		{
		}
	}

	public class SalesGrowthEstNextYearCriteria : StockDigitCriteriaDefinition
	{

		public override string DisplayName {
			get { return "Sales Growth Estimate (next year)Criteria"; }
		}

		public override string CriteriaName {
			get { return "Sales Growth Estimate"; }
		}

		public override StockScreenerCriteriaGroup CriteriaGroup {
			get { return StockScreenerCriteriaGroup.Growth; }
		}
		public override QuoteProperty[] ProvidedQuoteProperties {
			get { return new  QuoteProperty[] {QuoteProperty.Symbol,QuoteProperty.Name,QuoteProperty.LastTradePriceOnly,QuoteProperty.LastTradeTime,QuoteProperty.MarketCapitalization}; }
		}
		public override StockScreenerProperty[] ProvidedScreenerProperties {
			get { return new  StockScreenerProperty[] {StockScreenerProperty.ReturnOnEquity,StockScreenerProperty.ReturnOnAssets,StockScreenerProperty.ForwardPriceToEarningsRatio,StockScreenerProperty.SalesGrowthEstimate_NextYear}; }
		}

		public SalesGrowthEstNextYearCriteria() : base("8k")
		{
		}
	}

}
