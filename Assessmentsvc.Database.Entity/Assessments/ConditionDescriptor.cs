using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class ConditionDescriptor : BaseEntity
    {
        public string Text { get; set; }

    }
}
