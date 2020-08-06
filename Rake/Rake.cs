using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Rake
{
    public class Rake
    {
        private readonly int _minCharLength;
        private readonly int _maxWordsLength;
        private readonly double _minKeywordFrequency;
        private readonly HashSet<string> _stopWords;

        public Rake(
            string? stopWordsPath = null,
            int minCharLength = 1,
            int maxWordsLength = 5, 
            double minKeywordFrequency = 1)
        {
            _minCharLength = minCharLength;
            _maxWordsLength = maxWordsLength;
            _minKeywordFrequency = minKeywordFrequency;
            _stopWords = StopListHelper.ParseFromPath(stopWordsPath);
        }

        public Rake(
            HashSet<string> stopWords,
            int minCharLength = 1,
            int maxWordsLength = 5,
            double minKeywordFrequency = 1)
        {
            _minCharLength = minCharLength;
            _maxWordsLength = maxWordsLength;
            _minKeywordFrequency = minKeywordFrequency;
            _stopWords = stopWords ?? new HashSet<string>();
        }

        public Dictionary<string, double> Run(string text)
        {
            string[] sentenceList = SplitSentences(text.ToLowerInvariant());

            var phraseList = GenerateCandidateKeywords(sentenceList, _minCharLength, _maxWordsLength);

            var wordScores = CalculateWordScores(phraseList);

            var keywordCandidates = GenerateCandidateKeywordScores(phraseList, wordScores, _minKeywordFrequency);

            return keywordCandidates
                .OrderByDescending(pair => pair.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private Dictionary<string, double> GenerateCandidateKeywordScores(
            List<string> phraseList, 
            Dictionary<string, double> wordScores,
            double minKeywordFrequency)
        {
            var keywordCandidates = new Dictionary<string, double>();

            foreach (var phrase in phraseList)
            {
                if (minKeywordFrequency > 1)
                {
                    if (phraseList.Count(s => s.Equals(phrase)) < minKeywordFrequency)
                        continue;
                }

                if (!keywordCandidates.ContainsKey(phrase)) keywordCandidates[phrase] = 0;

                var words = SeparateWords(phrase, 0);
                var candidateScore = words.Sum(word => wordScores[word]);

                keywordCandidates[phrase] = candidateScore;
            }

            return keywordCandidates;
        }

        private Dictionary<string, double> CalculateWordScores(IEnumerable<string> lowerCasedPhraseList)
        {
            var wordFrequency = new Dictionary<string, double>();
            var wordDegree = new Dictionary<string, double>();

            foreach (var phrase in lowerCasedPhraseList)
            {
                var words = SeparateWords(phrase, 0);
                var wordsLength = words.Count;

                var wordListDegree = wordsLength - 1;
                // if word_list_degree > 3: word_list_degree = 3 #exp.

                foreach (var word in words)
                {
                    if (!wordFrequency.ContainsKey(word)) wordFrequency[word] = 0;

                    wordFrequency[word] = wordFrequency[word] + 1;

                    if (!wordDegree.ContainsKey(word)) wordDegree[word] = 0;

                    wordDegree[word] = wordDegree[word] + wordListDegree; // orig.
                                                                          // word_degree[word] += 1/(word_list_length*1.0) #exp.
                }
            }
            foreach (var item in wordFrequency)
            {
                wordDegree[item.Key] = wordDegree[item.Key] + wordFrequency[item.Key];
            }

            // Calculate Word scores = deg(w)/frew(w)
            var wordScore = new Dictionary<string, double>();
            foreach (var item in wordFrequency)
            {
                if (!wordScore.ContainsKey(item.Key)) wordScore[item.Key] = 0;

                wordScore[item.Key] = wordDegree[item.Key] / (wordFrequency[item.Key] * 1.0); // orig.
                                                                                              // word_score[item] = word_frequency[item]/(word_degree[item] * 1.0) #exp.
            }

            return wordScore;
        }

        private static readonly Regex splitter = new Regex(@"[^a-zA-Z0-9_\+\-/]", RegexOptions.Compiled);

        /// <summary>
        /// Utility function to return a list of all words that are have a length greater than a specified number of characters.
        /// </summary>
        /// <param name="phrase">The text that must be split in to words.</param>
        /// <param name="minWordReturnSize">The minimum no of characters a word must have to be included.</param>
        /// <returns></returns>
        private List<string> SeparateWords(string phrase, int minWordReturnSize)
        {
            var words = new List<string>();

            foreach (var singleWord in splitter.Split(phrase))
            {
                var currentWord = singleWord.Trim();
                // leave numbers in phrase, but don't count as words, since they tend to invalidate scores of their phrases

                if (!string.IsNullOrWhiteSpace(currentWord) && currentWord.Length > minWordReturnSize &&
                    !IsNumber(currentWord))
                {
                    words.Add(currentWord);
                }
            }

            return words;
        }

        private static bool IsNumber(string word) => float.TryParse(word, out _);

        private List<string> GenerateCandidateKeywords(
            string[] sentenceList,
            int minCharLength, 
            int maxWordsLength)
        {
            var phraseList = new List<string>();

            var sb = new StringBuilder();

            foreach (string sentence in sentenceList)
            {
                string sLowerCase = sentence.Trim();

                var wordSplitter = new StringSplitter(sLowerCase.AsSpan(), ' ');

                while (wordSplitter.TryGetNext(out var wordSpan))
                {
                    string word = wordSpan.ToString();

                    if (_stopWords.Contains(word))
                    {
                        string phrase = sb.ToString().Trim();

                        if (!string.IsNullOrWhiteSpace(phrase)
                            && IsAcceptable(phrase, minCharLength, maxWordsLength))
                        {
                            phraseList.Add(phrase);
                        }

                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(word).Append(' ');
                    }
                }

                string p2 = sb.ToString().Trim();

                if (!string.IsNullOrWhiteSpace(p2)
                    && IsAcceptable(p2, minCharLength, maxWordsLength))
                {
                    phraseList.Add(p2);
                }

                sb.Clear();
            }

            return phraseList;
        }

        private static bool IsAcceptable(string phrase, int minCharLength, int maxWordsLength)
        {
            if (phrase.Length < minCharLength) return false;

            var wordSplitter = new StringSplitter(phrase.AsSpan(), ' ');

            int wordCount = 0;

            while (wordSplitter.TryGetNext(out _))
            {
                wordCount++;
            }

            if (wordCount > maxWordsLength)
            {
                return false;
            }

            var digits = 0;
            var alpha = 0;

            for (var i = 0; i < phrase.Length; i++)
            {
                if (char.IsDigit(phrase[i])) digits++;
                if (char.IsLetter(phrase[i])) alpha++;
            }

            // a phrase must have at least one alpha character
            if (alpha == 0) return false;

            // a phrase must have more alpha than digits characters
            if (digits > alpha) return false;

            return true;
        }

        private static readonly Regex sentenceDelimiters = new Regex(@"[\[\]\n.!?,;:\t\-\""”“\(\)\\\'\u2019\u2013]", RegexOptions.Compiled);

        /// <summary>
        /// Utility function to return a list of sentences.
        /// </summary>
        /// <param name="text">The text that must be split in to sentences</param>
        /// <returns></returns>
        private static string[] SplitSentences(string text)
        {
            var sentences = sentenceDelimiters.Split(text);

            return sentences;
        }
    }
}
