using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace darwinGameV1
{
    internal class Event
    {
        string name;
        string description;
        public Event(string name, string desc)
        {
            this.name = name;
            this.description = desc;
        }

        public String EventName()
        {
            return name;
        }

        public String Description()
        {
            return description;
        }

    }
}
