using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CQRSPattern
{
    public class Message
    {
        public Message(int id, string content)
        {
            this.Id = id;
            this.Content = content;
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public void Publish()
        { 
        }
    }
}
