using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.ProjectMethod.Validation
{
    /// <summary>
    /// 驗証規則
    /// </summary>
    public class ValidatioinRule
    {
        private Dictionary<RuleTitle, Func<IEnumerable<char>, bool>> validationTypes;

        public ValidatioinRule()
        {
            validationTypes = new Dictionary<RuleTitle, Func<IEnumerable<char>, bool>>
            {
                { RuleTitle.English, IsEnglish },
                { RuleTitle.NotEnglish, IsNotEnglish },
                { RuleTitle.Number, IsNumber },
                { RuleTitle.NotNumber, IsNotNumber }
            };
        }

        public Func<IEnumerable<char>, bool> this[RuleTitle key]
        {
            get
            {
                return validationTypes.ContainsKey(key)
                    ? validationTypes[key]
                    : null;
            }
        }

        private bool IsEnglish(IEnumerable<char> code)
        {

            return code.All(@char => (@char >= 65 && @char <= 90) || (@char >= 97 && @char <= 122));
        }

        private bool IsNumber(IEnumerable<char> code)
        {
            return code.All(@char => @char >= 48 && @char <= 57);
        }

        private bool IsNotNumber(IEnumerable<char> code)
        {
            return !IsNumber(code);
        }

        private bool IsNotEnglish(IEnumerable<char> code)
        {
            return !IsEnglish(code);
        }
    }
}
