using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class Condition : BaseEntity
    {
         public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ConditionDescriptor ConditionDescriptor { get; set; }

    }
}
