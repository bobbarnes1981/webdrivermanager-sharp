﻿/*
 * (C) Copyright 2015 Boni Garcia (http://bonigarcia.github.io/)
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

using System.Collections.Generic;

namespace WebDriverManagerSharp
{
    /**
     * Manager for Internet Explorer.
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 1.0.0
     */
    public class InternetExplorerDriverManager : WebDriverManager
    {

        protected override DriverManagerType? GetDriverManagerType()
        {
            return DriverManagerType.IEXPLORER;
        }

        protected override string GetDriverName()
        {
            return "IEDriverServer";
        }

        protected override string GetDriverVersion()
        {
            return Config().getInternetExplorerDriverVersion();
        }

        protected override System.Uri GetDriverUrl()
        {
            return Config().getInternetExplorerDriverUrl();
        }

        protected override System.Uri GetMirrorUrl()
        {
            return null;
        }

        protected override string GetExportParameter()
        {
            return Config().getInternetExplorerDriverExport();
        }

        protected override void SetDriverVersion(string version)
        {
            Config().setInternetExplorerDriverVersion(version);
        }

        protected override void SetDriverUrl(System.Uri url)
        {
            Config().setInternetExplorerDriverUrl(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="IOException" />
        /// <returns></returns>
        protected override List<System.Uri> GetDrivers()
        {
            return getDriversFromXml(GetDriverUrl());
        }

        protected override string GetBrowserVersion()
        {
            return null;
        }
    }
}