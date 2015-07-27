using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
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
