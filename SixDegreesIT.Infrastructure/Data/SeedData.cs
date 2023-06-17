using SixDegreesIT.Core;

namespace SixDegreesIT.Infrastructure.Data
{

    public static class SeedData
    {
        public static void Initialize(PruebaSDDBContext db)
        {
            PruebasSD[] data = new[]
            {
                new PruebasSD()
                {
                    Name = "Archibald",
                    SurName = "Beaker"
                },
                new PruebasSD()
                {                   
                    Name = "Yasmin",
                    SurName = "Cotton"
                },
                new PruebasSD()
                {
                    Name = "Luke",
                    SurName = "Peterson"
                },
                new PruebasSD()
                {
                    Name = "Farrago",
                    SurName = "Rivers"
                },
                new PruebasSD()
                {
                    Name = "Marcie",
                    SurName = "Savage"
                }
            };

            db.PruebasSDs.AddRange(data);

            db.SaveChanges();
        }
    }
}