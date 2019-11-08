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
using System.Collections.Generic;
using System.IO;

namespace WebDriverManager
{
    /**
     * Manager for selenium-server-standalone.
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 3.0.1
     */
    public class SeleniumServerStandaloneManager : WebDriverManager
    {
        protected override DriverManagerType? GetDriverManagerType()
        {
            return DriverManagerType.SELENIUM_SERVER_STANDALONE;
        }

        protected override string GetDriverName()
        {
            return "selenium-server-standalone";
        }

        protected override string GetDriverVersion()
        {
            return Config().getSeleniumServerStandaloneVersion();
        }

        protected override System.Uri GetDriverUrl()
        {
            return Config().getSeleniumServerStandaloneUrl();
        }

        protected override System.Uri GetMirrorUrl()
        {
            return null;
        }

        protected override string GetExportParameter()
        {
            return null;
        }


        protected override void SetDriverVersion(string version)
        {
            Config().setSeleniumServerStandaloneVersion(version);
        }

        protected override void SetDriverUrl(System.Uri url)
        {
            Config().setSeleniumServerStandaloneUrl(url);
        }

        public override FileInfo postDownload(FileInfo archive)
        {
            return archive;
        }

        protected override string GetBrowserVersion()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="IOException"/>
        /// <returns></returns>
        protected override List<System.Uri> GetDrivers()
        {
            return getDriversFromXml(GetDriverUrl());
        }
    }
}