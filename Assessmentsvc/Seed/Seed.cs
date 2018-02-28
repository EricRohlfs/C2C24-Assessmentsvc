using Assessmentsvc.Database;
using Assessmentsvc.Database.Entity;
using ExcelHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Api
{
    public class Seed
    {
        private AssessmentsContext _context;
        private string _file;
        private DataSet _seedData;

        public Seed(AssessmentsContext context, string file)
        {

            _context = context;
            _file = file;
            _seedData = GetSeedData();
        }

        public void PurgeDatabase()
        {

            _context.Database.ExecuteSqlCommand("DELETE  FROM   METAssessments");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   CapabilityAssessments");

            _context.Database.ExecuteSqlCommand("DELETE  FROM   SortsAssessments");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   PersonnelData");

            _context.Database.ExecuteSqlCommand("DELETE  FROM   AssessmentComments");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   ConditionDescriptors");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   Conditions");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   Measures");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   Missions");

            _context.Database.ExecuteSqlCommand("DELETE  FROM   Tasks");
            _context.Database.ExecuteSqlCommand("DELETE  FROM   Units");

        }
        public DataSet GetSeedData()
        {
            DataSet result;
            ExcelWorkSheetToTable spreadsheet = new ExcelWorkSheetToTable(_file);
            result = spreadsheet.Table;
            return result;
        }

        #region ReferenceData
        public void SeedConditionDescriptorTable()
        {
            DataTable table = _seedData.Tables["ConditionDescriptors"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                ConditionDescriptor conditiondescriptor = new ConditionDescriptor
                {
                    Id = new Guid(columns[0].ToString()),
                    Text = columns[1].ToString()

                };
                _context.ConditionDescriptors.Add(conditiondescriptor);

            }
            _context.SaveChanges();
        }
        public void SeedConditionTable()
        {
            DataTable table = _seedData.Tables["Conditions"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Condition condition = new Condition
                {
                    Id = new Guid(columns[0].ToString()),
                    Number = columns[1].ToString(),
                    Title = columns[2].ToString(),
                    Description = columns[3].ToString()

                };
                _context.Conditions.Add(condition);

            }
            _context.SaveChanges();
        }
        public void SeedMeasureTable()
        {
            DataTable table = _seedData.Tables["Measures"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Measure measure = new Measure
                {
                    Id = new Guid(columns[0].ToString()),
                    Description = columns[1].ToString()
                };
                _context.Measures.Add(measure);

            }
            _context.SaveChanges();
        }
        public void SeedMissionTable()
        {
            DataTable table = _seedData.Tables["Missions"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Mission mission = new Mission
                {
                    Id = new Guid(columns[0].ToString()),
                    Description = columns[1].ToString(),
                    Abbreviation = columns[2].ToString(),
                    Name = columns[3].ToString()
                };
                _context.Missions.Add(mission);

            }
            _context.SaveChanges();
        }

        public void SeedTaskTable()
        {
            DataTable table = _seedData.Tables["Tasks"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Assessmentsvc.Database.Entity.Task task = new Assessmentsvc.Database.Entity.Task
                {
                    Id = new Guid(columns[0].ToString()),
                    Title = columns[1].ToString(),
                    Description = columns[2].ToString(),
                    Number = columns[3].ToString(),
                };
                _context.Tasks.Add(task);

            }
            _context.SaveChanges();
        }

        public void SeedUnitTable()
        {
            DataTable table = _seedData.Tables["Units"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Unit unit = new Unit { Id = new Guid(columns[0].ToString()), Uic = columns[1].ToString(), Name = columns[2].ToString() };
                _context.Units.Add(unit);

            }
            _context.SaveChanges();
        }

        #endregion ReferenceData


        public void SeedReferenceData()
        {
            SeedConditionDescriptorTable();
            SeedConditionTable();
            SeedMeasureTable();
            SeedMissionTable();

            SeedTaskTable();
            SeedUnitTable();

        }
        public Unit GetUnit(Guid unitId)
        {
            DataTable units = _seedData.Tables["Units"];
            Unit unit = null;
            DataRow row = units.Select("Id = '" + unitId.ToString() + "'").FirstOrDefault<DataRow>();
            if (row != null)
            {
                unit = new Unit()
                {
                    Id = new Guid(row[0].ToString()),
                    Uic = row[1].ToString(),
                    Name = row[2].ToString()

                };

            }

            return unit;
        }

        public Mission GetMission(Guid missionId)
        {
            DataTable missions = _seedData.Tables["Missions"];
            Mission mission = null;
            DataRow row = missions.Select("Id = '" + missionId.ToString() + "'").FirstOrDefault<DataRow>();
            if (row != null)
            {
                mission = new Mission()
                {
                    Id = new Guid(row[0].ToString()),
                    Description = row[1].ToString(),
                    Abbreviation = row[2].ToString(),
                    Name = row[3].ToString()

                };

            }
            return mission;
        }

        public Assessmentsvc.Database.Entity.Task GetTask(Guid taskId)
        {
            DataTable tasks = _seedData.Tables["Tasks"];
            Assessmentsvc.Database.Entity.Task task = null;
            DataRow row = tasks.Select("Id = '" + taskId.ToString() + "'").FirstOrDefault<DataRow>();
            if (row != null)
            {
                task = new Assessmentsvc.Database.Entity.Task()
                {
                    Id = new Guid(row[0].ToString()),
                    Title = row[1].ToString(),
                    Description = row[2].ToString(),
                    Number = row[3].ToString()


                };

            }
            return task;
        }

        public AssessmentComment GetAssessmentComment(string assessmentCommentId)
        {
            DataTable assessmentComments = _seedData.Tables["AssessmentComments"];
            AssessmentComment comment = null;
            DataRow row = assessmentComments.Select("Id = '" + assessmentCommentId + "'").FirstOrDefault<DataRow>();
            if (row != null)
            {
                comment = new AssessmentComment()
                {
                    Id = new Guid(row[0].ToString()),
                    Personnel = row[1].ToString(),
                    Equipment = row[2].ToString(),
                    Supply = row[3].ToString(),
                    Training = row[4].ToString(),
                    Ordnance = row[5].ToString(),
                    Facility = row[6].ToString(),
                    Overall = row[7].ToString()
                };


            }
            return comment;
        }



        public void SeedMetAssessments()
        {
            DataTable table = _seedData.Tables["METAssessment"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Guid CapabilityId = new Guid(columns[0].ToString());



                METAssessment metAssessment = new METAssessment
                {
                    CapabilityAssessmentId = new Guid(columns[0].ToString()),
                    METAssessmentId = new Guid(columns[1].ToString()),
                    Description = columns[2].ToString(),
                    Abbreviation = columns[3].ToString(),
                    Name = columns[4].ToString(),
                    Status = columns[5].ToString(),
                    Assessed = (DateTime)columns[6],
                    Achieved = columns[7].ToString(),
                    Current = columns[8].ToString(),
                    Next = columns[9].ToString(),
                    Personnel = Convert.ToInt32(columns[10]),
                    Equipment = Convert.ToInt32(columns[11]),
                    Supply = Convert.ToInt32(columns[12]),
                    Training = Convert.ToInt32(columns[13]),
                    Ordnance = Convert.ToInt32(columns[14]),
                    Overall = Convert.ToInt32(columns[15])
 
                 };
                _context.METAssessments.Add(metAssessment);
            }
            _context.SaveChanges();
        }

        private CapabilityAssessment GetCapability(Guid capabilityId)
        {
            DataTable capabiltyAssessments = _seedData.Tables["CapabilityAssessment"];
            CapabilityAssessment capabilityAssessment = null;
            DataRow row = capabiltyAssessments.Select("Id = '" + capabilityId.ToString() + "'").FirstOrDefault<DataRow>();
            if (row != null)
            {
                capabilityAssessment = new CapabilityAssessment()
                {
                    CapabilityAssessmentId = new Guid(row[0].ToString()),
                    Description = row[1].ToString(),
                    Abbreviation = row[2].ToString(),
                    Name = row[3].ToString(),
                    Status = row[4].ToString(),
                    Assessed = (DateTime)row[5],
                    Achieved = row[6].ToString(),
                    Current = row[7].ToString(),
                    Next = row[8].ToString(),
                    Personnel = Convert.ToInt32(row[9]),
                    Equipment = Convert.ToInt32(row[10]),
                    Supply = Convert.ToInt32(row[11]),
                    Training = Convert.ToInt32(row[12]),
                    Ordnance = Convert.ToInt32(row[13]),
                    Overall = Convert.ToInt32(row[14])
                };

            }
            return capabilityAssessment;
        }

        public void SeedSorts()
        {
            DataTable table = _seedData.Tables["Sorts"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;


                Sorts sortsAssessment = new Sorts
                {
                    
                    Personnel = Convert.ToInt32(columns[0]),
                    Equipment = Convert.ToInt32(columns[1]),
                    Supply = Convert.ToInt32(columns[2]),
                    Training = Convert.ToInt32(columns[3]),
                    Ordnance = Convert.ToInt32(columns[4]),
                    Overall = Convert.ToInt32(columns[5]),
                    Category = columns[6].ToString(),
                    Code = columns[7].ToString(),
                    Status = columns[8].ToString(),
                    Organization = columns[9].ToString(),
                    Embarked = columns[10].ToString(),
                    Effectivity = Convert.ToInt32(columns[11]),
                    Level = Convert.ToInt32(columns[12]),
                    Limitation = Convert.ToInt32(columns[13]),
                    ADCON = columns[14].ToString(),
                    OPCON = columns[15].ToString(),
                    Latitude = columns[16].ToString(),
                    Longitude = columns[17].ToString(),
                    CBRCurrent = columns[18].ToString(),
                    CBRProjected = columns[19].ToString(),
                    CBRTraining = columns[20].ToString()
              };
                _context.SortsAssessments.Add(sortsAssessment);
            }
            _context.SaveChanges();
        }

        private void SeedCapabilityAssessment()
        {
            DataTable table = _seedData.Tables["CapabilityAssessment"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;

                Guid CapabilityId = new Guid(columns[0].ToString());



                CapabilityAssessment capabilityAssessment = new CapabilityAssessment
                {
                    Id = CapabilityId,
                    CapabilityAssessmentId = CapabilityId,
                    Description = columns[1].ToString(),
                    Abbreviation = columns[2].ToString(),
                    Name = columns[3].ToString(),
                    Status = columns[4].ToString(),
                    Assessed = (DateTime)columns[5],
                    Achieved = columns[6].ToString(),
                    Current = columns[7].ToString(),
                    Next = columns[8].ToString(),
                    Personnel = Convert.ToInt32(columns[9]),
                    Equipment = Convert.ToInt32(columns[10]),
                    Supply = Convert.ToInt32(columns[11]),
                    Training = Convert.ToInt32(columns[12]),
                    Ordnance = Convert.ToInt32(columns[13]),
                    Overall = Convert.ToInt32(columns[14])

                };
                _context.CapabilityAssessments.Add(capabilityAssessment);
            }
            _context.SaveChanges();
        }

        private void SeedPersonnelData()
        {
            DataTable table = _seedData.Tables["Personnel"];
            int rowcount = table.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                object[] columns = table.Rows[i].ItemArray;


                Personnel personnel = new Personnel()
                {
                    Id = new Guid(),
                    Type = columns[0].ToString(),
                    Structured = Convert.ToInt32(columns[1]),
                    Authorized = Convert.ToInt32(columns[2]),
                    Assigned = Convert.ToInt32(columns[3]),
                    Possessed = Convert.ToInt32(columns[4])
                };
                _context.PersonnelData.Add(personnel);
            }
            _context.SaveChanges();
        }



        public void SeedDatabase()
        {
          
            PurgeDatabase();
            
            SeedReferenceData();
            SeedSorts();
            SeedPersonnelData();
            SeedCapabilityAssessment();
            SeedMetAssessments();

            _context.SaveChanges();
          }

    }
}
