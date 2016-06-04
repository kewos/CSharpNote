using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     號碼有對應的英文字找出所有可能
    ///     solution
    ///     生成字典樹片遍出所有可能
    /// </summary>
    public class LetterCombinations : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GetLetterCombinations("33429").Dump();
        }

        private IList<string> GetLetterCombinations(string digits)
        {
            return string.IsNullOrEmpty(digits) ? new List<string>() : new PhoneNode(digits).GetCombinations().ToList();
        }

        private class PhoneNode
        {
            private PhoneNode(IEnumerable<PhoneNode> sons)
            {
                Sons = sons;
            }

            private PhoneNode(string phoneNumber, string value)
                : this(phoneNumber)
            {
                Value = value;
            }

            public PhoneNode(string phoneNumber)
                : this(ParseNumber(phoneNumber))
            {
            }

            private string Value { get; set; }
            private IEnumerable<PhoneNode> Sons { get; set; }

            private static IEnumerable<PhoneNode> ParseNumber(string phoneNumber)
            {
                if (string.IsNullOrEmpty(phoneNumber))
                    return null;

                var subNumber = phoneNumber.Substring(1, phoneNumber.Length - 1);
                switch (phoneNumber[0])
                {
                    case '1':
                        return new List<PhoneNode>();
                    case '2':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "a"),
                            new PhoneNode(subNumber, "b"),
                            new PhoneNode(subNumber, "c")
                        };
                    case '3':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "d"),
                            new PhoneNode(subNumber, "e"),
                            new PhoneNode(subNumber, "f")
                        };
                    case '4':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "g"),
                            new PhoneNode(subNumber, "h"),
                            new PhoneNode(subNumber, "i")
                        };
                    case '5':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "j"),
                            new PhoneNode(subNumber, "k"),
                            new PhoneNode(subNumber, "l")
                        };
                    case '6':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "m"),
                            new PhoneNode(subNumber, "n"),
                            new PhoneNode(subNumber, "o")
                        };
                    case '7':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "p"),
                            new PhoneNode(subNumber, "q"),
                            new PhoneNode(subNumber, "r"),
                            new PhoneNode(subNumber, "s")
                        };
                    case '8':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "t"),
                            new PhoneNode(subNumber, "u"),
                            new PhoneNode(subNumber, "v")
                        };
                    case '9':
                        return new List<PhoneNode>
                        {
                            new PhoneNode(subNumber, "w"),
                            new PhoneNode(subNumber, "x"),
                            new PhoneNode(subNumber, "y"),
                            new PhoneNode(subNumber, "z")
                        };
                    default:
                        return null;
                }
            }

            private bool HasSons()
            {
                return Sons != null && Sons.Any();
            }

            public IEnumerable<string> GetCombinations()
            {
                return GetCombinations(this);
            }

            private IEnumerable<string> GetCombinations(PhoneNode node, string msg = "")
            {
                msg = msg + node.Value;

                return !node.HasSons()
                    ? new List<string> {msg}
                    : node.Sons.SelectMany(son => GetCombinations(son, msg));
            }
        }
    }
}