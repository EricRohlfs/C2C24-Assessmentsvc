using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessmentsvc.Database.Entity
{
    public class UnitMissionAssessment : BaseEntity
    {
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public Guid MissionId { get; set; }
        public Mission Mission { get; set; }
        public string Rating { get; set; }
        public DateTime DateAssessed { get; set; }
        public bool Approved { get; set; }
        
        public AssessmentComment Comment { get; set; }

    }
}
