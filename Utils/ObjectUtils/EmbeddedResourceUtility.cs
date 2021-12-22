using System;
using System.IO;
using System.Reflection;

namespace IFlow.Testing.Utils.ObjectUtils
{
    public static class EmbeddedResourceUtility
    {
        public static string GetFileContentsFromNamespace(Assembly assembly, string @namespace, string fileName)
        {
            var resourcePath = BuildResourcePath(@namespace, fileName);
            return GetFileContents(assembly, resourcePath);
        }

        private static string GetFileContents(Assembly assembly, string resourcePath)
        {
            using (var stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            "Assembly {0} doesn't contain embedded resource {1}. Check that {1} is marked as EmbeddedResource.",
                            assembly.FullName, resourcePath));
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static string BuildResourcePath(string @namespace, string fileName)
        {
            var resourcePath = $"{@namespace}.{fileName}";
            return resourcePath;
        }
    }
}
