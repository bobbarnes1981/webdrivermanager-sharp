﻿/*
 * (C) Copyright 2019 Boni Garcia (http://bonigarcia.github.io/)
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

namespace WebDriverManager.Tests.Test
{
    /**
     * Force download test.
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 3.3.0
     */
    public class ForceError403Test
    {
        private readonly ILogger log = Logger.GetLogger();

        private static readonly int NUM = 40;

        [Ignore("")]
        [Test]
        public void test403()
        {
            for (int i = 0; i < NUM; i++)
            {
                log.Debug("Forcing 403 error {0}/{1}", i + 1, NUM);
                WebDriverManager.firefoxdriver().avoidAutoVersion().avoidPreferences().setup();
                Assert.That(WebDriverManager.firefoxdriver().getBinaryPath(), Is.Not.Null);
            }
        }
    }
}