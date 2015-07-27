using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPattern.Implement.StretagyPattern
{
    public class StrategyA : StrategyBase
    {
        private string Strategy001()
        {
            return "Strategy001";
        }

        private string Strategy002()
        {
            return "Strategy002";
        }

        private string Strategy003()
        {
            return "Strategy003";
        }
    }

    public class StrategyB : StrategyBase
    {
        private string Strategy001()
        {
            return "Strategy001";
        }

        private string Strategy002()
        {
            return "Strategy002";
        }

        private string Strategy003()
        {
            return "Strategy003";
        }
    }
}
