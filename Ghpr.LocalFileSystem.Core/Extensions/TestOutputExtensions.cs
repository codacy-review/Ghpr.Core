﻿using System.IO;
using Ghpr.Core.Core.Extensions;
using Ghpr.LocalFileSystem.Core.Entities;
using Ghpr.LocalFileSystem.Core.Providers;
using Newtonsoft.Json;

namespace Ghpr.LocalFileSystem.Core.Extensions
{
    public static class TestOutputExtensions
    {
        public static string Save(this TestOutput testOutput, string path)
        {
            path.Create();
            var fullPath = Path.Combine(path, NamesProvider.GetTestOutputFileName(testOutput.TestOutputInfo.Date));
            using (var file = File.CreateText(fullPath))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, testOutput);
            }
            return fullPath;
        }

        public static TestOutput LoadTestOutput(this string fullPath)
        {
            TestOutput testOutput;
            using (var file = File.OpenText(fullPath))
            {
                var serializer = new JsonSerializer();
                testOutput = (TestOutput)serializer.Deserialize(file, typeof(TestOutput));
            }
            return testOutput;
        }
    }
}