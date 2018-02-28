using System;

namespace Assessmentsvc.Database.Entity
{
    public class Sorts : BaseEntity
    {
        public int Personnel { get; set; }
        public int Equipment { get; set; }
        public int Supply { get; set; }
        public int Training { get; set; }
        public int Ordnance { get; set; }
        public int Overall { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string Organization { get; set; }
        public string Embarked { get; set; }
        public int Effectivity { get; set; }
        public int Level { get; set; }
        public int Limitation { get; set; }
        public string ADCON { get; set; }
        public string OPCON { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CBRCurrent { get; set; }
        public string CBRProjected { get; set; }
        public string CBRTraining { get; set; }
    }
}
