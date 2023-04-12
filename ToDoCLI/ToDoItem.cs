using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCLI
{
    class ToDoItem : IComparable<ToDoItem>
    {
        public int Id { get; set; }
        public bool Finished { get; set; }
        public string Description { get; set ; }

        public int CompareTo(ToDoItem other)
        {
            if (other is null)
                return -1;
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id,4} - {(Finished ? "OK" : "Pending"),10} - {Description}";
        }
    }
}
