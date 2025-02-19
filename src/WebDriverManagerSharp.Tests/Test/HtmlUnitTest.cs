﻿/*
 * (C) Copyright 2018 Boni Garcia (http://bonigarcia.github.io/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace WebDriverManagerSharp.Tests.Test
{
    using System;
    using NUnit.Framework;
    using WebDriverManagerSharp.Tests.Base;

    /**
     * Test with HtmlUnit browser (which uses void driver manager).
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 1.0.0
     */
    public class HtmlUnitTest : BrowserTestParent
    {
        private static readonly Type webDriverClass;

        [OneTimeSetUp]
        public static void SetupClass()
        {
            Assert.Ignore("HtmlUnitDriver not relevant for .NET");
//            webDriverClass = typeof(HtmlUnitDriver);
            WebDriverManager.GetInstance(webDriverClass).Setup();
        }

        [SetUp]
        public void HtmlUnitDriverTest()
        {
//            driver = new HtmlUnitDriver();
        }
    }
}