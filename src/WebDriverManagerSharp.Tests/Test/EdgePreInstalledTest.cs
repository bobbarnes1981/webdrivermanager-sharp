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

using NUnit.Framework;
using System.IO;

namespace WebDriverManagerSharp.Tests.Test
{
    /**
     * Test with Microsoft Edge using pre-installed version.
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 3.0.0
     */
    public class EdgePreInstalledTest
    {
        private readonly ILogger log = Logger.GetLogger();

        FileInfo microsoftWebDriverFile = new FileInfo(Path.Combine(System.Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "MicrosoftWebDriver.exe"));

        [Test]
        public void testInsiderExists()
        {
            Assume.That(microsoftWebDriverFile.Exists);
            exerciseEdgeInsider();
        }

        [Test]
        public void testInsiderNotExists()
        {
            Assume.That(!microsoftWebDriverFile.Exists);

            Assert.Throws<WebDriverManagerException>(exerciseEdgeInsider);
        }

        private void exerciseEdgeInsider()
        {
            WebDriverManager.edgedriver().operatingSystem(OperatingSystem.WIN).version("pre-installed").setup();
            FileInfo binary = new FileInfo(WebDriverManager.edgedriver().getBinaryPath());
            log.Debug("Edge driver {0}", binary);
            Assert.That(binary.Extension, Is.EqualTo(".exe"));
        }
    }
}