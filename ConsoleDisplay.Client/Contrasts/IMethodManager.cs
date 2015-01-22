using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDisplay.Data.Contracts;

namespace ConsoleDisplay.Client.Contrasts
{
    public interface IMethodManager
    {
        /// <summary>
        /// 呈現方法清單
        /// </summary>
        /// <param name="repository">執行的方案</param>
        void Display(IMethodRepository repository);
    }
}
