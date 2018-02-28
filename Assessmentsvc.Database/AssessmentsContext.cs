
using Assessmentsvc.Database.Entity;
using Microsoft.EntityFrameworkCore;
namespace Assessmentsvc.Database
{
    public class AssessmentsContext : DbContext
    {
        public AssessmentsContext(DbContextOptions<AssessmentsContext> options) : base(options)
        {

        }
         public DbSet<Assessmentsvc.Database.Entity.AssessmentComment> AssessmentComments { get; set; }       
        public DbSet<Assessmentsvc.Database.Entity.ConditionDescriptor> ConditionDescriptors { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Condition> Conditions { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Measure> Measures { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Mission> Missions { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Task> Tasks { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Unit> Units { get; set; }

        public DbSet<Assessmentsvc.Database.Entity.Sorts> SortsAssessments { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.METAssessment> METAssessments { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.Personnel> PersonnelData { get; set; }
        public DbSet<Assessmentsvc.Database.Entity.CapabilityAssessment> CapabilityAssessments { get; set; }





 

    }
}
