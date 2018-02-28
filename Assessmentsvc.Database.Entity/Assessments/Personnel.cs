using System;
namespace Assessmentsvc.Database.Entity
{
    public class Personnel:BaseEntity
    {
        public string Type { get; set; }
        public int Structured { get; set; }
        public int Authorized { get; set; }
        public int Assigned { get; set; }
        public int Possessed { get; set; }
    }
}
