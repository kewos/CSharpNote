using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Data.Project.Implement.Validation
{
    /// <summary>
    /// 驗証幫手
    /// </summary>
    public class ValidationHelper
    {
        #region Field
        private readonly List<ValidationRecord> validationRecords;
        private ValidatioinRule validatioinRule;
        private ValidationSequenceComponent validationSequenceComponent;
        #endregion

        #region Constructor
        public ValidationHelper(List<ValidationRecord> validationRecords)
        {
            this.validationRecords = validationRecords;
        }
        #endregion

        #region Property
        private ValidationSequenceComponent ValidationOperator
        {
            get
            {
                if (validationSequenceComponent == null)
                {
                    validationSequenceComponent = new ValidationSequenceComponent();
                }

                return validationSequenceComponent;
            }
        }

        private ValidatioinRule RuleOpertator
        {
            get
            {
                if (validatioinRule == null)
                {
                    validatioinRule = new ValidatioinRule();
                }

                return validatioinRule;
            }
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 驗証
        /// </summary>
        /// <param name="code">LotCode</param>
        /// <returns>是否通過驗証</returns>
        private bool Validation(string code)
        {
            return validationRecords.Where(v => !v.IsReturn)
                .All(record => MakeValidation(record)(code));
        }

        /// <summary>
        /// 製作驗証流程樣版
        /// </summary>
        /// <param name="record"></param>
        /// <returns>驗証流程樣版</returns>
        private Func<IEnumerable<char>, bool> MakeValidation(ValidationRecord record)
        {
            return (code) =>
            {
                code = ValidationOperator.BeforeNotification(record, code);
                code = ValidationOperator.AfterNotification(record, code);
                code = ValidationOperator.Reverse(record, code);
                code = ValidationOperator.Skip(record, code);
                code = ValidationOperator.Take(record, code);

                return ValidationType(record, code);
            };
        }

        /// <summary>
        /// 製作轉換簡碼流程樣版
        /// </summary>
        /// <param name="record"></param>
        /// <returns>轉換簡碼樣版</returns>
        private Func<IEnumerable<char>, int> MakeParse(ValidationRecord record)
        {
            return (code) =>
            {
                code = ValidationOperator.BeforeNotification(record, code);
                code = ValidationOperator.AfterNotification(record, code);
                code = ValidationOperator.Reverse(record, code);
                code = ValidationOperator.Skip(record, code);
                code = ValidationOperator.Take(record, code);
                code = ValidationOperator.ReverseTake(record, code);

                return ValidationType(record, code) ? ValidationOperator.Return(record, code) : -1;
            };
        }

        /// <summary>
        /// 驗証型別
        /// </summary>
        private bool ValidationType(ValidationRecord record, IEnumerable<char> code)
        {
            var rule = RuleOpertator[record.Type];

            return rule != null && rule.Invoke(code);
        }
        #endregion

        #region PublicMethod
        /// <summary>
        /// LotCode轉換成簡碼
        /// </summary>
        /// <param name="code">LotCode</param>
        /// <returns>簡碼</returns>
        public int Parse(string code)
        {
            var parseItem = validationRecords.FirstOrDefault(v => v.IsReturn);

            return parseItem != null && Validation(code) 
                ? MakeParse(parseItem)(code) 
                : -1;
        }
        #endregion
    }
}
