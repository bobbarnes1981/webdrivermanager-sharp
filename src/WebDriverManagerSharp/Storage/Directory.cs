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
    using System.Collections.Generic;
    using System.Linq;

    public class Directory : IDirectory
    {
        private System.IO.DirectoryInfo directoryInfo;

        public Directory(string fullPath)
        {
            directoryInfo = new System.IO.DirectoryInfo(fullPath);
        }

        public string Name
        {
            get
            {
                return directoryInfo.Name;
            }
        }

        public string FullName
        {
            get
            {
                return directoryInfo.FullName;
            }
        }

        public IReadOnlyList<IDirectory> ChildDirectories
        {
            get
            {
                return directoryInfo.GetDirectories().Select(d => new Directory(d.FullName)).ToList();
            }
        }

        public IReadOnlyList<IFile> Files
        {
            get
            {
                return directoryInfo.GetFiles().Select(f => new File(f.FullName)).ToList();
            }
        }

        public void Delete(bool recurse)
        {
            directoryInfo.Delete(recurse);
        }

        public bool Exists
        {
            get
            {
                return directoryInfo.Exists;
            }
        }

        public void Create()
        {
            directoryInfo.Create();
        }
    }
}
