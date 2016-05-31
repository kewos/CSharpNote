using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Helper;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Algorithm.Component;

namespace CSharpNote.Data.Algorithm
{
    [MarkedRepositoryAttribue]
    public class AlgorithmRepository : AbstractRepository
    {
        [MarkedItem]
        public void LargeRepunitFactors()
        {
            //A number consisting entirely of ones is called a repunit. We shall define R(k) to be a repunit of length k.
            //For example, R(10) = 1111111111 = 11×41×271×9091, and the sum of these prime factors is 9414.
            //Find the sum of the first forty prime factors of R(109).
            Console.WriteLine(Calulate(10));
        }

        private int Calulate(int length)
        {
            var number = ConvertToNumberLoop(length);
            var query = GetFactorOfPrimes(number).Take(4);
            return query.Sum();
        }

        /// <summary>
        ///     取得數值質因數
        /// </summary>
        /// <param name="number">需判斷數字</param>
        /// <returns>質因數數列</returns>
        private IEnumerable<int> GetFactorOfPrimes(int number)
        {
            return Enumerable.Range(2, (int) Math.Sqrt(number) - 1)
                .AsParallel().AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(x =>
                    Enumerable.Range(2, (int) Math.Sqrt(x)).All(y => x%y != 0) ||
                    x == 2)
                .Where(x => number%x == 0);
        }

        private int ConvertToNumberLoop(int length)
        {
            var sb = new StringBuilder();
            foreach (var n in Enumerable.Repeat("1", length)) sb.Append(n);

            return int.Parse(sb.ToString());
        }

        [MarkedItem]
        public void CoinPartitions()
        {
            Console.WriteLine(CaculateCoinPartitions(5));
        }

        private int CaculateCoinPartitions(int total)
        {
            var sum = 0;
            for (var i = 1; i <= total; i++)
            {
                var leak = total - i;
                if (leak > 0)
                {
                    sum += CaculateCoinPartitions(leak);
                    continue;
                }

                if (leak == 0)
                {
                    return sum++;
                }
            }

            return sum;
        }

        [MarkedItem]
        public void DivisorSquareSum()
        {
            //Problem 211
            //For a positive integer n, let σ2(n) be the sum of the squares of its divisors. For example,
            //σ2(10) = 1 + 4 + 25 + 100 = 130.
            //Find the sum of all n, 0 < n < 64,000,000 such that σ2(n) is a perfect square.
            var obj = new object();
            var sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(Enumerable.Range(1, 64000), number =>
            {
                lock (obj)
                {
                    var factors = GetFactor(number);
                    var sum = GetSequenceSquareSum(factors);
                    if (CheckPerfectSquare(sum))
                        Console.WriteLine(number);
                }
            });

            sw.Stop();
            Console.WriteLine("SpentTime:{0}ms", sw.ElapsedMilliseconds);
        }

        /// <summary>
        ///     判斷是否為完全平方數
        /// </summary>
        /// <param name="numbers">需判斷數字</param>
        /// <returns></returns>
        private bool CheckPerfectSquare(double number)
        {
            return (Math.Sqrt(number)%1) == 0;
        }

        /// <summary>
        ///     取得全部數值的平方加總
        /// </summary>
        /// <param name="numbers">需平方加總數列</param>
        /// <returns>平方加總</returns>
        private double GetSequenceSquareSum(List<int> numbers)
        {
            var obj = new object();
            double sum = 0;

            Parallel.ForEach(numbers, number =>
            {
                lock (obj)
                {
                    sum += Math.Pow(number, 2);
                }
            });

            return sum;
        }

        /// <summary>
        ///     取得因子
        /// </summary>
        /// <param name="number">需取得因子數字</param>
        /// <returns>全部因子</returns>
        private List<int> GetFactor(int number)
        {
            var factors = new List<int>();
            foreach (var factor in Enumerable.Range(1, (int) Math.Floor(Math.Sqrt(number))).Where(x => number%x == 0))
            {
                factors.Add(factor);
                if (!factors.Contains(number/factor))
                    factors.Add(number/factor);
            }

            return factors;
        }

        [MarkedItem]
        public void GcdSequence()
        {
            //Problem 443
            //Let g(n) be a sequence defined as follows:
            //g(4) = 13,
            //g(n) = g(n-1) + gcd(n, g(n-1)) for n > 4.
            //The first few values are:
            //          n	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	...
            //        g(n)	13	14	16	17	18	27	28	29	30	31	32	33	34	51	54	55	60	...
            //        You are given that g(1 000) = 2524 and g(1 000 000) = 2624152.
            //Find g(1015).

            var g = new Dictionary<int, int>();
            g.Add(4, 13);

            foreach (var number in Enumerable.Range(5, 10000))
            {
                var currentResult = g[number - 1] + GetGcd(number, g[number - 1]);
                g.Add(number, currentResult);

                Console.WriteLine("index:{0} number:{1}", number, currentResult);
            }
        }

        /// <summary>
        ///     取得最大公因數
        /// </summary>
        /// <param name="number1">需判斷數字1</param>
        /// <param name="number2">需判斷數字2</param>
        /// <returns>最大公因數</returns>
        private int GetGcd(int number1, int number2)
        {
            var factors1 = GetFactor(number1);
            var factors2 = GetFactor(number2);

            return factors1.Intersect(factors2).Max();
        }

        [MarkedItem]
        public void CountingNumbersWithatLeastFourDistinctPrimeFactorsLessThan100()
        {
            //It can be verified that there are 23 positive integers less than 1000 that are divisible by at least four distinct primes less than 100.
            //Find how many positive integers less than 1016 are divisible by at least four distinct primes less than 100.
            var primes = GetPrimesWithinRange(100);
            var sum =
                Enumerable.Range(1, 1000)
                    .Select(number => primes.Count(prime => number%prime == 0))
                    .Count(matchPrime => matchPrime >= 4);

            Console.WriteLine(sum);
        }

        /// <summary>
        ///     取得2~Range之間的prime
        /// </summary>
        /// <param name="range">範圍</param>
        /// <returns>Primes within 2 and range</returns>
        private IEnumerable<int> GetPrimesWithinRange(int range)
        {
            return Enumerable.Range(2, range - 1).Where(x => GetFactor(x).Count == 2);
        }

        [MarkedItem]
        public void HowManyReversibleNumbersAreThereBelowOneBillion()
        {
            var sum = 0;
            foreach (var number in Enumerable.Range(1, 900))
            {
                if (number%10 == 0)
                    continue;

                var reverseNumber = GetReverseNumber(number);
                if (IsReverseNumber(reverseNumber))
                    sum++;
            }

            Console.WriteLine(sum);
        }

        private bool IsReverseNumber(int number)
        {
            return number == GetReverseNumber(number);
        }

        private int GetReverseNumber(int number)
        {
            return int.Parse(Reverse(number.ToString()));
        }

        private string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        [MarkedItem]
        public void CountingFractions72()
        {
            //Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.
            //If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:
            //1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8
            //It can be seen that there are 21 elements in this set.
            //How many elements would be contained in the set of reduced proper fractions for d ≤ 1,000,000?
            var max = 100;
            var sum = 0;
            var obj = new object();

            var sw = new Stopwatch();
            sw.Start();
            var primes = GetPrimesWithinRange(max);
            Parallel.ForEach(Enumerable.Range(1, max), fractionM =>
            {
                Parallel.ForEach(Enumerable.Range(1, fractionM - 1), fractionC =>
                {
                    lock (obj)
                    {
                        if (
                            primes.Where(prime => prime <= fractionC)
                                .Any(prime => fractionM%prime == 0 && fractionC%prime == 0))
                            sum++;
                    }
                });
            });

            sw.Stop();
            Console.WriteLine("{0}:{1}", sum, sw.ElapsedMilliseconds);
        }

        [MarkedItem]
        public void ConsecutivePrimeSum50()
        {
            //The prime 41, can be written as the sum of six consecutive primes:
            //41 = 2 + 3 + 5 + 7 + 11 + 13
            //This is the longest sum of consecutive primes that adds to a prime below one-hundred.
            //The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
            //Which prime, below one-million, can be written as the sum of the most consecutive primes?
            var max = 1000;
            var count = 0;
            var sum = 0;
            var primes = GetPrimesWithinRange(max).ToList();
            foreach (var prime in primes)
            {
                if (sum + prime < max && primes.Contains(sum + prime))
                {
                    Console.WriteLine(sum);
                    break;
                }

                count++;
                sum += prime;
            }
        }

        [MarkedItem]
        public void PrimePermutations49()
        {
            //The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
            //There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
            //What 12-digit number do you form by concatenating the three terms in this sequence?
            var digit = 4;
            foreach (
                var number in
                    Enumerable.Range((int) Math.Pow(10, digit - 1),
                        (int) (Math.Pow(10, digit) - Math.Pow(10, digit - 1))))
            {
                foreach (var step in Enumerable.Range(0, (int) (Math.Pow(10, digit) - number)/3))
                {
                    var term1 = number + step;
                    var term2 = number + step*2;
                    var term3 = number + step*3;
                    if (term1 == 1487 && IsPrime(term1) && IsPrime(term2) && IsPrime(term3))
                        Console.WriteLine("{0}:{1}:{2}", term1, term2, term3);
                }
            }

            Console.WriteLine(IsPrime(53));
        }

        private bool IsPrime(int number)
        {
            if (number < 1)
                return false;

            if (number == 2)
                return true;

            return GetPrimesWithinRange(number).Contains(number);
        }

        [MarkedItem]
        public void FindMinimumInRotatedSortedArray()
        {
            //Suppose a sorted array is rotated at some pivot unknown to you beforehand.
            //(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
            //Find the minimum element.
            //You may assume no duplicate exists in the array.
            var max = new List<int>();
            var sortArray = new List<int> {0, 1, 2, 4, 5, 6, 7};

            for (var i = 0; i < sortArray.Count; i++)
            {
                if (sortArray[0] != 0)
                {
                    max.Add(IntArrayToInt(sortArray));
                }

                sortArray.Add(sortArray[0]);
                sortArray.Remove(sortArray[0]);
            }

            Console.WriteLine(max.Min());
        }

        private int IntArrayToInt(List<int> sortArray)
        {
            return
                sortArray.Select((t, i) => sortArray.Count - i - 1)
                    .Select((term, i) => sortArray[term]*(int) Math.Pow(10, i))
                    .Sum();
        }

        [MarkedItem]
        public void GivenAnInputStringReverseTheStringWordByWord()
        {
            //https://oj.leetcode.com/problems/reverse-words-in-a-string/
            //Given an input string, reverse the string word by word.
            //For example,
            //Given s = "the sky is blue",
            //return "blue is sky the".
            var needReverse = "the sky is blue";
            var reverse = string.Join(" ", needReverse.Split(null).Reverse());
            Console.WriteLine(reverse);
        }

        [MarkedItem]
        public void FindTheContiguousSubarrayWithinAnArray()
        {
            //https://oj.leetcode.com/problems/maximum-product-subarray/
            //Find the contiguous subarray within an array (containing at least one number) which has the largest product.
            //For example, given the array [2,3,-2,4],
            //the contiguous subarray [2,3] has the largest product = 6.
            var list = new List<int> {2, 3, -2, 4, 10, -3, 5, -1};
            var subList = new List<int>();
            var max = 0;
            for (var x = 0; x <= list.Count; x++)
            {
                for (var y = 1; x + y <= list.Count; y++)
                {
                    var sub = list.Skip(x).Take(y);
                    var subSumValue = sub.Aggregate((a, b) => a*b);
                    if (subSumValue > max)
                    {
                        max = subSumValue;
                        subList = sub.ToList();
                    }
                }
            }

            var sb = new StringBuilder();
            subList.ForEach(n => sb.Append("[" + n + "]"));
            sb.Append("=" + max);

            Console.WriteLine(sb.ToString());
        }

        [MarkedItem]
        public void EvaluateReversePolishNotation()
        {
            //https://oj.leetcode.com/problems/evaluate-reverse-polish-notation/
            //Evaluate the value of an arithmetic expression in Reverse Polish Notation.
            //Valid operators are +, -, *, /. Each operand may be an integer or another expression.
            //Some examples:
            //["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
            //["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
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

        [MarkedItem]
        public void Candy()
        {
            //https://oj.leetcode.com/problems/candy/
            //There are N children standing in a line. Each child is assigned a rating value.
            //You are giving candies to these children subjected to the following requirements:
            //Each child must have at least one candy.
            //Children with a higher rating get more candies than their neighbors.
            //What is the minimum candies you must give?
            var childredRates = new List<int> {2, 10, 1, 9, 100, 8, 7, 6};
            var candies = Enumerable.Repeat(0, 8).ToList();
            while (Enumerable.Range(0, childredRates.Count()).Any(n =>
            {
                var state = false;
                while (candies[n] == 0 || CompareWithNeighbors(childredRates, candies, n))
                {
                    state = true;
                    candies[n]++;
                }

                return state;
            }))

                Console.WriteLine(candies.Aggregate((a, b) => a + b));
        }

        private bool CompareWithNeighbors(List<int> childredRates, List<int> candies, int position)
        {
            if (position == 0)
                return
                    (CheckNeedAdd(childredRates[position], candies[position], childredRates[position + 1],
                        candies[position + 1]) ||
                     CheckNeedAdd(childredRates[position], candies[position], childredRates[childredRates.Count - 1],
                         candies[childredRates.Count - 1]));

            if (position >= childredRates.Count - 1)
                return
                    CheckNeedAdd(childredRates[position], candies[position], childredRates[position - 1],
                        candies[position - 1]) ||
                    CheckNeedAdd(childredRates[position], candies[position], childredRates[0], candies[0]);

            return
                CheckNeedAdd(childredRates[position], candies[position], childredRates[position - 1],
                    candies[position - 1]) ||
                CheckNeedAdd(childredRates[position], candies[position], childredRates[position + 1],
                    candies[position + 1]);
        }

        private bool CheckNeedAdd(int childredRate1, int candy1, int childredRate2, int candy2)
        {
            return (childredRate1 > childredRate2 && candy1 <= candy2) ? true : false;
        }

        [MarkedItem]
        public void WordLadder()
        {
            //https://oj.leetcode.com/problems/word-ladder/
            //Given two words (start and end), and a dictionary, find the length of shortest transformation sequence from start to end, such that:
            //Only one letter can be changed at a time
            //Each intermediate word must exist in the dictionary
            //For example,
            //Given:
            //start = "hit"
            //end = "cog"
            //dict = ["hot","dot","dog","lot","log"]
            //As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
            //return its length 5.
            //Note:
            //Return 0 if there is no such transformation sequence.
            //All words have the same length.
            //All words contain only lowercase alphabetic characters.

            var start = "hit";
            var end = "cog";
            var dict = new List<string> {"hot", "dot", "dog", "lot", "log"};
            var path = new Stack<string>();

            Translate(start, end, dict, path).ToList().ForEach(n => Console.WriteLine(n));
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

        [MarkedItem]
        public void WildcardMatching()
        {
            //https://oj.leetcode.com/problems/wildcard-matching/
            //'?' Matches any single character.
            //'*' Matches any sequence of characters (including the empty sequence).
            //The matching should cover the entire input string (not partial).
            //The function prototype should be:
            //bool isMatch(const char *s, const char *p)
            //Some examples:
            //isMatch("aa","a") → false
            //isMatch("aa","aa") → true
            //isMatch("aaa","aa") → false
            //isMatch("aa", "*") → true
            //isMatch("aa", "a*") → true
            //isMatch("ab", "?*") → true
            //isMatch("aab", "c*a*b") → false
            Console.WriteLine(IsMatch("aa", "a"));
            Console.WriteLine(IsMatch("aa", "aa"));
            Console.WriteLine(IsMatch("aaa", "aa"));
            Console.WriteLine(IsMatch("aa", "*"));
            Console.WriteLine(IsMatch("aa", "a*"));
            Console.WriteLine(IsMatch("ab", "?*"));
            Console.WriteLine(IsMatch("aab", "c*a*b"));
        }

        private bool IsMatch(string checkString, string validateString)
        {
            if (!validateString.Contains("*") && !validateString.Contains("?"))
                return checkString.Equals(validateString);

            var postion = 0;
            var bondary = checkString.Length - 1;
            foreach (var c in validateString.TakeWhile(c => postion <= bondary).Where(c => !c.Equals('*')))
            {
                if (c.Equals('?'))
                {
                    postion++;
                    continue;
                }

                if (checkString[postion].Equals(c))
                {
                    postion++;
                    continue;
                }

                while (postion <= bondary && !checkString[postion].Equals(c)) postion++;
            }

            return postion <= bondary;
        }

        [MarkedItem]
        public void JumpGame()
        {
            //https://oj.leetcode.com/problems/jump-game/
            //Given an array of non-negative integers, you are initially positioned at the first index of the array.
            //Each element in the array represents your maximum jump length at that position.
            //Determine if you are able to reach the last index.
            //For example:
            //A = [2,3,1,1,4], return true.
            //A = [3,2,1,0,4], return false.
            var testA = new List<int> {2, 3, 1, 1, 4};
            var testB = new List<int> {3, 2, 1, 0, 4};
            Console.WriteLine(CheckJumpGame(testA));
            Console.WriteLine(CheckJumpGame(testB));
        }

        private bool CheckJumpGame(List<int> array)
        {
            var position = 0;
            var lastIndex = array.Count() - 1;
            while (position < lastIndex)
            {
                if (array[position] == 0)
                    break;

                position += array[position];
            }

            return (position == lastIndex);
        }

        [MarkedItem]
        public void JumpGameIi()
        {
            //https://oj.leetcode.com/problems/jump-game-ii/
            //Given an array of non-negative integers, you are initially positioned at the first index of the array.
            //Each element in the array represents your maximum jump length at that position.
            //Your goal is to reach the last index in the minimum number of jumps.
            //For example:
            //Given array A = [2,3,1,1,4]
            //The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)
            var testA = new List<int> {2, 3, 1, 1, 4};
            Console.WriteLine(CheckJumpGameMinStep(testA));
        }

        private int CheckJumpGameMinStep(List<int> array, int position = 0, int step = 0)
        {
            var lastIndex = array.Count() - 1;
            if (array[position] == 0 || position > lastIndex)
                return default(int);

            return position == lastIndex
                ? step
                : Enumerable.Range(1, array[position]).Min(n => CheckJumpGameMinStep(array, position + n, step + 1));
        }

        [MarkedItem]
        public void MaxPointsOnALine()
        {
            //https://oj.leetcode.com/problems/jump-game-ii/
            //Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
            var random = new Random();
            var points =
                Enumerable.Range(1, 20)
                    .Select(n => new {X = random.Next(1, 100), Y = random.Next(1, 100)})
                    .ToList<dynamic>();
            CaculateMaxPointOnALine(points);
            Console.WriteLine(CaculateMaxPointOnALine(points));
        }

        private int CaculateMaxPointOnALine(List<dynamic> points)
        {
            return points.Max(pointA =>
            {
                return points
                    .GroupBy(pointB => CaculateSlope(pointA, pointB))
                    .Max(g => g.Count());
            });
        }

        private double CaculateSlope(dynamic point1, dynamic point2)
        {
            if (point1.Y == point2.Y && point1.X == point2.X)
                return 100;

            if (point1.Y == point2.Y)
                return 0;

            if (point1.X == point2.X)
                return 1;

            return (double) ((point1.X - point2.X)/(point1.Y - point2.Y));
        }

        [MarkedItem]
        public void SingleNumberIi()
        {
            //https://oj.leetcode.com/problems/single-number-ii/
            //Given an array of integers, every element appears three times except for one. Find that single one.
            //Note:
            //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
            var testArray = new List<int> {3, 1, 4, 1, 4, 2, 4, 1, 5, 2, 2, 3, 3};
            var ones = 0;
            var twos = 0;
            for (var i = 0; i < testArray.Count(); i++)
            {
                ones = (ones ^ testArray[i]) & ~twos; //1100 1101
                twos = (twos ^ testArray[i]) & ~ones; //0000 0010
            }

            Console.WriteLine(ones);
        }

        [MarkedItem]
        public void RotateList()
        {
            //https://oj.leetcode.com/problems/rotate-list/
            //Given a list, rotate the list to the right by k places, where k is non-negative.
            //For example:
            //Given 1->2->3->4->5->NULL and k = 2,
            //return 4->5->1->2->3->NULL.

            var rotateList = new List<int> {1, 2, 3, 4, 5};
            var k = 2;
            Rotate(ref rotateList, 2);
        }

        private void Rotate(ref List<int> list, int k)
        {
            foreach (var n in Enumerable.Range(0, k))
            {
                list.Insert(0, list.Last());
                list.RemoveAt(list.Count - 1);
            }
        }

        [MarkedItem]
        public void AddTwoNumbers()
        {
            //https://oj.leetcode.com/problems/add-two-numbers/
            //You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
            //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
            //Output: 7 -> 0 -> 8

            var n1 = new List<int> {2, 4, 6};
            var n2 = new List<int> {5, 6, 4};
            var count = new List<int>();
            var maxLength = Math.Max(n1.Count, n2.Count);
            var temp = 0;
            foreach (var index in Enumerable.Range(0, maxLength))
            {
                var x = 0;
                var y = 0;
                if (index <= n1.Count - 1)
                    x = n1[index];

                if (index <= n2.Count - 1)
                    y = n2[index];

                count.Add((x + y)%10 + temp);
                temp = (x + y)/10;
            }

            count.Add(temp);
        }

        [MarkedItem]
        public void AddTwoNumbersⅡ()
        {
            var list1 = new ListNode(2).Next(new ListNode(4)).Next(new ListNode(3));
            var list2 = new ListNode(5).Next(new ListNode(6)).Next(new ListNode(4));
        }

        public ListNode AddTwoNumbersⅡ(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return null;

            var tmpNum = l1.val + l2.val;
            var head = new ListNode(tmpNum%10);
            var tmp = head;
            while (l1.next != null && l2.next != null)
            {
                tmpNum = l1.val + l2.val + (tmpNum/10);
                tmp.next = new ListNode(tmpNum%10);
                tmp = tmp.next;

                l1 = l1.next;
                l2 = l2.next;
            }

            if (tmpNum/10 != 0)
                tmp.next = new ListNode(tmpNum/10);

            return head;
        }

        public class ListNode
        {
            public ListNode next;
            public int val;

            public ListNode(int x)
            {
                val = x;
            }

            public ListNode Next(ListNode next)
            {
                this.next = next;
                return next;
            }
        }

        [MarkedItem]
        public void InsertInterval()
        {
            //https://oj.leetcode.com/problems/insert-interval/
            //Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
            //You may assume that the intervals were initially sorted according to their start times.
            //Example 1:
            //Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].
            //Example 2:
            //Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].
            //This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

            var intSet = new List<List<int>>
            {
                new List<int> {1, 2},
                new List<int> {3, 5},
                new List<int> {6, 7},
                new List<int> {8, 10},
                new List<int> {12, 16}
            };
            var newInterval = new List<int> {1, 100};

            Insert(intSet, newInterval).ForEach(set => Console.WriteLine("[{0},{1}]", set[0], set[1]));
        }

        private List<List<int>> Insert(List<List<int>> intSet, List<int> interval)
        {
            intSet.Add(interval);
            var list = intSet.Where(set => !(interval[0] < set[0] && interval[1] > set[1]));
            var start = list.Where(set => interval[0] <= set[1] && interval[1] >= set[1]).Min(set => set[0]);
            var end = list.Where(set => interval[1] >= set[0] && interval[0] <= set[0]).Max(set => set[1]);
            var newInterval = new List<int> {start, end};
            var need = list.Where(set => set[1] <= interval[0] || set[0] >= interval[1]).ToList();

            need.Add(newInterval);

            return need;
        }

        [MarkedItem]
        public void FlattenBinaryTreetoLinkedList()
        {
            //https://oj.leetcode.com/problems/flatten-binary-tree-to-linked-list/
            //Given a binary tree, flatten it to a linked list in-place.
            TreeToList(GetRootOfTree()).ForEach(n => Console.WriteLine(n));
        }

        private Node GetRootOfTree()
        {
            var root = new Node {Key = 1};
            var node2 = new Node {Key = 2};
            var node3 = new Node {Key = 3};
            var node4 = new Node {Key = 4};
            var node5 = new Node {Key = 5};
            var node6 = new Node {Key = 6};
            root.Left = node2;
            root.Right = node5;
            node2.Right = node4;
            node2.Left = node3;
            node5.Right = node6;

            return root;
        }

        private List<int> TreeToList(Node head)
        {
            var newList = new List<int> {head.Key};

            if (head.Left != null)
                newList.AddRange(TreeToList(head.Left));

            if (head.Right != null)
                newList.AddRange(TreeToList(head.Right));

            return newList;
        }

        private class Node
        {
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Key { get; set; }
        }

        [MarkedItem]
        public void MinimumDepthOfBinaryTree()
        {
            //https://oj.leetcode.com/problems/minimum-depth-of-binary-tree/
            //Given a binary tree, find its minimum depth.
            //The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
            Console.WriteLine(GetMinimumDepthOfBinaryTree(GetRootOfTree()));
        }

        private int GetMinimumDepthOfBinaryTree(Node head)
        {
            int leftDepth = 0, rightDepth = 0;

            if (head.Left != null)
                leftDepth = GetMinimumDepthOfBinaryTree(head.Left);

            if (head.Right != null)
                rightDepth = GetMinimumDepthOfBinaryTree(head.Right);

            if ((leftDepth == 0 && rightDepth != 0) || (rightDepth == 0 && leftDepth != 0))
                return 1 + Math.Max(leftDepth, rightDepth);

            return 1 + Math.Min(leftDepth, rightDepth);
        }

        [MarkedItem]
        public void ValidNumber()
        {
            //https://oj.leetcode.com/problems/valid-number/
            //Validate if a given string is numeric.
            //Some examples:
            //"0" => true
            //" 0.1 " => true
            //"abc" => false
            //"1 a" => false
            //"2e10" => true
            //Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one.
            IsNumberic("0");
            IsNumberic("0.1");
            IsNumberic("abc");
            IsNumberic("1 a");
            IsNumberic("2e");
        }

        private void IsNumberic(string validationString)
        {
            var integerRegex1 = @"^[0]$";
            var integerRegex = @"^[-]??[1-9]{1}[0-9]+$";
            var floatRegex = @"^[-]??[0-9]+[.]{1}[0-9]+$";
            var floatRegex1 = @"^[-]??[0-9]{1}[.]{1}[0-9]+$";
            var scientificNotation = @"^[-]??[1-9]{1}[0-9]{0,}[e]{1}$";

            var regexList = new List<string>
            {
                integerRegex,
                integerRegex1,
                floatRegex,
                floatRegex1,
                scientificNotation
            };

            var state = regexList
                .Any(regex => new Regex(regex).IsMatch(validationString));

            Console.WriteLine("{0}:{1}", validationString, state);
        }

        [MarkedItem]
        public void TrappingRainWater()
        {
            //https://oj.leetcode.com/problems/trapping-rain-water/
            //Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
            //For example, 
            //Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
            var elements = new List<int> {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
            var sum = 0;
            var intervals = new List<List<int>>();
            for (var i = 0; i < elements.Count; i++)
            {
                for (var j = i + 1; j < elements.Count; j++)
                {
                    if (elements[j] < elements[i])
                        continue;

                    if (!(intervals.Any(interval => interval[0] <= i
                                                    && interval[1] >= j))
                        && j - i > 1)
                    {
                        intervals.Add(new List<int> {i, j});
                        var min = Math.Min(elements[i], elements[j]);
                        sum += Enumerable.Range(i + 1, j - i - 1).Sum(index => min - elements[index]);
                    }

                    break;
                }
            }

            Console.WriteLine(sum);
            intervals.ForEach(n => Console.WriteLine("[{0},{1}]", n[0], n[1]));
        }

        [MarkedItem]
        public void MinimumWindowSubstring()
        {
            //https://oj.leetcode.com/problems/minimum-window-substring/ 
            //Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
            //For example,
            //S = "ADOBECODEBANC"
            //T = "ABC"
            //Minimum window is "BANC".
            //Note:
            //If there is no such window in S that covers all characters in T, return the emtpy string "".
            //If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.

            var s = "ADOBECODEBANC";
            var t = "ABC";
        }

        private string FindMinimumWindow(string s, string t)
        {
            var a = new List<int>();
            for (var i = 0; i < s.Length; i++)
            {
                if (t.Contains(s[i].ToString()))
                    a.Add(i);
            }

            return null;
        }

        [MarkedItem]
        public void Triangle()
        {
            //https://oj.leetcode.com/problems/triangle/
            //Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
            //For example, given the following triangle
            //[
            //     [2],
            //    [3,4],
            //   [6,5,7],
            //  [4,1,8,3]
            //]
            //The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
            //Note:
            //Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.

            var triangle = new List<List<int>>
            {
                new List<int> {2},
                new List<int> {3, 4},
                new List<int> {6, 5, 7},
                new List<int> {4, 1, 8, 3}
            };
            var level = 0;
            var index = 0;

            Console.WriteLine(GetMinValueByTrianglePath(triangle, level, index).Min(n => n.Sum(x => x)));
        }

        private List<List<int>> GetMinValueByTrianglePath(List<List<int>> triangle, int level, int index)
        {
            if (level + 1 >= triangle.Count)
                return new List<List<int>> {new List<int> {triangle[level][index]}};

            var leftValue = GetMinValueByTrianglePath(triangle, level + 1, index);
            var righttValue = GetMinValueByTrianglePath(triangle, level + 1, index + 1);

            leftValue.AddRange(righttValue);
            leftValue.ForEach(n => n.Add(triangle[level][index]));

            return leftValue;
        }

        [MarkedItem]
        public void TwoSum()
        {
            //https://oj.leetcode.com/problems/two-sum/
            //Given an array of integers, find two numbers such that they add up to a specific target number.
            //The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.
            //You may assume that each input would have exactly one solution.
            //Input: numbers={2, 7, 11, 15}, target=9
            //Output: index1=1, index2=2

            var input = new List<int> {2, 7, 2, 11, 15};
            var target = 9;

            FindMatchTargetIndex(input, target).DumpMany();
        }

        private IEnumerable<List<int>> FindMatchTargetIndex(List<int> numberList, int target)
        {
            var sets = new List<List<int>>();
            var index = 0;
            var range = 0;
            while (index + range < numberList.Count)
            {
                target -= numberList[index + range];
                if (target == 0)
                    sets.Add(new List<int> {index, index + range});

                if (target > 0)
                    range++;
                else
                    target += numberList[index++];
            }

            return sets;
        }

        [MarkedItem]
        public void LongestSubstringWithoutRepeatingCharacters()
        {
            //https://oj.leetcode.com/problems/longest-substring-without-repeating-characters/
            //Given a string, find the length of the longest substring without repeating characters. For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
            //which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
            var test = "aaaaaaaaaaaaaaaaaaefc";

            Console.WriteLine(GetLengthWithoutRepeat(test));
        }

        private int GetLengthWithoutRepeat(string checkString)
        {
            var stringMax = checkString.Distinct().Count();
            var noRepeatLength = 3;
            var index = 0;
            if (stringMax <= 3) return stringMax;
            while (index < checkString.Length)
            {
                var stringInternal = noRepeatLength + 1;
                if (index + stringInternal > checkString.Length)
                    break;

                if (stringInternal != checkString.Substring(index, stringInternal).Distinct().Count())
                {
                    index++;
                    continue;
                }

                if (stringInternal > noRepeatLength)
                    noRepeatLength = stringInternal;
                else
                    index++;

                if (noRepeatLength == stringMax)
                    break;
            }

            return noRepeatLength;
        }

        [MarkedItem]
        public void BestTimetoBuyandSellStock()
        {
            //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock/
            //Say you have an array for which the ith element is the price of a given stock on day i.
            //If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
            var price = new List<int> {2, 1};

            Console.WriteLine(GetBestTimeToBuyAndSell(price));
        }

        private int GetBestTimeToBuyAndSell(List<int> prices)
        {
            if (prices == null
                || !prices.Any()
                || prices.Any(p => p < 0))
                return 0;

            var min = new List<int> {0};
            var maxBenifit = 0;
            for (var index = 1; index < prices.Count(); index++)
            {
                if (prices[index] > prices[index - 1])
                {
                    maxBenifit = Math.Max(maxBenifit, min.Max(n => prices[index] - prices[n]));
                    continue;
                }

                if (prices[index] < prices[index - 1])
                {
                    min.Add(index);
                }
            }

            return maxBenifit;
        }

        [MarkedItem]
        public void BestTimetoBuyandSellStockIi()
        {
            //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
            //Say you have an array for which the ith element is the price of a given stock on day i.
            //Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
            //(ie, buy one and sell one share of the stock multiple times). However, 
            //you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
            var prices = new List<int> {10, 5, 8, 1, 5, 3, 9, 4, 2, 6, 7};
            var totalProfit = 0;
            for (var i = 0; i < prices.Count() - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                    totalProfit += prices[i + 1] - prices[i];
            }

            Console.WriteLine(totalProfit);
        }

        [MarkedItem]
        public void BestTimetoBuyandSellStockIii()
        {
            //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
            //Say you have an array for which the ith element is the price of a given stock on day i.
            //Design an algorithm to find the maximum profit. You may complete at most two transactions.
            //Note:
            //You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
            var prices = new List<int> {10, 5, 8, 1, 5, 3, 9, 4, 2, 6, 5};
            var set = new List<List<int>>();
            var p = 0;
            for (var i = 0; i < prices.Count() - 1; i++)
            {
                if (prices[i + 1] < prices[i])
                {
                    if (i != p)
                        set.Add(new List<int> {p, i});

                    p = i + 1;
                }

                if (i != prices.Count() - 2)
                    continue;

                if (i != p)
                    set.Add(new List<int> {p, i + 1});
            }

            var maxProfitOfTwoTransaction =
                set.Select(n => prices[n[1]] - prices[n[0]])
                    .OrderByDescending(n => n)
                    .Take(2)
                    .Sum();

            Console.WriteLine(maxProfitOfTwoTransaction);
        }

        [MarkedItem]
        public void UniquePaths()
        {
            //https://oj.leetcode.com/problems/unique-paths/
            //A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
            //The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below)
            //How many possible unique paths are there?
            //Above is a 3 x 7 grid. How many possible unique paths are there?
            //Note: m and n will be at most 100.
            var arrayX = 10;
            var arrayY = 9;
            var allStep = arrayX + arrayY - 2;
            var goDown = arrayX - 1;
            double res = 1;
            for (var step = 1; step <= goDown; step++)
            {
                var goRight = allStep - goDown;
                res = res*(goRight + step)/step;
            }

            Console.WriteLine(res);
        }

        [MarkedItem]
        public void Anagrams()
        {
            //https://oj.leetcode.com/problems/anagrams/
            //Given an array of strings, return all groups of strings that are anagrams.
            //Note: All inputs will be in lower-case.
            var strs = new List<string> {"dog", "god", "cab", "bac", "zdz", "aac"};
            strs.Where(n =>
            {
                return strs.Any(m =>
                {
                    if (n == m)
                        return false;

                    return string.Concat(n.ToCharArray().OrderBy(x => x)) ==
                           string.Concat(m.ToCharArray().OrderBy(x => x));
                });
            });
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/sort-colors/")]
        public void SortColors()
        {
            //Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.
            //Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
            //Note:
            //You are not suppose to use the library's sort function for this problem.
            //Follow up:
            //A rather straight forward solution is a two-pass algorithm using counting sort.
            //First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
            //Could you come up with an one-pass algorithm using only constant space?

            var colors = new List<int> {1, 100, 2, 1, 1, 4, 1, 4, 1, 5, 1, 2};
            var postion = 0;
            while (postion < colors.Count - 1)
            {
                if (postion < 0)
                    postion = 0;

                if (colors[postion + 1] < colors[postion])
                {
                    Swap(ref colors, postion, postion + 1);
                    postion--;
                    continue;
                }

                postion++;
            }

            colors.Dump();
        }

        private void Swap(ref List<int> items, int index1, int index2)
        {
            var temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/sort-colors/")]
        public void SortColorsIi()
        {
            //Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.
            //Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
            //Note:
            //You are not suppose to use the library's sort function for this problem.
            //Follow up:
            //A rather straight forward solution is a two-pass algorithm using counting sort.
            //First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
            //Could you come up with an one-pass algorithm using only constant space?

            var colors = new List<int> {1, 1, 2, 1, 0, 1, 2, 1, 0, 1, 1, 2};
            int blue = -1, white = -1, red = -1;
            for (var i = 0; i < colors.Count; i++)
            {
                switch (colors[i])
                {
                    case 0:
                        colors[++blue] = 0;
                        colors[++white] = 1;
                        colors[++red] = 2;
                        break;
                    case 1:
                        colors[++white] = 1;
                        colors[++red] = 2;
                        break;
                    default:
                        colors[++red] = 2;
                        break;
                }
            }

            colors.Dump();
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public void LongestCommonPrefix()
        {
            //Write a function to find the longest common prefix string amongst an array of strings.

            var items = new string[] {};

            LongestCommonPrefix(items).ToConsole();
        }

        public string LongestCommonPrefix(string[] items)
        {
            if (items == null || items.Length <= 0)
                return string.Empty;

            var last = items[0].Length;
            for (var i = 1; i < items.Length; i++)
            {
                if (last == 0)
                    return string.Empty;

                last = Math.Min(last, items[i].Length);
                while (last > 0 && items[i].Substring(0, last) != items[0].Substring(0, last))
                    last--;
            }

            return items[0].Substring(0, last);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public void PalindromeNumber()
        {
            //Determine whether an integer is a palindrome. Do this without extra space.

            var i = 77801120877;

            Console.WriteLine("{0}:IsPalindromeNumber:{1}", i, IsPalindromeNumber(i));
        }

        private bool IsPalindromeNumber(long i)
        {
            var s = i.ToString();
            for (var j = 0; j < s.Length/2; j++)
            {
                if (s[j] != s[s.Length - 1 - j])
                    return false;
            }

            return true;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public void PalindromeNumberIi()
        {
            //Determine whether an integer is a palindrome. Do this without extra space.
            var i = 7780110877;

            Console.WriteLine("{0}:IsPalindromeNumber:{1}", i, IsPalindromeNumberIi(i));
        }

        private bool IsPalindromeNumberIi(long i)
        {
            for (var j = 0; j < (int) (Math.Log10(i) + 1)/2; j++)
            {
                var one = (int) (i/Math.Pow(10, j)%10);
                var two = (int) (i/Math.Pow(10, (int) (Math.Log10(i) - j)%10));
                if (one != two)
                    return false;
            }

            return true;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public void LengthofLastWord()
        {
            //Determine whether an integer is a palindrome. Do this without extra space.
            //Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
            //If the last word does not exist, return 0.
            //Note: A word is defined as a character sequence consists of non-space characters only.
            //For example, 
            //Given s = "Hello World",
            //return 5.
            Console.WriteLine(GetLastWordLength("Hello World"));
        }

        private int GetLastWordLength(string s)
        {
            var postion = s.Length - 1;
            while (postion >= 0 && s[postion] != ' ')
                postion--;

            return s.Length - 1 - postion;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/3sum-closest/")]
        public void Sum3Closest()
        {
            //Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
            //For example, given array S = {-1 2 1 -4}, and target = 1.
            //The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

            var set = new[] {1, 2, 5, 7, -4, -4, 10, 9, 7};

            Console.WriteLine(GetCloseSet(set, -10));
        }

        private int GetCloseSet(int[] nums, int target)
        {
            var x = 0;
            var y = 1;
            var z = 2;
            var min = nums.Max();
            var count = nums.Count();
            while (!(x == count - 3 && y == count - 2 && z == count - 1))
            {
                var close = Math.Abs(target - (nums[x] + nums[y] + nums[z]));
                min = Math.Min(min, close);
                if (y == count - 2 && z == count - 1)
                {
                    y = ++x + 1;
                    z = x + 2;
                }
                else if (z == count - 1)
                {
                    z = ++y + 1;
                }
                else
                {
                    ++z;
                }
            }

            return min;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/largest-rectangle-in-histogram/")]
        public void LargestRectangleinHistogram()
        {
            //Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
            //The largest rectangle is shown in the shaded area, which has area = 10 unit.
            //For example,
            //Given height = [2,1,5,6,2,3],
            //return 10.
            var set = new List<int> {2, 1, 5, 6, 2, 3};
            var max = 0;
            for (var x = 0; x < set.Count() - 1; x++)
            {
                for (var y = x; y < set.Count(); y++)
                {
                    var area = Math.Min(set[x], set[y])*(y - x);
                    max = Math.Max(max, area);
                }
            }

            Console.WriteLine(max);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/restore-ip-addresses/")]
        public void RestoreIPAddresses()
        {
            //Given a string containing only digits, restore it by returning all possible valid IP address combinations.
            //For example:
            //Given "25525511135",
            //return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)
            RestoreIPAddresses("25525511135").Dump();
        }

        private List<string> RestoreIPAddresses(string ip)
        {
            var ipSet = (from x in Enumerable.Range(1, 3)
                from y in Enumerable.Range(1, 3)
                from z in Enumerable.Range(1, 3)
                select
                    new List<string>
                    {
                        ip.Substring(0, x),
                        ip.Substring(x, y),
                        ip.Substring(x + y + 1, z),
                        ip.Substring(x + y + z + 2)
                    }).ToList();

            return ipSet.Where(n => n.All(check)).Select(n => string.Join(".", n)).ToList();
        }

        private bool check(string ipNumber)
        {
            if (ipNumber.Length <= 0 || ipNumber.Length > 3)
                return false;

            var n = Convert.ToInt32(ipNumber);

            return n > 0 && n <= 255;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/first-missing-positive/")]
        public void FirstMissingPositive()
        {
            //Given an unsorted integer array, find the first missing positive integer.
            //For example,
            //Given [1,2,0] return 3,
            //and [3,4,-1,1] return 2.
            //Your algorithm should run in O(n) time and uses constant space.
            FirstMissingPositive(new[] {4, 3, 4, 1, 1, 4, 1, 4}).ToConsole();
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null || !nums.Any())
                return 1;
            //非正整數位置
            var negativeIndex = -1;
            for (var index1 = 0; index1 < nums.Length; index1++)
            {
                if (nums[index1] <= 0)
                    negativeIndex++;
                //排序
                for (var index2 = index1;
                    index2 > 0 && index2 >= negativeIndex && nums[index2 - 1] > nums[index2];
                    index2--)
                {
                    var temp = nums[index2];
                    nums[index2] = nums[index2 - 1];
                    nums[index2 - 1] = temp;
                }
            }
            //沒正整數
            if (negativeIndex + 1 == nums.Length)
                return 1;
            //重複次數
            var duplicate = 0;
            //前個數
            var preNum = 0;
            //確認是否在自已的位置上
            for (var index = negativeIndex + 1; index < nums.Length; index++)
            {
                if (preNum == nums[index])
                {
                    duplicate++;
                    continue;
                }

                if (nums[index] != index - negativeIndex - duplicate)
                    return index - negativeIndex - duplicate;

                preNum = nums[index];
            }
            //缺最後一個
            return nums[nums.GetUpperBound(0)] + 1;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/climbing-stairs/")]
        public void ClimbingStairs()
        {
            //You are climbing a stair case. It takes n steps to reach to the top.
            //Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
            Console.WriteLine(ClimbingStairs(100));
        }

        private int ClimbingStairs(int distinct)
        {
            if (distinct < 0)
                return 0;

            if (distinct <= 2)
                return distinct;

            return ClimbingStairs(distinct - 2) + ClimbingStairs(distinct - 1);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/climbing-stairs/")]
        public void ClimbingStairsⅠ()
        {
            //You are climbing a stair case. It takes n steps to reach to the top.
            //Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
            Console.WriteLine(ClimbingStairs(100));
        }

        private int ClimbingStairsⅠ(int distinct)
        {
            if (distinct < 0)
                return 0;

            if (distinct <= 2)
                return distinct;

            var set = new List<int> {1, 2};
            for (var i = 2; i < distinct; i++)
                set.Add(set[i - 2] + set[i - 1]);

            return set.Last();
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/plus-one/")]
        public void PlusOne()
        {
            //Given a non-negative number represented as an array of digits, plus one to the number.
            //The digits are stored such that the most significant digit is at the head of the list.
            var num1 = new List<int> {9, 2, 5};
            var num2 = new List<int> {3, 2, 5};

            PlusOne(num1, num2).Dump();
        }

        private List<int> PlusOne(List<int> num1, List<int> num2)
        {
            var sum = new Stack<int>();
            var max = Math.Max(num1.Count, num2.Count);
            var nextPlus = 0;
            for (var i = 0; i < max; i++)
            {
                var current = 0;
                current += nextPlus;
                if (i < num1.Count)
                    current += num1[num1.Count - 1 - i];

                if (i < num2.Count)
                    current += num2[num2.Count - 1 - i];

                nextPlus = current/10;
                sum.Push(current%10);
            }

            if (nextPlus != 0)
                sum.Push(nextPlus);

            return sum.ToList();
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/rotate-image/")]
        public void RotateImage()
        {
            //You are given an n x n 2D matrix representing an image.
            //Rotate the image by 90 degrees (clockwise).
            //Follow up:
            //Could you do this in-place?
            var matrix = new[,] {{1, 5, 5, 5, 5}, {1, 5, 5, 5, 5}, {1, 5, 5, 5, 5}, {1, 5, 5, 5, 5}, {1, 5, 5, 5, 5}};

            RotateDegree90(matrix);
        }

        private void RotateDegree90(int[,] array)
        {
            var result = new int[array.GetLength(1), array.GetLength(0)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    result[j, array.GetLength(0) - i - 1] = array[i, j];
                }
            }
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/search-a-2d-matrix/")]
        public void SearchA2dMatrix()
        {
            //Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
            //Integers in each row are sorted from left to right.
            //The first integer of each row is greater than the last integer of the previous row.
            //For example,
            //Consider the following matrix:
            //  [1,   3,  5,  7],
            //  [10, 11, 16, 20],
            //  [23, 30, 34, 50]
            //Given target = 3, return true.
            var matrix = new int[3, 4] {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 50}};
            var target = 9;

            Console.WriteLine(SearchA2dMatrix(matrix, target));
        }

        private bool SearchA2dMatrix(int[,] matrix, int target)
        {
            var end = matrix.GetLength(0)*matrix.GetLength(1);
            var start = matrix.GetLength(1);
            while (start != end)
            {
                var x = start/matrix.GetLength(1);
                var y = start%matrix.GetLength(0);
                if (matrix[x, y] - target <= matrix[x - 1, y])
                    return false;

                start++;
            }

            return true;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/search-a-2d-matrix/")]
        public void ImplementPow()
        {
            Console.WriteLine(ImplementPow(3, 3));
        }

        private double ImplementPow(double x, int y)
        {
            if (y == 0)
                return 1;

            if (y == 1)
                return x;

            var temp = ImplementPow(x, y/2);
            if (y%2 == 0)
                return temp*temp;

            return x*temp*temp;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/divide-two-integers/")]
        public void DivideTwoIntegers()
        {
            //Divide two integers without using multiplication, division and mod operator.
            Console.WriteLine(DivideTwoIntegers(100, 33));
        }

        private int DivideTwoIntegers(int x, int y)
        {
            if (x == 0 || y == 0)
                return 0;

            var state = 1;
            if (!((x > 0 && y > 0) || (x < 0 && y < 0)))
                state = 1;

            var sum = 0;
            while ((x >= y))
            {
                x -= y;
                sum++;
            }

            return sum*state;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/search-insert-position/")]
        public void SearchInsertPosition()
        {
            //Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
            //You may assume no duplicates in the array.
            //Here are few examples.
            //[1,3,5,6], 5 → 2
            //[1,3,5,6], 2 → 1
            //[1,3,5,6], 7 → 4
            //[1,3,5,6], 0 → 0
            var testArray = new List<int> {1, 3, 5, 6};

            Console.WriteLine(SearchInsertPositionⅰ(testArray, 5));
        }

        private int SearchInsertPosition(List<int> array, int target)
        {
            var n = 0;
            while (n < array.Count())
            {
                if (target <= array[n]) return n;
                n++;
            }

            return n;
        }

        private int SearchInsertPositionⅰ(List<int> array, int target)
        {
            var low = 0;
            var height = array.Count - 1;

            if (target <= array[low])
                return low;

            if (target > array[height])
                return height + 1;

            while (low < height)
            {
                var mid = low + (height - low)/2;
                if (target > array[mid])
                    low = mid + 1;
                else if (target < array[mid])
                    height = mid - 1;
                else
                    return mid;
            }

            return low;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/generate-parentheses/")]
        public void GenerateParentheses()
        {
            //Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
            //For example, given n = 3, a solution set is:
            //"((()))", "(()())", "(())()", "()(())", "()()()"
            var set = new List<string>();

            GenerateParenthesesⅰ(6).Dump();
        }

        private void GenerateParentheses(List<string> set, int n, string s = "")
        {
            if (n == 0)
            {
                if (!set.Contains(s))
                    set.Add(s);

                return;
            }

            if (s != "()")
                GenerateParentheses(set, n - 1, s + "()");

            GenerateParentheses(set, n - 1, "()" + s);
            GenerateParentheses(set, n - 1, "(" + s + ")");
        }

        private List<string> GenerateParenthesesⅰ(int n)
        {
            var set = new List<string> {"()"};
            var tempSet = new List<string>();
            for (var i = 1; i < n; i++)
            {
                tempSet.Clear();
                tempSet.AddRange(set);
                set.Clear();
                tempSet.ForEach(s =>
                {
                    if (s != "()")
                        set.Add(s + "()");

                    set.Add("()" + s);
                    set.Add("(" + s + ")");
                });
            }

            return set;
        }

        [MarkedItem(@"http://community.topcoder.com/tc?module=ProblemDetail&rd=5009&pm=2402")]
        public void BadNeighbors()
        {
            var donations = new List<int> {10, 3, 2, 5, 7, 8};
            Console.WriteLine(MaxDonations(donations));

            var donations1 = new List<int> {11, 15};
            Console.WriteLine(MaxDonations(donations1));

            var donations2 = new List<int> {7, 7, 7, 7, 7, 7, 7};
            Console.WriteLine(MaxDonations(donations2));

            var donations3 = new List<int> {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            Console.WriteLine(MaxDonations(donations3));

            var donations4 = new List<int>
            {
                94,
                40,
                49,
                65,
                21,
                21,
                106,
                80,
                92,
                81,
                679,
                4,
                61,
                6,
                237,
                12,
                72,
                74,
                29,
                95,
                265,
                35,
                47,
                1,
                61,
                397,
                52,
                72,
                37,
                51,
                1,
                81,
                45,
                435,
                7,
                36,
                57,
                86,
                81,
                72
            };

            Console.WriteLine(MaxDonations(donations4));
        }

        private int MaxDonations(List<int> donations)
        {
            var max = new Dictionary<int, int>
            {
                {0, donations[0]},
                {1, donations[1]}
            };

            var index = 2;
            while (index < donations.Count() - 1)
            {
                if (index - 2 == 0)
                {
                    max.Add(2, Math.Max(donations[0], donations[donations.Count() - 1]) + donations[2]);
                    index++;
                    continue;
                }

                max.Add(index, Math.Max(max[index - 2], max[index - 3]) + donations[index]);
                index++;
            }

            return max.Max(m => m.Value);
        }

        [MarkedItem(@"http://community.topcoder.com/tc?module=ProblemDetail&rd=4493&pm=1259")]
        public void ZigZag()
        {
            //var zigZagSequence = new List<int> { 1, 7, 4, 9, 2, 5 };
            //Console.WriteLine(LongestZigZag(zigZagSequence));
            var zigZagSequence1 = new List<int> {1, 17, 5, 10, 13, 15, 10, 5, 16, 8};
            Console.WriteLine(LongestZigZag(zigZagSequence1));
            //var zigZagSequence2 = new List<int> { 44 };
            //Console.WriteLine(LongestZigZag(zigZagSequence2));
        }

        private int LongestZigZag(List<int> zigZagSequence)
        {
            var index = 0;
            var max = 1;
            var tempMax = 1;
            bool? state = null;
            while (index < zigZagSequence.Count() - 1)
            {
                var nextState = (zigZagSequence[index] > zigZagSequence[index + 1]);
                if (state == null)
                {
                    state = nextState;
                    tempMax = 2;
                    max = Math.Max(tempMax, max);
                    index++;
                    continue;
                }

                if (nextState == state)
                {
                    state = !state;
                    max = Math.Max(++tempMax, max);
                    index++;
                }
                else
                    state = null;
            }

            return max;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/pascals-triangle-ii/")]
        public void PascalsTriangleII()
        {
            //Given an index k, return the kth row of the Pascal's triangle.
            //For example, given k = 3,
            //Return [1,3,3,1].
            //Note:
            //Could you optimize your algorithm to use only O(k) extra space?
            PascalsTriangleII(3).Dump();
        }

        private List<int> PascalsTriangleII(int k)
        {
            var space = new List<int> {1};
            var index = 0;
            while (index < k)
            {
                space.Add(space[0]);
                for (var i = index; i > 0; i--)
                {
                    space[i] += space[i - 1];
                }

                index++;
            }

            return space;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/pascals-triangle/")]
        public void PascalsTriangleI()
        {
            //Given numRows, generate the first numRows of Pascal's triangle.
            PascalsTriangleI(5).DumpMany();
        }

        private IEnumerable<List<int>> PascalsTriangleI(int k)
        {
            var set = new List<List<int>> {new List<int> {1}};
            for (var i = 1; i <= k; i++)
            {
                var newSet = new List<int>();
                var frontSet = set[i - 1];
                newSet.Add(frontSet[0]);
                for (var j = 1; j < i; j++)
                {
                    newSet.Add(frontSet[j] + frontSet[j - 1]);
                }

                newSet.Add(frontSet[frontSet.Count - 1]);
                set.Add(newSet);
            }

            return set;
        }

        [MarkedItem]
        public void ArrayListAllSubSet()
        {
            var set = new List<int> {1, 5, 9, 100, 4, 99, 88};
            ArrayListAllSubSet(set).DumpMany();
        }

        private List<List<int>> ArrayListAllSubSet(List<int> set, List<int> subset = null, int index = 0)
        {
            if (index >= set.Count)
                return new List<List<int>> {subset};

            var newset1 = new List<int>();
            var newset2 = new List<int>();
            if (subset != null)
            {
                newset1.AddRange(subset);
                newset2.AddRange(subset);
            }

            newset2.Add(set[index]);
            var result1 = ArrayListAllSubSet(set, newset1, index + 1);
            var result2 = ArrayListAllSubSet(set, newset2, index + 1);

            result1.AddRange(result2);
            return result1;
        }

        [MarkedItem(@"http://community.topcoder.com/stat?c=problem_statement&pm=7558")]
        public void AdvertisingAgency()
        {
            var input1 = new List<int> {1, 2, 3};
            Console.WriteLine(NumberOfRejections(input1));

            var input2 = new List<int> {1, 1, 1};
            Console.WriteLine(NumberOfRejections(input2));

            var input3 = new List<int> {1, 2, 1, 2};
            Console.WriteLine(NumberOfRejections(input3));
        }

        private int NumberOfRejections(List<int> requests)
        {
            if (requests.Count > 50)
                return -1;

            var reject = 0;
            var accepts = new List<int>();
            foreach (var request in requests)
            {
                if (request > 100 || request < 1)
                {
                    reject++;
                    continue;
                }

                if (accepts.Contains(request))
                    reject++;
                else
                    accepts.Add(request);
            }

            return reject;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-list/")]
        public void RemoveDuplicatesfromSortedList()
        {
            //Given a sorted linked list, delete all duplicates such that each element appear only once.
            //For example,
            //Given 1->1->2, return 1->2.
            //Given 1->1->2->3->3, return 1->2->3.
            var array = new List<int> {1, 1, 2, 3, 3};
            RemoveDuplicatesfromSortedList(array);
            array.Dump();
        }

        private void RemoveDuplicatesfromSortedList(List<int> array)
        {
            var index = 0;
            while (index < array.Count() - 1)
            {
                while (index + 1 < array.Count && array[index] == array[index + 1])
                {
                    array.RemoveAt(index + 1);
                }

                index++;
            }
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/merge-sorted-array/")]
        public void MergeSortedArray()
        {
            //Given two sorted integer arrays A and B, merge B into A as one sorted array.
            //Note:
            //You may assume that A has enough space (size that is greater or equal to m + n) to hold additional elements from B. The number of elements initialized in A and B are m and n respectively.
            var list1 = new List<int> {1, 1, 1, 5, 6, 7};
            var list2 = new List<int> {2, 3, 7, 9};

            MergeSortedArray(list1, list2).Dump();
        }

        private List<int> MergeSortedArray(List<int> list1, List<int> list2)
        {
            var p1 = 0;
            var p2 = 0;
            while (p2 < list2.Count)
            {
                while (p1 < list1.Count && list1[p1++] < list2[p2]) ;

                list1.Insert(p1, list2[p2]);
                p2++;
            }

            return list1;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/maximum-subarray/")]
        public void MaximumSubarray()
        {
            //Find the contiguous subarray within an array (containing at least one number) which has the largest sum.
            //For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
            //the contiguous subarray [4,−1,2,1] has the largest sum = 6.
            var array = new List<int> {-2, 1, -3, 4, -1, 2, 1, -5, 4};

            Console.WriteLine(MaximumSubarray(array));
        }

        private int MaximumSubarray(List<int> array)
        {
            var index1 = 0;
            var index2 = 0;
            var currentSum = 0;
            var max = array[0];
            while (index1 < array.Count - 1)
            {
                if (index2 >= array.Count)
                {
                    index2 = ++index1;
                    currentSum = 0;
                }

                currentSum += array[index2++];
                max = Math.Max(max, currentSum);
            }

            return max;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/maximum-subarray/", true)]
        public void MaximumSubarrayⅠ()
        {
            var array = new List<int> {-2, 1, -3, 4, -1, 2, 1, -5, 4};

            Console.WriteLine(MaximumSubarrayⅠ(array));
        }

        private int MaximumSubarrayⅠ(List<int> array)
        {
            var max = array[0];
            var sum = 0;
            foreach (var item in array)
            {
                sum += item;
                max = Math.Max(sum, max);
                sum = Math.Max(sum, 0);
            }

            return max;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/combinations/", true)]
        public void Combinations()
        {
            //given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
            //for example,
            //if n = 4 and k = 2, a solution is
            var set = new List<List<int>>();
            var n = 4;
            var k = 2;
            var pass = n - k;
            Combinations(n, k, pass, new List<int>(), set);

            set.DumpMany();
        }

        private void Combinations(int n, int k, int pass, List<int> subset, List<List<int>> set)
        {
            if (k <= 0)
            {
                set.Add(subset);
                return;
            }

            if (pass > 0)
            {
                Combinations(n - 1, k, pass - 1, subset.ToList(), set);
            }

            var subSet1 = subset.ToList();
            subSet1.Add(n);
            Combinations(n - 1, k - 1, pass, subSet1, set);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-array-ii/")]
        public void RemoveDuplicatesFromSortedArrayⅡ()
        {
            //Follow up for "Remove Duplicates":
            //What if duplicates are allowed at most twice?
            //For example,
            //Given sorted array A = [1,1,1,2,2,3],
            //Your function should return length = 5, and A is now [1,1,2,2,3].
            var elements = new List<int> {1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 3};

            Console.WriteLine(RemoveDuplicatesFromSortedArrayⅡ(elements));
        }

        private int RemoveDuplicatesFromSortedArrayⅡ(List<int> elements)
        {
            if (elements.Count() <= 2)
                return elements.Count();

            for (var i = elements.Count - 1; i >= 2; i--)
            {
                if (elements[i] == elements[i - 2]) elements.RemoveAt(i);
            }

            return elements.Count();
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/sqrtx/")]
        public void ImplementSqrt()
        {
            //Implement int sqrt(int x).
            //Compute and return the square root of x.
            Console.WriteLine(ImplementSqrt(15));
        }

        private long ImplementSqrt(int x)
        {
            long ans = 0;
            var bit = 1l << 16;
            while (bit > 0)
            {
                ans |= bit;
                if (ans*ans > x)
                {
                    ans ^= bit;
                }

                bit >>= 1;
            }

            return ans;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/distinct-subsequences/")]
        public void DistinctSubsequences()
        {
            //Given a string S and a string T, count the number of distinct subsequences of T in S.
            //A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
            //Here is an example:
            //S = "rabbbit", T = "rabbit"
            //Return 3.
            var s = "aarabbbit";
            var t = "rabbit";

            Console.WriteLine(DistinctSubsequences(s, t));
        }

        private int DistinctSubsequences(string s, string t)
        {
            var stime = SequenceRepeatTimes(s);
            var ttime = SequenceRepeatTimes(t);
            if (stime.Count != ttime.Count)
                return 0;

            var all = 1;
            for (var i = 0; i < stime.Count; i++)
            {
                if (stime[i].Key != ttime[i].Key || stime[i].Value < ttime[i].Value)
                    return 0;

                if (stime[i].Value > ttime[i].Value)
                    all *= AllGroup(stime[i].Value, ttime[i].Value);
            }

            return all;
        }

        private int AllGroup(int x, int y)
        {
            var i = Enumerable.Range(1, y).Aggregate((a, b) => a*b);
            var j = Enumerable.Range(x - y + 1, y).Aggregate((a, b) => a*b);

            return i/j;
        }

        private List<KeyValuePair<char, int>> SequenceRepeatTimes(string s)
        {
            var repeat = new List<KeyValuePair<char, int>>();
            for (var i = 0; i < s.Length; i++)
            {
                if (i == 0 || s[i] != s[i - 1])
                {
                    repeat.Add(new KeyValuePair<char, int>(s[i], 1));
                    continue;
                }

                repeat[repeat.Count - 1] = new KeyValuePair<char, int>(repeat.Last().Key, repeat.Last().Value + 1);
            }

            return repeat;
        }

        [MarkedItem(@"https://oj.leetcode.com/discuss/2143/any-better-solution-that-takes-less-than-space-while-in-time"
            )]
        public void DistinctSubsequencesⅠ()
        {
            var s = "aaa";
            var t = "a";

            Console.WriteLine(DistinctSubsequencesⅠ(s, t));
        }

        private int DistinctSubsequencesⅠ(string s, string t)
        {
            var m = s.Length;
            var n = t.Length;
            if (m < n)
                return 0;

            var path = Enumerable.Range(0, n + 1).Select(i => 0).ToList();
            path[0] = 1;

            for (var i = 1; i <= m; i++)
            {
                for (var j = n; j >= 1; j--)
                {
                    path[j] += (s[i - 1] == t[j - 1]) ? path[j - 1] : 0;
                }
            }

            return path[n];
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/permutation-sequence/")]
        public void PermutationSequence()
        {
            PermutationSequence(3).DumpMany();
        }

        private List<List<int>> PermutationSequence(int n)
        {
            var containElement = Enumerable.Range(1, n).ToList();
            var sets = containElement.Select(elements => new List<int> {elements}).ToList();
            containElement.Select(elements => new List<int> {elements});
            for (var i = 1; i < n; i++)
            {
                var temp = new List<List<int>>();
                sets.ForEach(set =>
                {
                    foreach (var element in containElement.Where(elements => !set.Contains(elements)))
                    {
                        var sub = set.ToList();
                        sub.Add(element);
                        temp.Add(sub);
                    }
                });

                sets = temp;
            }

            return sets;
        }

        [MarkedItem(@"https://projecteuler.net/problem=21")]
        public void AmicableNumbers()
        {
            var max = 10000;
            GetPrimesWithinRange(max).ToList();
            var sumSet = Enumerable.Range(2, max - 1)
                .Select(number => new
                {
                    Key = number,
                    Value = GetFactor(number)
                        .Where(factor => factor < number)
                        .Sum()
                })
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in sumSet.Where(set => (sumSet.ContainsKey(set.Value) && set.Key == sumSet[set.Value]))
                )
            {
                Console.WriteLine("index:{0} sum:{1}", element.Key, element.Value);
            }
        }

        [MarkedItem(@"https://projecteuler.net/problem=37")]
        public void TruncatablePrimes()
        {
            var valid = 3797;
            var validString = valid.ToString();
            var group = new List<int>();
            for (var index = 0; index < validString.Length; index++)
            {
                var sub1 = validString.Substring(validString.Length - index - 1, index + 1);
                var sub2 = validString.Substring(index, validString.Length - index);

                int value1;
                if (int.TryParse(sub1, out value1))
                    group.Add(value1);

                int value2;
                if (int.TryParse(sub2, out value2))
                    group.Add(value2);
            }

            Console.WriteLine("All Primes{0}", group.All(i => IsPrime(i)));
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/search-for-a-range/")]
        public void SearchForARange()
        {
            //Given a sorted array of integers, find the starting and ending position of a given target value.
            //Your algorithm's runtime complexity must be in the order of O(log n).
            //If the target is not found in the array, return [-1, -1].
            //For example,
            //Given [5, 7, 7, 8, 8, 10] and target value 8,
            //return [3, 4].
            var search = new List<int> {5, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 10, 10};
            var target = 8;

            SearchForARange(search, target).Dump();
        }

        private List<int> SearchForARange(List<int> search, int target)
        {
            var index = SearchIndex(search, target, 0, search.Count - 1);
            var result = new List<int> {index, index};

            if (index == -1) return result;

            var right = index;
            while ((right = SearchIndex(search, target, 0, --right)) != -1)
                result[0] = right;

            var left = index;
            while ((left = SearchIndex(search, target, ++left, search.Count - 1)) != -1)
                result[1] = left;

            return result;
        }

        /// <summary>
        ///     binary search
        /// </summary>
        /// <param name="search">search list</param>
        /// <param name="target">search target</param>
        /// <param name="start">start postion</param>
        /// <param name="end">end postion</param>
        /// <returns>IndexPosition</returns>
        private int SearchIndex(List<int> search, int target, int start, int end)
        {
            while (start <= end)
            {
                var middle = start + (end - start)/2;
                if (search[middle] > target)
                    end = middle - 1;

                if (search[middle] < target)
                    start = middle + 1;

                if (search[middle] == target)
                    return middle;
            }

            return -1;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/Reorder-List/")]
        public void ReorderList()
        {
            var order = Enumerable.Range(0, 11).ToList();
            ReorderList(order).Dump();
        }

        private IEnumerable<int> ReorderList(List<int> order)
        {
            var index = 0;
            while (index < (order.Count - 1)/2)
            {
                order.Insert(index*2 + 1, order[order.Count - 1]);
                order.RemoveAt(order.Count - 1);
                index++;
            }

            return order;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/single-number/")]
        public void SingleNumber()
        {
            //Given an array of integers, every element appears twice except for one. Find that single one.
            //Note:
            //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
            var searchList = new List<int> {1, 2, 2, 3, 1, 6, 3, 4, 4, 5, 5, 5, 5};

            Console.WriteLine(SingleNumber(searchList));
        }

        private int SingleNumber(List<int> searchList)
        {
            return searchList.Aggregate((a, b) => a ^ b);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-list-ii/")]
        public void RemoveDuplicatesFromSortedListii()
        {
            var list = new List<int> {1, 1, 1, 1, 2, 5, 6, 9, 88, 88, 99, 99, 99, 100};

            RemoveDuplicatesFromSortedListii(list).Dump();
        }

        private IEnumerable<int> RemoveDuplicatesFromSortedListii(List<int> list)
        {
            var i = 1;
            var state = false;
            while (i < list.Count)
            {
                if (list[i - 1] == list[i])
                {
                    list.RemoveAt(i - 1);
                    state = true;
                    continue;
                }

                if (state)
                {
                    list.RemoveAt(i - 1);
                    state = false;
                    continue;
                }

                i++;
            }

            return list;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/permutations/")]
        public void Permutations()
        {
            //Given a collection of numbers, return all possible permutations.
            //For example,
            //[1,2,3] have the following permutations:
            //[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]
            var elements = Enumerable.Range(1, 7).ToList();

            Permutations(elements, elements.Count).DumpMany();
        }

        private IEnumerable<List<int>> Permutations(List<int> elements, int level, List<int> sub = null)
        {
            var subSets = new List<List<int>>();
            if (level == 0)
                return new List<List<int>> {sub};

            if (sub == null)
                sub = new List<int>();

            foreach (var element in elements)
            {
                if (sub.Contains(element))
                    continue;

                var tmp = sub.ToList();
                tmp.Add(element);
                subSets.AddRange(Permutations(elements, level - 1, tmp));
            }

            return subSets;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/word-break/")]
        public void WordBreak()
        {
            //Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.
            //For example, given
            //s = "leetcode",
            //dict = ["leet", "code"].
            //Return true because "leetcode" can be segmented as "leet code".
            var dict = new List<string> {"leet", "code"};
            var s = "leetcode";

            Console.WriteLine(WordBreak(dict, s));
        }

        private bool WordBreak(List<string> dict, string s)
        {
            var stringIndex = 0;
            var dictIndex = 0;
            while (dictIndex < dict.Count && stringIndex + dict[dictIndex].Length - 1 < s.Length)
            {
                if (s.Substring(stringIndex, dict[dictIndex].Length) == dict[dictIndex])
                {
                    stringIndex += dict[dictIndex].Length - 1;
                    dictIndex++;
                }

                stringIndex++;
            }

            return dictIndex >= dict.Count;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/longest-consecutive-sequence/")]
        public void LongestConsecutiveSequence()
        {
            //Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
            //For example,
            //Given [100, 4, 200, 1, 3, 2],
            //The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
            //Your algorithm should run in O(n) complexity.
            var elements = new List<int> {100, 4, 200, 1, 3, 2};

            Console.WriteLine(LongestConsecutiveSequence(elements));
        }

        private int LongestConsecutiveSequence(List<int> elements)
        {
            return 0;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/fraction-to-recurring-decimal/")]
        public void FractionToRecurringDecimal()
        {
            //Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
            //If the fractional part is repeating, enclose the repeating part in parentheses.
            //For example,
            //Given numerator = 1, denominator = 2, return "0.5".
            //Given numerator = 2, denominator = 1, return "2".
            //Given numerator = 2, denominator = 3, return "0.(6)".
            Console.WriteLine(FractionToRecurringDecimal(1, 2));
            Console.WriteLine(FractionToRecurringDecimal(2, 1));
            Console.WriteLine(FractionToRecurringDecimal(2, 3));
        }

        private string FractionToRecurringDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
                return "0";

            var result = new StringBuilder();

            if (numerator < 0 ^ denominator < 0)
                result.Append("-");

            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);

            result.Append(numerator/denominator);
            if (numerator%denominator == 0)
                return result.ToString();

            result.Append(".");
            for (var dic = new Dictionary<int, int>(); numerator > 0; numerator %= denominator)
            {
                if (dic.ContainsKey(numerator))
                {
                    result = result.Insert(dic[numerator], "(");
                    result.Append(")");
                    break;
                }

                dic.Add(numerator, result.Length);
                numerator *= 10;
                result.Append(numerator/denominator);
            }

            return result.ToString();
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/majority-element/")]
        public void MajorityElement()
        {
            //Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
            //You may assume that the array is non-empty and the majority element always exist in the array.
            var elements = new List<int> {1, 3, 1, 1, 5, 1, 9, 1, 1, 7, 1};

            MajorityElement(elements).ToConsole();
        }

        private int MajorityElement(List<int> elements)
        {
            var dic = new Dictionary<int, int>();
            foreach (var e in elements)
            {
                if (!dic.ContainsKey(e))
                    dic.Add(e, 1);
                else
                    dic[e]++;
            }

            return dic.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/excel-sheet-column-title/")]
        public void ExcelSheetColumnTitle()
        {
            //Given a positive integer, return its corresponding column title as appear in an Excel sheet.
            ExcelSheetColumnTitle(28).ToConsole();
        }

        private string ExcelSheetColumnTitle(int number)
        {
            var chars = new List<char>();
            while (number > 0)
            {
                chars.Add((char) ((number - 1)%26 + 65));
                number = (number - 1)/26;
            }

            chars.Reverse();

            return string.Concat(chars);
        }

        [MarkedItem(@"https://oj.leetcode.com/problems/dungeon-game/")]
        public void DungeonGame()
        {
            var rm = new Random();
            var maxNum = 3;
            var dungeon =
                Enumerable.Repeat(0, maxNum).Select(n =>
                    Enumerable.Repeat(0, maxNum).Select(m =>
                        rm.Next(-10, 3)).ToList())
                    .ToList();
            var result = DungeonGame(dungeon);

            ((result >= 0) ? 1 : Math.Abs(result) + 1).ToConsole();
        }

        private int DungeonGame(List<List<int>> dungeon, int x = 0, int y = 0, int maxHp = 0)
        {
            var currentHp = dungeon[x][y] + maxHp;
            var hpList = new List<int>();
            if (x == dungeon.Count - 1 && y == dungeon[0].Count - 1)
                return maxHp;

            if (x + 1 < dungeon.Count)
                hpList.Add(Math.Max(DungeonGame(dungeon, x + 1, y, currentHp), currentHp));

            if (y + 1 < dungeon[0].Count)
                hpList.Add(Math.Max(DungeonGame(dungeon, x, y + 1, currentHp), currentHp));

            return hpList.Max();
        }

        [MarkedItem(@"http://community.topcoder.com/stat?c=problem_statement&pm=4637")]
        public void DayPlanner()
        {
            var tasks = new List<string> {"01:22 A", "01:22 B", "23:22 C"};

            GetEnds(tasks).ToConsole();
        }

        private string GetEnds(List<string> parameters)
        {
            if (parameters.Count <= 0)
                return "";

            var rule = @"[0-2]{1}[0-9][1][:]{1}[0-5]{1}[0-9][1][ ]{1}[A-Zz-z]+$";
            var regex = new Regex(rule);
            if (!parameters.Any(p => regex.IsMatch(p)))
                return string.Empty;

            var firstTime = int.MaxValue;
            var firstTask = string.Empty;
            var endTime = int.MinValue;
            var endTask = string.Empty;
            parameters.ForEach(p =>
            {
                var parameterArray = p.Split(' ');
                var timeArray = parameterArray[0].Split(':');
                var totalMin = Convert.ToInt32(timeArray[0])*60 + Convert.ToInt32(timeArray[1]);
                if (endTime < totalMin)
                {
                    endTime = totalMin;
                    endTask = parameterArray[1];
                }

                if (firstTime > totalMin)
                {
                    firstTime = totalMin;
                    firstTask = parameterArray[1];
                }
            });

            return string.Format("{0}-{1}", firstTask, endTask);
        }

        [MarkedItem(@"https://projecteuler.net/problem=185")]
        public void NumberMind()
        {
            var dictionary = new Dictionary<int, int>
            {
                {90342, 2},
                {70794, 0},
                {39458, 2},
                {34109, 1},
                {51545, 2},
                {12531, 1}
            };

            NumberMind(5, dictionary).ToConsole();
        }

        private int NumberMind(int digit, Dictionary<int, int> dictionary)
        {
            var elements = Enumerable.Range((int) Math.Pow(10, digit - 1),
                (int) Math.Pow(10, digit) - (int) Math.Pow(10, digit - 1));

            return elements.FirstOrDefault(element =>
                dictionary.All((key, keypair) =>
                {
                    var compareItem1 = keypair.Key.ToString();
                    var compareItem2 = element.ToString();
                    var times = keypair.Value;
                    var count = 0;
                    for (var index = 0; index < digit; index++)
                    {
                        if (compareItem1[index] == compareItem2[index])
                            count++;
                        if (count > times)
                            return false;
                    }

                    return (count == times);
                }));
        }

        [MarkedItem]
        public void RepeatedDnaSequences()
        {
            var dna = "AAAAACCCCCAAAAACCCCCAAAAAGGGTTT";

            RepeatedDnaSequences(dna, 10).Dump();
        }

        public List<string> RepeatedDnaSequences(string dna, int letterLong)
        {
            var dictionary = new Dictionary<string, int>();
            for (var index = 0; index < dna.Length - letterLong; index++)
            {
                var str = dna.Substring(index, letterLong);
                if (dictionary.ContainsKey(str))
                {
                    dictionary[str]++;
                    continue;
                }

                dictionary.Add(str, 1);
            }

            return dictionary.Where(d => d.Value >= 2).Select(d => d.Key).ToList();
        }

        [MarkedItem("https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/")]
        public void BestTimeToBuyAndSellStockIv()
        {
            var random = new Random();
            var elements = Enumerable.Range(1, 10).Select(n => random.Next(1, 100)).ToList();

            BestTimeToBuyAndSellStock(elements).ToConsole("BestProfit:");
        }

        public int BestTimeToBuyAndSellStock(IList<int> elements)
        {
            var profit = 0;
            var buyPrice = 0;
            for (var i = 0; i < elements.Count - 1; i++)
            {
                if (buyPrice == 0 && elements[i] < elements[i + 1])
                {
                    profit -= elements[i];
                    buyPrice = elements[i];
                    continue;
                }

                if (buyPrice != 0 && elements[i] > elements[i + 1])
                {
                    profit += elements[i];
                    buyPrice = 0;
                }
            }

            return buyPrice == 0 ? profit : profit + elements.Last();
        }

        [MarkedItem("https://oj.leetcode.com/problems/rotate-array/")]
        public void RotateArray()
        {
            var elements = Enumerable.Range(1, 7).ToArray();

            RotateArrayⅰ(elements, 3).Dump();
            "=======================".ToConsole();

            RotateArrayⅱ(elements, 3).Dump();

            "=======================".ToConsole();
            RotateArrayⅲ(elements, 3).Dump();
        }

        private int[] RotateArrayⅰ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;
            position = position%length + 1;

            if (position == 0)
                return array;

            var newArray = new int[length];
            for (var i = 0; i < length; i++)
            {
                newArray[i] = array[(position + i)%length];
            }

            return newArray;
        }

        private int[] RotateArrayⅱ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;

            if (position == 0)
                return array;

            return Enumerable.Range(1, length).Select(n => array[(n + position)%length]).ToArray();
        }

        private int[] RotateArrayⅲ(int[] array, int position)
        {
            if (position < 0)
                throw new Exception("invalid paramater positon");

            var length = array.Length;
            var moveDistance = length - (position%length);

            if (position == 0)
                return array;

            for (var indexFromMoveDistance = 0; indexFromMoveDistance < length - moveDistance; indexFromMoveDistance++)
            {
                for (var step = moveDistance; step > 0; step--)
                {
                    UtilityHelper.Swap(ref array[indexFromMoveDistance + step - 1],
                        ref array[indexFromMoveDistance + step]);
                }
            }

            return array;
        }

        [MarkedItem("https://oj.leetcode.com/problems/palindrome-partitioning-ii/")]
        public void PalindromePartitioningII()
        {
            PalindromePartitioningII("aaabaaacc").Dump();
        }

        public List<string> PalindromePartitioningII(string @string)
        {
            var result = new List<string>();
            var index = 0;
            while (index < @string.Length)
            {
                var tempindex = 0;
                var tempString = string.Empty;
                for (var subStringLength = 1; index + subStringLength <= @string.Length; subStringLength++)
                {
                    var tempValue = @string.Substring(index, subStringLength);
                    if (!tempValue.IsPalindrome())
                        continue;

                    tempindex = index + subStringLength;
                    tempString = tempValue;
                }

                result.Add(tempString);
                index = tempindex;
            }

            return result;
        }

        [MarkedItem("https://oj.leetcode.com/problems/interleaving-string/")]
        public void InterleavingString()
        {
            var s1 = "a";
            var s2 = "b";
            var s3 = "ab";

            IsInterleave(s1, s2, s3).ToConsole();
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            if (s3.Length == 0)
                return true;

            if (s1.Length == 0)
                return s2 == s3;

            if (s2.Length == 0)
                return s1 == s3;

            return (s1[0] == s3[0]
                    &&
                    IsInterleave(s1.Substring(1, s1.Length - 1), s2, s3.Substring(1, s3.Length - 1)))
                   ||
                   (s2[0] == s3[0]
                    &&
                    IsInterleave(s1, s2.Substring(1, s2.Length - 1), s3.Substring(1, s3.Length - 1)));
        }

        [MarkedItem("https://leetcode.com/problems/candy/")]
        public void Candy2()
        {
            var ratings = new[] {2, 1, 9, 2, 3, 34, 1};

            Candy2(ratings).ToConsole();
        }

        public int Candy2(int[] ratings)
        {
            if (!ratings.Any())
                return 0;

            var candy = Enumerable.Repeat(1, ratings.Length).ToList();
            var peak = 0;

            for (var index = 0; index < ratings.Length - 1; index++)
            {
                if (ratings[index] < ratings[index + 1])
                {
                    candy[index + 1] = candy[index] + 1;
                    peak = index + 1;
                    continue;
                }

                if (ratings[index] > ratings[index + 1]
                    && candy[index] <= candy[index + 1])
                {
                    for (var addIndex = peak; addIndex <= index; addIndex++)
                        candy[addIndex]++;

                    continue;
                }

                if (ratings[index] != ratings[index + 1])
                    continue;

                var max = Math.Max(candy[index], candy[index + 1]);
                candy[index] = max;
                candy[index + 1] = max;
            }

            return candy.Sum();
        }

        [MarkedItem("https://leetcode.com/problems/minimum-size-subarray-sum/")]
        public void MinimumSizeSubarraySum()
        {
            var elements = new[] {2, 3, 1, 2, 4, 3};
            var solution = 7;

            MinimumSizeSubarraySum(solution, elements).ToConsole();
        }

        public int MinimumSizeSubarraySum(int solution, int[] elements)
        {
            var gap = 0;
            var length = elements.Length;

            while (++gap <= length)
            {
                var tail = length - gap + 1;
                var subArray = Enumerable.Range(0, tail)
                    .Select(start => elements.SubArray(start, gap));

                if (subArray.Any(array => array.Sum() >= solution))
                    return gap;
            }

            return 0;
        }

        [MarkedItem("https://leetcode.com/problems/happy-number/")]
        public void HappyNumber()
        {
            IsHappy(7).ToConsole();

            IsHappy(100).ToConsole();
        }

        private bool IsHappy(int number)
        {
            if (number == 0)
                return false;

            if (number == 1)
                return true;

            var hashSet = new HashSet<int>();
            while (true)
            {
                number = number.DecomposeNoSignDigit().Sum(digit => digit*digit);
                if (number == 1)
                    return true;

                if (hashSet.Contains(number))
                    return false;

                hashSet.Add(number);
            }
        }

        [MarkedItem]
        public void SingleNumberⅠ()
        {
            var nums = new[] {1, 1, 2, 2, 10, 5, 10, 3, 3, 4, 4};

            SingleNumberⅠ(nums).ToConsole();
        }

        private unsafe int SingleNumberⅠ(int[] nums)
        {
            fixed (int* pNums = nums)
            {
                for (var i = 0; i < nums.Count() - 1; i++)
                {
                    *(pNums + i + 1) ^= *(pNums + i);
                }

                return nums[nums.Count() - 1];
            }
        }

        [MarkedItem]
        public void FindKthLargest()
        {
            var nums = Enumerable.Range(1, 1).Shuffle().ToArray();
            var k = 1;

            FindKthLargest(nums, k).ToConsole();
        }

        private int FindKthLargest(int[] nums, int k)
        {
            return nums.OrderByDescending(x => x).Skip(k - 1).First();
        }

        [MarkedItem]
        public void LengthOfLongestSubstring()
        {
            LengthOfLongestSubstring("ac").ToConsole();
        }

        private int LengthOfLongestSubstring(string s)
        {
            if (s == string.Empty)
                return 0;

            if (s.Length == 1)
                return 1;

            var index = 0;
            var max = int.MinValue;
            for (var i = 0; i < s.Length; i++)
            {
                var sub = s.Substring(index, i - index);
                if (sub.Contains(s[i]))
                    index += sub.IndexOf(s[i]) + 1;

                max = Math.Max(max, i - index + 1);
            }

            return max;
        }

        [MarkedItem]
        public void LargestRectangleArea()
        {
            LargestRectangleArea(Enumerable.Range(1, 10000).ToArray()).ToConsole();
        }

        private int LargestRectangleArea(int[] height)
        {
            if (height == null || height.Count() == 0)
                return 0;

            var max = 0;
            for (var index = 0; index < height.Count(); index++)
            {
                if (height[index]*Count < max)
                    continue;

                int pIndex;
                int sIndex;
                for
                    (
                    pIndex = index;
                    pIndex - 1 > -1 && height[index] <= height[pIndex - 1];
                    pIndex--
                    ) ;

                for
                    (
                    sIndex = index;
                    sIndex + 1 < height.Count() && height[index] <= height[sIndex + 1];
                    sIndex++
                    ) ;

                var area = height[index]*(sIndex - pIndex + 1);
                max = Math.Max(max, area);
            }

            return max;
        }

        [MarkedItem]
        public void SummaryRanges()
        {
            //https://leetcode.com/problems/summary-ranges/
            var nums = new[] {0, 1, 2, 4, 5, 7};

            SummaryRanges(nums).Dump();
        }

        private List<string> SummaryRanges(int[] nums)
        {
            if (nums == null || nums.Count() == 0)
                return new List<string>();

            var index = -1;
            var result = new List<string>();
            var temp = new List<int>();
            while (++index < nums.Count())
            {
                if (!temp.Any())
                {
                    temp.Add(nums[index]);
                    continue;
                }

                if (temp.Last() + 1 == nums[index])
                    temp.Add(nums[index]);
                else
                {
                    result.Add(ConvertToSummary(temp));
                    temp.Clear();
                    temp.Add(nums[index]);
                }
            }

            result.Add(ConvertToSummary(temp));

            return result.Where(x => x != string.Empty).ToList();
        }

        private string ConvertToSummary(List<int> temp)
        {
            if (temp == null && !temp.Any())
                return string.Empty;

            if (temp.First() == temp.Last())
                return temp.First().ToString();

            return string.Format("{0}->{1}", temp.First(), temp.Last());
        }

        [MarkedItem]
        public void InvertTree()
        {
            //https://leetcode.com/problems/invert-binary-tree/
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9)
                }
            };

            InvertTree(root);
        }

        private TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            if (root.left != null)
                InvertTree(root.left);

            if (root.right != null)
                InvertTree(root.right);

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            return root;
        }

        [MarkedItem]
        public void ComputeArea()
        {
            //https://leetcode.com/problems/rectangle-area/
            ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2).ToConsole();
        }

        private int ComputeArea(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            var areaOfSqrA = (c - a)*(d - b);
            var areaOfSqrB = (g - e)*(h - f);

            var left = Math.Max(a, e);
            var right = Math.Min(g, c);
            var bottom = Math.Max(f, b);
            var top = Math.Min(d, h);

            var overlap = 0;
            if (right > left && top > bottom)
                overlap = (right - left)*(top - bottom);

            return areaOfSqrA + areaOfSqrB - overlap;
        }

        [MarkedItem]
        public void Reverse()
        {
            Reverse(1534236469).ToConsole();
        }

        private int Reverse(int x)
        {
            if (x == int.MinValue || x == int.MaxValue)
                return 0;

            var sign = (x < 0) ? -1 : 1;
            x = Math.Abs(x);
            var tempString = string.Concat(x.ToString().OrderByDescending(y => y));
            try
            {
                checked
                {
                    return sign*Convert.ToInt32(tempString);
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        [MarkedItem]
        public void HammingWeight()
        {
            //https://leetcode.com/problems/number-of-1-bits/
            HammingWeight(1).ToString();
        }

        private int HammingWeight(uint n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }

        [MarkedItem]
        public void LengthOfLastWord()
        {
            LengthOfLastWord("abc abca abc").ToConsole();
        }

        private int LengthOfLastWord(string s)
        {
            return (from set in s.Split(' ').Reverse() where set.Length != 0 select set.Length).FirstOrDefault();
        }

        [MarkedItem]
        public void MajorityElementⅡ()
        {
            //https://leetcode.com/problems/majority-element-ii/
            var random = new Random();
            Enumerable.Range(1, 100).Select(n => random.Next(30)).ToArray();
        }

        private IList<int> MajorityElementⅡ(int[] nums)
        {
            return nums
                .GroupBy(x => x)
                .Where(g => g.Count() > nums.Length/3)
                .Select(x => x.Key)
                .ToList();
        }

        [MarkedItem]
        public void MaxPointsonaLine()
        {
            //Random random = new Random();
            //var points = Enumerable.Range(1, 20).Select(n => new Point((int)random.Next(1, 100), (int)random.Next(1, 100))).ToArray();
            //MaxPoints(points).ToConsole();
            var points = new[]
            {
                new Point(84, 250),
                new Point(0, 0),
                new Point(1, 0),
                new Point(0, -70),
                new Point(0, -70),
                new Point(1, -1),
                new Point(21, 10),
                new Point(42, 90),
                new Point(-42, -230)
            };

            MaxPoints(points).ToConsole();
        }

        private int MaxPoints(Point[] points)
        {
            var pointCountGroup = points.GroupBy(p => new {p.x, p.y}).ToDictionary(g =>
                new Point
                {
                    x = g.Key.x,
                    y = g.Key.y
                },
                g => g.Count());

            if (pointCountGroup.Count <= 2)
                return pointCountGroup.Sum(p => p.Value);


            var slopePointGroup = new Dictionary<float, List<Point>>();
            for (var i = 0; i < pointCountGroup.Count - 1; i++)
            {
                for (var j = i + 1; j < pointCountGroup.Count; j++)
                {
                    var p1 = pointCountGroup.Keys.ElementAt(i);
                    var p2 = pointCountGroup.Keys.ElementAt(j);

                    var slope = CaculateSlopeA(p1, p2);
                    if (!slopePointGroup.ContainsKey(slope))
                        slopePointGroup.Add(slope, new List<Point> {p1});

                    if (!slopePointGroup[slope].Contains(p2))
                        slopePointGroup[slope].Add(p2);
                }
            }

            return slopePointGroup
                .Select(sp => sp.Value.Sum(p => pointCountGroup[p]))
                .Max();
        }

        private float CaculateSlopeA(Point point1, Point point2)
        {
            if (point1.y == point2.y)
                return float.MinValue;

            if (point1.x == point2.x)
                return float.MaxValue;

            return (point2.y - point1.y)/(point2.x - point1.x);
        }

        private class Point
        {
            public int x;
            public int y;

            public Point()
            {
                x = 0;
                y = 0;
            }

            public Point(int a, int b)
            {
                x = a;
                y = b;
            }
        }

        [MarkedItem]
        public void CountDigitOne()
        {
            CountDigitOne(10).ToConsole();
            CountDigitOne(100).ToConsole();
            CountDigitOne(1000).ToConsole();
        }

        private int CountDigitOne(int n)
        {
            if (n < 1)
                return 0;

            long ones = 0;
            for (long m = 1; m <= n; m *= 10)
            {
                ones += (n/m + 8)/10*m + (n/m%10 == 1 ? n%m + 1 : 0);
            }

            return (int) ones;
        }

        [MarkedItem("https://leetcode.com/problems/product-of-array-except-self/")]
        public void ProductExceptSelf()
        {
            var set = new[] {1, 1};
            ProductExceptSelf(set).Dump();
        }

        private int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Count() < 2)
                return null;

            var zeroCount = nums.Where(x => x == 0).Count();
            if (zeroCount >= 2)
                return nums.Select(x => 0).ToArray();

            var total = nums.Where(x => x != 0).Aggregate((a, b) => a*b);

            return zeroCount != 1
                ? nums.Select(x => total/x).ToArray()
                : nums.Select(x => x == 0 ? total : 0).ToArray();
        }

        /// <summary>
        ///     context
        ///     兩個數加起來等於target
        ///     solution
        ///     用字典記錄target - num 及 num 去做mapping
        /// </summary>
        [MarkedItem]
        public void TwoSumⅠ()
        {
            TwoSumⅠ(new[] {3, 2, 4}, 6).Dump();
        }

        private int[] TwoSumⅠ(int[] nums, int target)
        {
            var length = nums.Length;
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < length; i++)
            {
                var num = nums[i];
                if (dictionary.ContainsKey(num))
                    return new[] {dictionary[num] + 1, i + 1};

                dictionary[target - num] = i;
            }

            throw new ArgumentException("Invalid argument.");
        }

        [MarkedItem("https://leetcode.com/problems/contains-duplicate-ii/")]
        public void ContainsNearbyDuplicate()
        {
        }

        private bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length < 2)
                return false;

            var dic = new Dictionary<int, HashSet<int>>();
            for (var index = 0; index < nums.Length; index++)
            {
                var num = nums[index];
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, new HashSet<int> {index});
                    continue;
                }

                var hashSet = dic[num];
                if (hashSet.Any(x => index - x <= k))
                    return true;

                hashSet.Add(index);
            }

            return false;
        }

        [MarkedItem]
        public void QSort()
        {
            var random = new Random();
            var set = Enumerable.Range(0, 10).OrderBy(x => random.Next());

            QuickSort(set).Dump();
        }

        private IEnumerable<int> QuickSort(IEnumerable<int> source)
        {
            var quickSort = source as IList<int> ?? source.ToList();
            if (!quickSort.Any())
                return quickSort;

            var pivot = quickSort.First();

            return QuickSort(quickSort.Where(n => n < pivot))
                .Concat(quickSort.Where(n => n == pivot))
                .Concat(QuickSort(quickSort.Where(n => n > pivot)));
        }

        /// <summary>
        ///     context
        ///     搜尋target是否有在matrix當中
        ///     solution
        ///     二元搜尋row直到第一個引數大於target
        /// </summary>
        [MarkedItem]
        public void SearchMatrix()
        {
            var matrix = new[,]
            {
                {1, 4, 7, 11, 15, 60},
                {2, 5, 8, 12, 19, 61},
                {3, 6, 9, 16, 22, 62},
                {10, 13, 14, 17, 24, 63},
                {18, 21, 23, 26, 30, 64}
            };

            SearchMatrix(matrix, 23).ToConsole();
        }

        private bool SearchMatrix(int[,] matrix, int target)
        {
            for (var x = 0; x < matrix.GetLength(0); x++)
            {
                if (matrix[x, 0] > target)
                    return false;

                if (BinarySearch(matrix, x, target))
                    return true;
            }

            return false;
        }

        private bool BinarySearch(int[,] matrix, int x, int target)
        {
            var right = matrix.GetLength(1) - 1;
            var left = 0;

            while (left <= right)
            {
                var middle = (right + left)/2;

                if (matrix[x, middle] == target)
                    return true;

                if (matrix[x, middle] > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return false;
        }

        [MarkedItem]
        public void MinWindow()
        {
            var s = "abeceeeeeea";
            var t = "bc";

            MinWindow(s, t).ToConsole();
        }

        private string MinWindow(string s, string t)
        {
            var dictionary = new Dictionary<char, Queue<int>>();
            foreach (var @char in t)
            {
                if (!dictionary.ContainsKey(@char))
                    dictionary[@char] = new Queue<int>();

                dictionary[@char].Enqueue(-1);
            }

            var counter = 0;
            var firstIndex = 0;
            var start = -1;
            var minLength = s.Length;

            Queue<int> pointer;
            for (var index = 0; index < s.Length; index++)
            {
                if (!dictionary.ContainsKey(s[index]))
                    continue;

                pointer = dictionary[s[index]];
                if (pointer.Peek() == -1)
                    counter++;

                pointer.Enqueue(index);
                pointer.Dequeue();

                //Counter集滿前不向下進行
                if (counter != t.Length
                    || (minLength != s.Length && s[index] != s[firstIndex]))
                    continue;

                //最小的index
                firstIndex = dictionary
                    .Select(item => item.Value.Peek())
                    .Concat(new[] {s.Length})
                    .Min();

                var len = index - firstIndex + 1;
                if (len >= minLength && len != s.Length)
                    continue;

                start = firstIndex;
                minLength = len;
            }

            return start == -1 ? string.Empty : s.Substring(start, minLength);
        }

        /// <summary>
        ///     context
        ///     從haystack尋找needle的位置
        ///     solution
        /// </summary>
        [MarkedItem]
        public void StrStr()
        {
            var haystack = "mississippi";
            var needle = "pi";

            StrStr(haystack, needle).ToConsole();
        }

        private int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
                return -1;

            if (needle == haystack)
                return 0;

            if (haystack.Length == 0 || needle.Length == 0)
                return -1;

            for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack[i] == needle[0] && haystack.Substring(i, needle.Length) == needle)
                    return i;
            }

            return -1;
        }

        [MarkedItem]
        public void MinDistance()
        {
            var word1 = "aaaaa";
            var word2 = "aaa";

            MinDistance(word1, word2).ToConsole();
        }

        private int MinDistance(string word1, string word2)
        {
            var matrix = new int[word2.Length + 1, word1.Length + 1];
            matrix[0, 0] = 0;

            for (var i = 1; i <= word1.Length; i++)
                matrix[0, i] = i;

            for (var i = 1; i <= word2.Length; i++)
                matrix[i, 0] = i;

            for (var i = 1; i <= word2.Length; i++)
            {
                for (var j = 1; j <= word1.Length; j++)
                {
                    var min = Math.Min(matrix[i - 1, j - 1] + (word1[j - 1] == word2[i - 1] ? 0 : 1),
                        matrix[i - 1, j] + 1);
                    min = Math.Min(min, matrix[i, j - 1] + 1);

                    matrix[i, j] = min;
                }
            }

            return matrix[word2.Length, word1.Length];
        }

        /// <summary>
        ///     context
        ///     三個元素加起來等於0
        ///     solution
        ///     使用三個指針 index1向右 index2於index1 +1 向右 index3最尾邊向左
        ///     當index2 > index3 index1 + 1
        ///     使用三個元素組成新的hashcode防重複組合進入
        /// </summary>
        [MarkedItem]
        public void ThreeSum()
        {
            ThreeSum(new[] {-2, 0, 1, 1, 2}).DumpMany();
        }

        private List<List<int>> ThreeSum(int[] nums)
        {
            var result = new HashSet<List<int>>();
            if (nums.Length < 3)
                return result.ToList();

            Array.Sort(nums);
            for (var index1 = 0; index1 < nums.Length - 2; index1++)
            {
                var index2 = index1 + 1;
                var index3 = nums.Length - 1;
                while (index2 < index3)
                {
                    var sum = nums[index1] + nums[index2] + nums[index3];
                    if (sum == 0)
                    {
                        result.Add(new SumItem {nums[index1], nums[index2], nums[index3]});
                        index2++;
                        index3--;
                    }
                    else if (sum < 0)
                        index2++;
                    else
                        index3--;
                }
            }

            return result.ToList();
        }

        private List<List<int>> FourSum(int[] nums, int target)
        {
            var result = new HashSet<List<int>>();
            if (nums.Length < 4)
                return result.ToList();

            Array.Sort(nums);
            for (var index1 = 0; index1 < nums.Length - 3; index1++)
            {
                for (var index2 = index1 + 1; index2 < nums.Length - 2; index2++)
                {
                    var index3 = index2 + 1;
                    var index4 = nums.Length - 1;
                    while (index3 < index4)
                    {
                        var sum = nums[index1] + nums[index2] + nums[index3] + nums[index4];
                        if (sum == target)
                        {
                            result.Add(new SumItem {nums[index1], nums[index2], nums[index3], nums[index4]});
                            index3++;
                            index4--;
                        }
                        else if (sum < target)
                            index3++;
                        else
                            index4--;
                    }
                }
            }

            return result.ToList();
        }

        private class SumItem : List<int>
        {
            public override int GetHashCode()
            {
                unchecked
                {
                    return this.Aggregate(19, (current, item) => current * 31 + item.GetHashCode());
                }
            }

            public override bool Equals(object obj)
            {
                var other = obj as SumItem;
                if (other == null)
                    return false;

                return this[0] == other[0] && this[1] == other[1] && this[2] == other[2];
            }
        }

        /// <summary>
        ///     context
        ///     二進位字串加法
        ///     solution
        ///     先反轉ab字串列出所有加法情況逐一進行運算
        /// </summary>
        [MarkedItem]
        public void AddBinary()
        {
            AddBinary("11", "1").ToConsole();
        }

        private string AddBinary(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
                return b;

            if (string.IsNullOrEmpty(b))
                return a;

            a = a.Reverse();
            b = b.Reverse();

            var result = string.Empty;
            var bound = Math.Min(a.Length, b.Length);
            var carry = false;
            var currentIndex = 0;
            for (; currentIndex < bound; currentIndex++)
            {
                result += CaculateBit(ref carry, a[currentIndex], b[currentIndex]);
            }

            if (a.Length != b.Length)
            {
                var longArray = (a.Length > b.Length) ? a : b;
                for (; currentIndex < longArray.Length; currentIndex++)
                {
                    result += CaculateBit(ref carry, longArray[currentIndex]);
                }
            }

            if (carry)
                result += "1";

            return result.Reverse();
        }

        private string CaculateBit(ref bool add, char right = '0', char left = '0')
        {
            switch (right.ToString() + left.ToString() + add.ToString())
            {
                case "00False":
                    return "0";
                case "10False":
                case "01False":
                    return "1";
                case "11False":
                    add = true;
                    return "0";
                case "00True":
                    add = false;
                    return "1";
                case "10True":
                case "01True":
                    return "0";
                case "11True":
                    return "1";
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        ///     context
        ///     號碼有對應的英文字找出所有可能
        ///     solution
        ///     生成字典樹片遍出所有可能
        /// </summary>
        [MarkedItem]
        public void LetterCombinations()
        {
            LetterCombinations("33429").Dump();
        }

        private IList<string> LetterCombinations(string digits)
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
                    ? new List<string> { msg }
                    : node.Sons.SelectMany(son => GetCombinations(son, msg));
            }
        }

        /// <summary>
        ///     context
        ///     每個candidates可以重複加起來等於target
        ///     solution
        ///     遞迴求解
        /// </summary>
        [MarkedItem]
        public void CombinationSum()
        {
            var result = CombinationSum(new[] {2, 3, 6, 7}, 7);
        }

        private List<List<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            return CombinationSum(candidates, target, new List<int>()).ToList();
        }

        private IEnumerable<List<int>> CombinationSum(int[] candidates, int target, IEnumerable<int> current,
            int candidateIndex = 0)
        {
            var enumerable = current as IList<int> ?? current.ToList();
            if (enumerable.Sum() == target)
                return new List<List<int>> {enumerable.ToList()};

            if (enumerable.Sum() > target || candidateIndex >= candidates.Length)
                return null;

            var result = new List<List<int>>();
            for (var index = candidateIndex; index < candidates.Length; index++)
            {
                var items = enumerable.ToList();
                items.Add(candidates[index]);

                var collection = CombinationSum(candidates, target, items, index + 1);
                if (collection != null && collection.Any())
                    result.AddRange(collection);
            }

            return result;
        }

        /// <summary>
        ///     context
        ///     存重複數字列出可組成target的所有可能
        ///     solution
        ///     遞迴求解
        /// </summary>
        [MarkedItem]
        public void CombinationSum2()
        {
            var result = CombinationSum2(new[] {1, 1}, 1);
        }

        private List<List<int>> CombinationSum2(int[] candidates, int target)
        {
            candidates = candidates.Where(x => x <= target).OrderBy(x => x).ToArray();
            var result = new List<List<int>>();
            CombinationSum2(candidates, target, new List<int>(), result);

            return result.Select(item => item.ToList()).ToList();
        }

        private void CombinationSum2(int[] candidates, int target, List<int> currentItems, List<List<int>> result,
            int candidateIndex = 0)
        {
            if (target == 0)
            {
                result.Add(currentItems);

                return;
            }

            if (target < 0 || candidateIndex >= candidates.Length || candidateIndex < 0)
                return;

            var preNum = int.MinValue;
            for (var index = candidateIndex; index < candidates.Length; index++)
            {
                var curNum = candidates[index];
                if (preNum == curNum)
                    continue;

                var items = currentItems.ToList();
                items.Add(candidates[index]);
                preNum = curNum;

                CombinationSum2(candidates, target - candidates[index], items, result, index + 1);
            }
        }

        /// <summary>
        ///     context
        ///     尋找第一個峰項的引數
        ///     solution
        ///     爬山 坡度上升用peakIndex儲存位置下降回傳Index
        /// </summary>
        [MarkedItem]
        public void FindPeakElement()
        {
            FindPeakElement(new[] {1, 2, 3, 1}).ToConsole();
        }

        public int FindPeakElement(int[] nums)
        {
            if (nums.Length < 1)
                return 0;

            var peakIndex = 0;
            for (var index = 0; index < nums.Length - 1; index++)
            {
                if (nums[index] < nums[index + 1])
                    peakIndex = index + 1;
                if (nums[index] > nums[index + 1])
                    return peakIndex;
            }

            return peakIndex;
        }

        /// <summary>
        ///     context
        ///     是否為字謎
        ///     solution
        ///     t字串變成字典檔s字串逐一去減看是否全部被去除
        /// </summary>
        [MarkedItem]
        public void IsAnagram()
        {
            IsAnagram("a", "b").ToConsole();
        }

        public bool IsAnagram(string s, string t)
        {
            if (s == t)
                return true;
            if (t.Length != s.Length)
                return false;

            var dic = new Dictionary<char, int>();
            foreach (var c in t)
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 1);
                    continue;
                }

                dic[c]++;
            }

            foreach (var c in s.Where(x => dic.ContainsKey(x)))
            {
                dic[c]--;
            }

            return dic.All(x => x.Value == 0);
        }

        /// <summary>
        ///     context
        ///     找尋獨立島
        ///     solution
        ///     片歷元素 如果是陸地遞迴四周 並使用xy組成hashcode加入hashtable防止重複找尋
        /// </summary>
        [MarkedItem]
        public void NumIslands()
        {
            var island = new[,]
            {
                {'1', '1', '1', '0', '0', '0'},
                {'1', '1', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '0', '0'},
                {'1', '0', '0', '0', '1', '0'}
            };
            NumIslands(island).ToConsole();
        }

        public int NumIslands(char[,] grid)
        {
            var xBoundary = grid.GetLength(1);
            var yBoundary = grid.GetLength(0);

            var set = new HashSet<int>();
            var count = 0;
            foreach (var index in Enumerable.Range(0, xBoundary*yBoundary))
            {
                var x = index%xBoundary;
                var y = index/xBoundary;

                if (grid[y, x] == '0')
                    continue;

                var hash = x*37 + y*31;
                if (set.Contains(hash))
                    continue;

                Check(set, grid, x, y);

                count++;
            }

            return count;
        }

        public void Check(HashSet<int> set, char[,] grid, int x, int y)
        {
            if (x < 0 || x >= grid.GetLength(1))
                return;

            if (y < 0 || y >= grid.GetLength(0))
                return;

            var hash = x*37 + y*31;
            if (set.Contains(hash))
                return;

            set.Add(hash);
            if (grid[y, x] == '0')
                return;

            Check(set, grid, x + 1, y);
            Check(set, grid, x - 1, y);
            Check(set, grid, x, y + 1);
            Check(set, grid, x, y - 1);
        }

        /// <summary>
        ///     Context
        ///     排出最大數
        ///     Solution
        ///     實作compare
        ///     1.比最短長度
        ///     2.比最長長度
        ///     3.比第一個大於第二個
        /// </summary>
        [MarkedItem]
        public void LargestNumber()
        {
            var a = LargestNumber(new[] {830, 8308});
        }

        public string LargestNumber(int[] nums)
        {
            if (nums.All(n => n == 0))
                return "0";

            var list = nums.ToList();
            list.Sort(new IntComparer());

            return list.Select(x => x.ToString()).Aggregate((a, b) => a + b);
        }

        [MarkedItem]
        public void IsIsomorphic()
        {
            IsIsomorphic("ab", "aa").ToConsole();
        }

        public bool IsIsomorphic(string s, string t)
        {
            if (s == t)
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return false;

            if (s.Length != t.Length)
                return false;

            var dic = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], t[i]);

                if (dic[s[i]] != t[i])
                    return false;
            }

            return true;
        }

        private class IntComparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                var strA = a.ToString();
                var strB = b.ToString();
                var minLength = Math.Min(strA.Length, strB.Length);
                var maxLength = Math.Max(strA.Length, strB.Length);

                var preIndex = -1;
                while (++preIndex < minLength)
                {
                    if (strA[preIndex] > strB[preIndex])
                        return -1;

                    if (strA[preIndex] < strB[preIndex])
                        return 1;
                }

                if (strA.Length == strB.Length)
                    return 0;

                var lastIndex = -1;
                var state = (strA.Length > strB.Length)
                    ? 1
                    : -1;

                var maxString = (strA.Length > strB.Length)
                    ? strA
                    : strB;

                while (preIndex + ++lastIndex < maxLength)
                {
                    if (maxString[lastIndex] > maxString[preIndex + lastIndex])
                        return 1 * state;

                    if (maxString[lastIndex] < maxString[preIndex + lastIndex])
                        return -1 * state;
                }

                for (var index = 0; index < maxLength - 1; index++)
                {
                    if (maxString[index] > maxString[index + 1])
                        return -1 * state;

                    if (maxString[index] < maxString[index + 1])
                        return 1 * state;
                }

                return state * -1;
            }
        }

        [MarkedItem]
        public void MinSubArrayLen()
        {
            MinSubArrayLen(100, new[] {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}).ToConsole();
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            var queue = new Queue<ValueNext>();
            for (var i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(new ValueNext {Value = nums[i], Index = i});
            }

            queue.Enqueue(null);

            for (var index = 0; index < nums.Length && queue.Peek() != null; index++)
            {
                while (queue.Peek() != null)
                {
                    if (queue.Peek().Value == target)
                        return index + 1;

                    var temp = queue.Dequeue();
                    if (temp.Index + 1 >= nums.Length || temp.Value > target)
                        continue;

                    temp.Value += nums[++temp.Index];

                    queue.Enqueue(temp);
                }

                queue.Dequeue();
                queue.Enqueue(null);
            }

            return 0;
        }

        public int MinSubArrayLenⅱ(int target, int[] nums)
        {
            var sum = 0;
            var length = nums.Length + 1;
            var preIndex = 0;
            for (var index = 0; index < nums.Length; index++)
            {
                if (sum == 0)
                    length = Math.Min(length, index - preIndex + 1);

                sum += nums[index];
                while (sum > target && preIndex + 1 < index)
                {
                    sum -= nums[preIndex++];
                }
            }

            return length <= nums.Length ? length : 0;
        }

        public class ValueNext
        {
            public int Value { get; set; }
            public int Index { get; set; }
        } 

        [MarkedItem]
        public void MissingNumber()
        {
            MissingNumber(new[] {1, 2, 3, 5}).ToConsole();
        }

        public int MissingNumber(int[] nums)
        {
            var items = Enumerable.Range(0, nums.Length + 1).ToList();
            foreach (var num in nums)
            {
                items.Remove(num);
            }

            throw new Exception();
        }

        [MarkedItem]
        public void IsUgly()
        {
            IsUgly(10).ToConsole();
        }

        public bool IsUgly(int num)
        {
            if (num < 1)
                return false;
            if (num < 7)
                return true;

            var factors = new List<int> {2, 3, 5};
            var index = 0;
            while (num >= 7)
            {
                if (index == factors.Count)
                    return false;

                if (num%factors[index] == 0)
                {
                    num /= factors[index];
                    continue;
                }

                index++;
            }

            return true;
        }

        public int NthUglyNumber(int n)
        {
            if (n < 0)
                throw new Exception();

            if (n <= 6)
                return n;

            var num = 7;
            var current = 6;
            while (current != n)
            {
                if (IsUgly(num))
                    current++;
                num++;
            }

            return num;
        }

        [MarkedItem]
        public void SerializeAndDeserializeBinaryTree()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node3.left = node4;
            node3.right = node5;

            var codec = new Codec();
            var serializeStr = codec.Serialize(node1);
            serializeStr.ToConsole();

            var deserializeNode = codec.Deserialize(serializeStr);

            codec.Serialize(deserializeNode).ToConsole();
        }

        public class Codec
        {
            public string Serialize(TreeNode root)
            {
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                var builder = new StringBuilder();
                while (queue.Any())
                {
                    var temp = queue.Dequeue();
                    if (temp == null)
                    {
                        builder.Append("#N");
                        continue;
                    }
                    builder.Append("#" + temp.val);
                    queue.Enqueue(temp.left);
                    queue.Enqueue(temp.right);
                }

                return builder.ToString();
            }

            public TreeNode Deserialize(string data)
            {
                if (string.IsNullOrEmpty(data))
                    return null;

                var nodesValue = data.Split('#').Where(x => x != string.Empty).ToArray();
                if (!nodesValue.Any())
                    return null;

                int rootValue;
                if (!int.TryParse(nodesValue.First(), out rootValue))
                    return null;

                var root = new TreeNode(rootValue);
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                for (var index = 1; index < nodesValue.Length; )
                {
                    if (!queue.Any())
                        break;

                    var temp = queue.Dequeue();
                    int value;
                    if (int.TryParse(nodesValue[index++], out value))
                    {
                        var leftNode = new TreeNode(value);
                        temp.left = leftNode;
                        queue.Enqueue(leftNode);
                    }
                    if (int.TryParse(nodesValue[index++], out value))
                    {
                        var rightNode = new TreeNode(value);
                        temp.right = rightNode;
                        queue.Enqueue(rightNode);
                    }
                }

                return root;
            }
        }

        [MarkedItem]
        public void LengthOfLIS()
        {
            LengthOfLIS(new[] {10, 9, 2, 5, 3, 7, 101, 18}).ToConsole();
        }

        public int LengthOfLIS(int[] nums)
        {
            var temp = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                var current = temp.Where(x => x.Key < num);
                if (!current.Any())
                {
                    temp[num] = temp.ContainsKey(num)
                        ? temp[num]
                        : 1;
                    continue;
                }
                var max = current.OrderByDescending(x => x.Value).First();
                temp = temp.Where(x => x.Key > max.Key).ToDictionary(x => x.Key, x => x.Value);
                temp[max.Key] = max.Value + 1;
            }

            return temp.Max(x => x.Value);
        }

        [MarkedItem]
        public void RemoveDuplicateLetters()
        {
            RemoveDuplicateLetters("cbacdcbc").ToConsole();
        }

        public string RemoveDuplicateLetters(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var letterDic = new Dictionary<char, KeyValuePair<int, int>>();
            var index = 0;
            foreach (var c in s)
            {
                index++;
                if (!letterDic.ContainsKey(c))
                    letterDic[c] = new KeyValuePair<int, int>(1, index);

                if (letterDic.ContainsKey(c) && letterDic[c].Key > 1)
                    continue;

                letterDic[c] = new KeyValuePair<int, int>(2, index);
            }

            return string.Concat(letterDic.OrderBy(x => x.Value.Value).Select(x => x.Key));
        }

        [MarkedItem]
        public void NumMatrixTest()
        {
            var matrix = new[,]
            {
                {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5}
            };

            var numMatrix = new NumMatrix(matrix);

            numMatrix.SumRegion(2, 1, 4, 3).ToConsole();
            numMatrix.SumRegion(1, 1, 2, 2).ToConsole();
            numMatrix.SumRegion(1, 2, 2, 4).ToConsole();
        }

        public class NumMatrix
        {
            private readonly Dictionary<string, int> hash = new Dictionary<string, int>();
            private readonly int[,] matrix;

            public NumMatrix(int[,] matrix)
            {
                this.matrix = matrix;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                if (row1 >= row2 || col1 >= col2)
                    return default(int);

                var sum = 0;
                for (var row = row1; row <= row2; row++)
                {
                    var hashCode = string.Format("{0}#{1}#{2}#{3}", row, col1, row, col1);
                    if (hash.ContainsKey(hashCode))
                    {
                        sum += hash[hashCode];
                        continue;
                    }

                    var columnSum = 0;
                    for (var col = col1; col <= col2; col++)
                    {
                        columnSum += matrix[row, col];
                    }

                    sum += columnSum;
                }

                return sum;
            }
        }

        [MarkedItem]
        public void CompareDictionaryDifferent()
        {
            var address1 = "C:\\Users\\WeiNang\\Desktop\\199";
            var address2 = "C:\\Users\\WeiNang\\Desktop\\28";

            var address1Files = GetFileDictionary(address1);
            var address2Files = GetFileDictionary(address2);

            var files = address1Files.Concat(address2Files)
                .GroupBy(item => item.FileName)
                .Where(g => g.Count() != 2)
                .Select(g => g.First())
                .GroupBy(item => item.DictionaryName)
                .ToDictionary(g => g.Key, g => g.Select(item => item.FileName).ToList())
                .ToList();

            var outputAddress = "C:\\Users\\WeiNang\\Desktop\\Different28And199.txt";
            File.WriteAllLines(outputAddress,
                files.SelectMany(file => file.Value
                    .Select(item => string.Format("{0}-{1}", file.Key, item)))
                    .ToArray());
        }

        private static List<FileItem> GetFileDictionary(string address)
        {
            return Directory.GetFiles(address)
                .Select(file =>
                {
                    var items = file.Split('\\');
                    var result = file.Split('\\').Skip(items.Count() - 2).ToList();
                    return new FileItem
                    {
                        DictionaryName = result.First(),
                        FileName = result.Skip(1).First()
                    };
                })
                .ToList();
        }

        public class FileItem
        {
            public string DictionaryName { get; set; }
            public string FileName { get; set; }
        }
    }
}