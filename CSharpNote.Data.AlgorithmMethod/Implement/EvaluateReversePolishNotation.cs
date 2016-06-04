using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// https://oj.leetcode.com/problems/evaluate-reverse-polish-notation/
    /// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
    /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
    /// Some examples:
    /// ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
    /// ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
    public class EvaluateReversePolishNotation : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var evaluate = new List<string> {"4", "13", "5", "/", "+"};
            var notation = new List<string> {"+", "-", "*", "/"};
            while (evaluate.Count != 1)
                for (var i = 0; i < evaluate.Count - 2; i++)
                {
                    int value1;
                    int value2;
                    if (!int.TryParse(evaluate[i], out value1)
                        || !int.TryParse(evaluate[i + 1], out value2)
                        || notation.All(n => n != evaluate[i + 2]))
                        continue;

                    Caculate(value1, value2, i + 2, evaluate);
                    break;
                }

            Console.WriteLine(evaluate.First());
        }

        private void Caculate(int x, int y, int postion, List<string> evaluate)
        {
            switch (evaluate[postion])
            {
                case "+":
                    evaluate[postion] = (x + y).ToString();
                    break;
                case "-":
                    evaluate[postion] = (x - y).ToString();
                    break;
                case "*":
                    evaluate[postion] = (x*y).ToString();
                    break;
                case "/":
                    evaluate[postion] = (x/y).ToString();
                    break;
            }

            evaluate.Remove(evaluate[postion - 1]);
            evaluate.Remove(evaluate[postion - 2]);
        }
    }
}