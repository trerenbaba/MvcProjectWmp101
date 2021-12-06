using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcProjectWmp101.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseCreator());
        }

    }
    public class DatabaseCreator : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //Initialize database ==> Database oluşmadan önce yapılması gereken işlemleri eklemek için kullanılır.
        public override void InitializeDatabase(DatabaseContext context)
        {
            base.InitializeDatabase(context);
        }

        //Seed Database ==> database oluştuktan sonra eklenmesi gereken işlemler için kullanılır.
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Persons per = new Persons();
                per.Name = FakeData.NameData.GetFirstName();
                per.SurName = FakeData.NameData.GetSurname();
                per.Age = FakeData.NumberData.GetNumber(10,99);
                context.Persons.Add(per);
            }

            List<Persons> AllPersons = context.Persons.ToList();

            foreach (Persons person in AllPersons)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Addresses adr = new Addresses();
                    adr.Description = FakeData.PlaceData.GetAddress();
                    adr.City = FakeData.PlaceData.GetCity();
                    adr.Persons = person;
                    context.Addresses.Add(adr);
                }

            }
            context.SaveChanges();
        }
    }
}