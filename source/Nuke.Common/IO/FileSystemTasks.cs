﻿// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Glob;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Utilities.Collections;

[assembly: IconClass(typeof(FileSystemTasks), "folder-open")]

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class FileSystemTasks
    {
        public static void PrepareCleanDirectory (string directory)
        {
            var directoryInfo = new DirectoryInfo (directory);
            if (!directoryInfo.Exists)
            {
                Logger.Info ($"Creating directory '{directoryInfo.FullName}'...");
                directoryInfo.Create ();
            }
            else
            {
                Logger.Info ($"Cleaning directory '{directoryInfo.FullName}'...");
                directoryInfo.GetDirectories ().ForEach (x => x.Delete (recursive: true));
                directoryInfo.GetFiles ().ForEach (x => x.Delete ());
            }
        }

        public static void PrepareCleanDirectories (IEnumerable<string> directories)
        {
            directories.ForEach(PrepareCleanDirectory);
        }

        public static void DeleteDirectory (string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Logger.Info($"Deleting directory '{directory}'...");
            DeleteDirectoryInternal(directory);
        }

        public static void DeleteDirectories (IEnumerable<string> directories)
        {
            directories.ForEach(DeleteDirectory);
        }

        public static void DeleteDirectoryInternal(string directory)
        {
            Directory.GetFiles(directory).ForEach(DeleteFile);
            Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
            Directory.Delete(directory, recursive: false);
        }

        private static void DeleteFile(string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        //public static void Copy (IEnumerable<string> sources, string destination)
        //{
        //}

        //public static IEnumerable<string> GetFiles (string directory, string filePattern, bool includeSubDirectories = true)
        //{
        //    return Directory.GetFiles (directory, filePattern, includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        //}

        [Pure]
        public static IEnumerable<string> GlobFiles (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return globPatterns.SelectMany(x => directoryInfo.GlobFiles(x)).Select(x => x.FullName);
        }

        [Pure]
        public static IEnumerable<string> GlobDirectories (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return globPatterns.SelectMany(x => directoryInfo.GlobDirectories(x)).Select(x => x.FullName);
        }

        [Pure]
        public static string GetRelativePath (string basePath, string destinationPath)
        {
            return Uri.UnescapeDataString(new Uri($@"{basePath}\").MakeRelativeUri(new Uri(destinationPath)).ToString());
        }
    }
}
