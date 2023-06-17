using SixDegreesIT.Core;

namespace SixDegreesIT.Infrastructure.Data
{

    public static class SeedData
    {
        public static void Initialize(PersonDBContext db)
        {
            Person[] data = new[]
            {
                new Person()
                {
                    Name = "Archibald",
                    SurName = "Beaker"
                },
                new Person()
                {                   
                    Name = "Yasmin",
                    SurName = "Cotton"
                },
                new Person()
                {
                    Name = "Luke",
                    SurName = "Peterson"
                },
                new Person()
                {
                    Name = "Farrago",
                    SurName = "Rivers"
                },
                new Person()
                {
                    Name = "Marcie",
                    SurName = "Savage"
                }
            };

            db.Persons.AddRange(data);

            db.SaveChanges();
        }
    }
}