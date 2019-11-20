﻿/*
 * (C) Copyright 2019 Robert barnes
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

namespace WebDriverManagerSharp.UnitTests.Managers
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using WebDriverManagerSharp.Configuration;
    using WebDriverManagerSharp.Processes;
    using WebDriverManagerSharp.Web;

    [TestFixture]
    public class EdgeDriverManagerTests
    {
        private Mock<IConfig> configMock;
        private Mock<IHttpClient> httpClientMock;
        private Mock<IShell> shellMock;

        [SetUp]
        public void SetUp()
        {
            WebDriverManager.ClearDrivers();

            configMock = new Mock<IConfig>();
            httpClientMock = new Mock<IHttpClient>();
            shellMock = new Mock<IShell>();

            Mock<IConfigFactory> configFactoryMock = new Mock<IConfigFactory>();
            configFactoryMock.Setup(x => x.Build()).Returns(configMock.Object);

            Mock<IHttpClientFactory> httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(x => x.Build(It.IsAny<IConfig>())).Returns(httpClientMock.Object);

            Mock<IShellFactory> shellFactoryMock = new Mock<IShellFactory>();
            shellFactoryMock.Setup(x => x.Build()).Returns(shellMock.Object);

            WebDriverManager.ConfigFactory = configFactoryMock.Object;
            WebDriverManager.HttpClientFactory = httpClientFactoryMock.Object;
            WebDriverManager.ShellFactory = shellFactoryMock.Object;
        }

        [Test]
        public void GetVersions()
        {
            System.Uri driverUrl = new System.Uri("https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/");
            configMock.Setup(x => x.GetOs()).Returns("WIN");
            configMock.Setup(x => x.GetEdgeDriverUrl()).Returns(driverUrl);
            configMock.Setup(x => x.GetLocalRepositoryUser()).Returns("fakeUser");
            configMock.Setup(x => x.GetLocalRepositoryPassword()).Returns("fakePass");

            string fakeHtml = "<ul class='driver-downloads'><li class='driver-download'><a aria-label='' href='http://www.microsoft.com'></a></li></ul><ul class='driver-downloads'><li class='driver-download'><p class='driver-download__meta'>version 1</p></li></ul>";

            httpClientMock.Setup(x => x.ExecuteHttpGet(driverUrl, null)).Returns(new MemoryStream(Encoding.ASCII.GetBytes(fakeHtml)));

            List<string> versions = WebDriverManager.EdgeDriver().GetVersions();

            Assert.That(versions, Is.Not.Null);
            Assert.That(versions.Count, Is.EqualTo(1));
        }

        [Test]
        public void SetVersionLatest()
        {
            WebDriverManager.EdgeDriver().Version("latest");

            configMock.Verify(x => x.SetEdgeDriverVersion("latest"), Times.Once);
        }

        [Test]
        public void SetDriverRepositoryUrl()
        {
            Uri uri = new Uri("http://www.uri.com");

            WebDriverManager.EdgeDriver().DriverRepositoryUrl(uri);

            configMock.Verify(x => x.SetEdgeDriverUrl(uri), Times.Once);
        }
    }
}
