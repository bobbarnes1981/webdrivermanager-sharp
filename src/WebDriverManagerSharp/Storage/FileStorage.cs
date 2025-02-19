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

namespace WebDriverManagerSharp.Storage
{
    using System.IO;
    using System.Reflection;

    public class FileStorage : IFileStorage
    {
        public bool DirectoryExists(string directory)
        {
            return System.IO.Directory.Exists(directory);
        }

        public bool FileExists(string file)
        {
            return System.IO.File.Exists(file);
        }

        public string GetCurrentDirectory()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }

        public string[] GetFileNames(string directory, string filter)
        {
            return System.IO.Directory.GetFiles(directory, filter);
        }

        public FileInfo[] GetFileInfos(string directory, string filter, SearchOption searchOption)
        {
            return new DirectoryInfo(directory).GetFiles(filter, searchOption);
        }

        public Stream OpenRead(string file)
        {
            return System.IO.File.OpenRead(file);
        }

        public string[] ReadAllLines(string file)
        {
            return System.IO.File.ReadAllLines(file);
        }
    }
}
