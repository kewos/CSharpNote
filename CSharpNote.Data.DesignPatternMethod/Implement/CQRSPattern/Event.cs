using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CQRSPattern
{
    public interface IEvent
    { 
    }

    public class Event : IEvent
    {
        public Event(int id, string content)
        {
            this.Id = id;
            this.Content = content;
        }

        public string Content { get; set; }
        public int Id { get; set; }
    }
}
