using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Data.DesignPattern.Implement.FilterPattern
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