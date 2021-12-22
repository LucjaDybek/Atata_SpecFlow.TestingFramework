using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IFlow.Testing.Utils.ObjectUtils
{
    public static class StringUtilities
    {
        private const string LowerCaseAlphabet = "abcdefghijklmnopqrstuvwyxz";
        private const string RandomStringByLengthPattern = @"__(\d*)";

        public static string GenerateShortId()
        {
            return Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
        }

        public static string GenerateFileTimeStamp()
        {
            return $"{DateTime.Now:dd-MM-yyyy_HH-mm-ss}";
        }

        public static string GenerateScreenshotTimeStamp()
        {
            return $"{DateTime.Now:dd-MM-yyyy HH.mm.ss tt}";
        }

        public static string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(LowerCaseAlphabet, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public static string AddRandomStringByPattern(string text, string pattern = RandomStringByLengthPattern)
        {
            var randomStringLength = Regex.Match(text, pattern).Success ? int.Parse(Regex.Match(text, pattern).Groups[1].Value) : 0;
            return Regex.Replace(text, "__", StringUtilities.GetRandomString(randomStringLength));
        }
    }
}
