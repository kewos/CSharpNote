using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// https://oj.leetcode.com/problems/word-ladder/
    /// Given two words (start and end), and a dictionary, find the length of shortest transformation sequence from start to end, such that:
    /// Only one letter can be changed at a time
    /// Each intermediate word must exist in the dictionary
    /// For example,
    /// Given:
    /// start = "hit"
    /// end = "cog"
    /// dict = ["hot","dot","dog","lot","log"]
    /// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
    /// return its length 5.
    /// Note:
    /// Return 0 if there is no such transformation sequence.
    /// All words have the same length.
    /// All words contain only lowercase alphabetic characters.
    public class WordLadder : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var start = "hit";
            var end = "cog";
            var dict = new List<string> {"hot", "dot", "dog", "lot", "log"};
            var path = new Stack<string>();

            Translate(start, end, dict, path).ToList().ForEach(Console.WriteLine);
        }

        private Stack<string> Translate(string start, string end, List<string> dict, Stack<string> path)
        {
            if (path.Count == 0)
                path.Push(start);

            if (CheckTranslate(start, end))
            {
                path.Push(end);
                return path;
            }

            foreach (var canTranlate in dict.Where(s => CheckTranslate(start, s) && !path.Contains(s)))
            {
                path.Push(canTranlate);
                return Translate(canTranlate, end, dict, path);
            }

            path.Pop();

            return path;
        }

        private bool CheckTranslate(string s1, string s2)
        {
            return s1.ToList().Intersect(s2.ToList()).Count() == 2;
        }
    }
}