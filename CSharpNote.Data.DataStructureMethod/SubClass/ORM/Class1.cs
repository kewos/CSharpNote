using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpNote.Common.Utility.DB;

namespace CSharpNote.Data.DataStructureMethod.SubClass.ORM
{
    public class CustomerFactory
    {
        public List<Dictionary<string, string>> GetCustoms()
        {
            return new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"CustomerID", "1"},
                    { "CompanyName", "1"},
                    { "ContactName", "1"},
                    { "ContactTitle", "1"},
                    { "Address", "1"},
                    { "City", "1"},
                    { "Region", "1"},
                    { "PostalCode", "1"},
                    { "Country", "1"},
                    { "Phone", "1"},
                    { "Fax", "1"},
                },
                new Dictionary<string, string>
                {
                    {"CustomerID", "1"},
                    { "CompanyName", "1"},
                    { "ContactName", "1"},
                    { "ContactTitle", "1"},
                    { "Address", "1"},
                    { "City", "1"},
                    { "Region", "1"},
                    { "PostalCode", "1"},
                    { "Country", "1"},
                    { "Phone", "1"},
                    { "Fax", "1"},
                }
            };
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public int CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
