using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models.Manager
{
    public class StudentsDatabaseContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }

        public StudentsDatabaseContext()
        {
            Database.SetInitializer(new StudentsDatabaseCreator());
        }
    }

    public class StudentsDatabaseCreator : CreateDatabaseIfNotExists<StudentsDatabaseContext>
    {
        public override void InitializeDatabase(StudentsDatabaseContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(StudentsDatabaseContext contex)
        {
            for (int i = 0; i < 10; i++)
            {
                Classes cls = new Classes();
                cls.ClassName = FakeData.NameData.GetCompanyName();
                contex.Classes.Add(cls);
            }
            contex.SaveChanges();

            List<Classes> AllClasses = contex.Classes.ToList();

            foreach (Classes cls in AllClasses)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,12); i++)
                {
                    Students students = new Students();
                    students.Name = FakeData.NameData.GetFirstName();
                    students.Surname = FakeData.NameData.GetSurname();
                    students.StudentNumber = FakeData.NumberData.GetNumber(999);
                    students.Classes = cls;
                    contex.Students.Add(students);

                }
            }
            contex.SaveChanges();
        }
       
    }
    

}