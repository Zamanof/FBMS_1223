using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_relationship.Entities
{
    internal class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
            => Name;
    }
}
