﻿// ******************************************************************************
// ** 
// **  Yahoo! Managed (MaasOne.Base)
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


namespace MaasOne
{
    public class Link
    {
        private string mTitle = string.Empty;
        private Uri mLink = null;
        public string Title
        {
            get { return mTitle; }
        }
        public Uri Url
        {
            get { return mLink; }
        }

        public Link(string title, Uri lnk)
        {
            mTitle = title;
            mLink = lnk;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
