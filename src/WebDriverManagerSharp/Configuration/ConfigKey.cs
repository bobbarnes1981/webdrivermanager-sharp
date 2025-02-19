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

namespace WebDriverManagerSharp.Configuration
{
    /**
     * Configuration key class.
     *
     * @author Boni Garcia (boni.gg@gmail.com)
     * @since 2.2.0
     */
    public class ConfigKey<T>
    {
        private readonly string name;
        private readonly T defaultValue;
        private T value;

        public ConfigKey(string name)
        {
            this.name = name;
            this.defaultValue = default(T);
        }

        public ConfigKey(string name, T value)
        {
            this.name = name;
            this.value = value;
            this.defaultValue = value;
        }

        public string GetName()
        {
            return name;
        }

        public T GetValue()
        {
            return value;
        }

        public void Reset()
        {
            value = defaultValue;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }
    }
}