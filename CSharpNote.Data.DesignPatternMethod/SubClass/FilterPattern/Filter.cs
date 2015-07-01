using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FilterPattern
{
    public class AddressTaiwanFilter : IFilter<Address>
    {
        public IEnumerable<Address> Filter(IEnumerable<Address> source)
        {
            return source.Where(address => address.Contry == "Taiwan");
        }
    }

    public class AddresskaohsiungFilter : IFilter<Address>
    {
        public IEnumerable<Address> Filter(IEnumerable<Address> source)
        {
            return source.Where(address => address.City == "Kaushoung");
        }
    }
}
