namespace Nipema.Tyonohjaus.EF
{
    using System.Data.Entity.Migrations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using Nipema.Tyonohjaus.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TyonohjausDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TyonohjausDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.ProductPropertyDescriptions.AddOrUpdate(
              p => p.Id,
              new ProductPropertyDescription { Id = 1, Description = "Kuvaus" },
              new ProductPropertyDescription { Id = 2, Description = "Tuotekuva" },
              new ProductPropertyDescription { Id = 3, Description = "Väri" },
              new ProductPropertyDescription { Id = 4, Description = "Paino" },
              new ProductPropertyDescription { Id = 5, Description = "Varastopaikka" },
              new ProductPropertyDescription { Id = 6, Description = "Ripustusmäärä" },
              new ProductPropertyDescription { Id = 7, Description = "Uunitusaika" },
              new ProductPropertyDescription { Id = 8, Description = "Pesupaine" },
              new ProductPropertyDescription { Id = 9, Description = "Maalauskierto" },
              new ProductPropertyDescription { Id = 10, Description = "Maalausresepti" }
            );

            context.TyoDescriptions.AddOrUpdate(
              t => t.DescriptionId,
              new TyoDescription { DescriptionId = 1, Description = "Määrä" },
              new TyoDescription { DescriptionId = 2, Description = "Väri" },
              new TyoDescription { DescriptionId = 3, Description = "Työkoodi" }
            );

            //Kieliasetus
            var lang = (from s in context.Settings
                        where s.Description == "Language"
                        select s.Value).FirstOrDefault();
            if (lang == null)
            {
                context.Settings.Add(new Setting()
                {
                    Description = "Language",
                    Value = "fi-FI"
                });
            }

            //Linjan suunta
            var direction = (from s in context.Settings
                        where s.Description == "Direction"
                        select s.Value).FirstOrDefault();
            if (direction == null)
            {
                context.Settings.Add(new Setting()
                {
                    Description = "Direction",
                    Value = "clockwise"
                });
            }

            //Pesupainevalinta
            var pesupaine2 = (from s in context.Settings
                             where s.Description == "Pesupaine2"
                             select s.Value).FirstOrDefault();
            if (pesupaine2 == null)
            {
                context.Settings.Add(new Setting()
                {
                    Description = "Pesupaine2",
                    Value = "max bar"
                });
            }

            //Uunitusaikavalinta
            var uunitusaika2 = (from s in context.Settings
                              where s.Description == "Uunitusaika2"
                              select s.Value).FirstOrDefault();
            if (uunitusaika2 == null)
            {
                context.Settings.Add(new Setting()
                {
                    Description = "Uunitusaika2",
                    Value = "50"
                });
            }

            string json = System.Text.Encoding.UTF8.GetString(Nipema.Tyonohjaus.EF.Properties.Resources.colors);

            dynamic stuff = JsonConvert.DeserializeObject(json);
            List<Vari> myList = new List<Vari>();
            foreach (var o in stuff)
            {
                string x = o.Value.ToString();
                Vari jc = JsonConvert.DeserializeObject<Vari>(x);
                myList.Add(jc);
            }

            context.Varit.AddOrUpdate(
                v => v.code,
                myList.ToArray()
            );
        }
    }

}
