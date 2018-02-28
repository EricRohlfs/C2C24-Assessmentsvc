using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Entity
{
    public class CapabilityAssessment: BaseEntity
    {
        public Guid CapabilityAssessmentId { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Assessed { get; set; }
        public string Achieved { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
        public int Personnel { get; set; }
        public int Equipment { get; set; }
        public int Supply { get; set; }
        public int Training { get; set; }
        public int Ordnance { get; set; }
        public int Overall { get; set; }

        public List<METAssessment> METAssessments { get; set; }
    }
}
