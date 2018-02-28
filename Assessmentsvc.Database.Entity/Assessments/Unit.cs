using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class Unit : BaseEntity
    {
        public string Uic { get; set; }
        public string Name { get; set; }
    }
}
