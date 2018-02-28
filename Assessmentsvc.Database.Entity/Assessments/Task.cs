using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
       
        public ICollection<Condition> Conditions { get; set; }
        public ICollection<Measure> Standards { get; set; }
    }
}
