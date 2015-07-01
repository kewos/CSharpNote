using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.StretagyPattern
{
    public class StrategyA : StrategyBase
    {
        public StrategyA() : base()
        {
        }

        private string Strategy001()
        {
            return string.Format("Strategy001");
        }

        private string Strategy002()
        {
            return string.Format("Strategy002");
        }

        private string Strategy003()
        {
            return string.Format("Strategy003");
        }
    }

    public class StrategyB : StrategyBase
    {
        public StrategyB()
            : base()
        {
        }

        private string Strategy001()
        {
            return string.Format("Strategy001");
        }

        private string Strategy002()
        {
            return string.Format("Strategy002");
        }

        private string Strategy003()
        {
            return string.Format("Strategy003");
        }
    }
}
