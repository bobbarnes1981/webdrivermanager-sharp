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

namespace WebDriverManagerSharp.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    // TODO: Convert to app.config
    public class Properties
    {
        private readonly Dictionary<string, string> dict;

        public Properties()
        {
            dict = new Dictionary<string, string>();
        }

        public void Load(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("#", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] parts = line.Split('=');
                    dict.Add(parts[0], parts[1]);
                }
            }
        }

        public string GetProperty(string name)
        {
            if (!dict.ContainsKey(name))
            {
                return null;
            }

            return dict[name];
        }
    }
}
