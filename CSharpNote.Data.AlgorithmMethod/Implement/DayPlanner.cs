using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class DayPlanner : AbstractExecuteModule
    {
        [AopTarget(@"http://community.topcoder.com/stat?c=problem_statement&pm=4637")]
        public override void Execute()
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
    }
}