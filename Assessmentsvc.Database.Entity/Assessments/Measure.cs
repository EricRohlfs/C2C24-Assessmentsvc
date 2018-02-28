using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class Measure : BaseEntity
    {
        public string Number { get; set; }

        public string Description { get; set; }
        public string Scale { get; set; }

    }
}
