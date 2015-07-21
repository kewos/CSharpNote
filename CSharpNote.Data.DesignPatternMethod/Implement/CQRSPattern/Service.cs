using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CQRSPattern
{
    public interface IService
    { 
    }

    public class CheckCommandService : IService
    {
        public bool CheckContent(string content)
        {
            return true;
        }
    }
}
