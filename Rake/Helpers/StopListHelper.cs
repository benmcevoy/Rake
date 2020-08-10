using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Rake
{
    internal static class StopListHelper
    {
        public static HashSet<string> ParseFromPath(string? stopWordsPath)
        {
            var stopWords = new HashSet<string>(StringComparer.Ordinal);

            foreach (var line in string.IsNullOrWhiteSpace(stopWordsPath)
                ? ReadDefaultStopListLine()
                : File.ReadAllLines(stopWordsPath))
            {
                ReadOnlySpan<char> normalizedLine = line.AsSpan().Trim();

                if (normalizedLine.Length == 0 || normalizedLine[0] == '#') continue;

                var splitter = new StringSplitter(normalizedLine, ' ');

                while (splitter.TryGetNext(out var word))
                {
                    stopWords.Add(word.ToString());
                }
            }

            return stopWords;
        }

        private static IEnumerable<string> ReadDefaultStopListLine()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Rake.SmartStoplist.txt";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
