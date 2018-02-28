using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessmentsvc.Database.Entity
{
    public class Mission:BaseEntity
    {
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Met { get; set; }

    }
}
