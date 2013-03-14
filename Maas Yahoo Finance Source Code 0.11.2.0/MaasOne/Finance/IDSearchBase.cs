﻿// ******************************************************************************
// ** 
// **  MaasOne WebServices
// **  Written by Marius Häusler 2012
// **  It would be pleasant, if you contact me when you are using this code.
// **  Contact: YahooFinanceManaged@gmail.com
// **  Project Home: http://code.google.com/p/yahoo-finance-managed/
// **  
// ******************************************************************************
// **  
// **  Copyright 2012 Marius Häusler
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
using System.Collections.Generic;
using System.Text;


namespace MaasOne.Finance
{
    public abstract class IDSearchBaseSettings<T> : Base.SettingsBase, IQuerySettings where T : IDSearchBaseResult
    {
        public string Query { get; set; }
    }



    public abstract class IDSearchBaseResult
    {

        private IDSearchBaseData[] mItems = null;
        public IDSearchBaseData[] Items { get { return mItems; } }

        public IDSearchBaseResult(IDSearchBaseData[] items)
        {
            mItems = items;
        }

    }


    public abstract class IDSearchBaseData : IID
    {
        private string mID = string.Empty;
        /// <summary>
        /// The ID of the stock, index, etc.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public string ID
        {
            get { return mID; }
        }

        public IDSearchBaseData(string id)
        {
            mID = id;
        }

    }



}
