using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class AssessmentComment : BaseEntity
    {
        
        public string Personnel { get; set; }
        public string Equipment { get; set; }
        public string Supply { get; set; }
        public string Training { get; set; }
        public string Ordnance { get; set; }
        public string Facility { get; set; }
        public string Overall { get; set; }
    
    }
}
