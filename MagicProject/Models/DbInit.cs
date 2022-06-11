using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MagicProject.Models
{
    public class DbInit : DropCreateDatabaseIfModelChanges<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {
            base.Seed(context);

            var professiya = new List<Profes>
            {
                new Profes{ID = "D", Name = "Программист"},
                 new Profes{ID = "T", Name = "Тестировщик"},
                  new Profes{ID = "P", Name = "проект-манаж"},
                   new Profes{ID = "S", Name = "манеждер-по"},
            };
            professiya.ForEach(s => context.Profeses.Add(s));
            context.SaveChanges();

            var zaynits = new List<Zaynit>
            {
                new Zaynit{ID = "F", Name = "полный день"},
                 new Zaynit{ID = "H", Name = "половина дня"},
                  new Zaynit{ID = "P", Name = "проект"},
                   new Zaynit{ID = "A", Name = "договор"},
            };
            zaynits.ForEach(a => context.Zaynits.Add(a));
            context.SaveChanges();

            var forms = new List<Form>
            {
                new Form{ID = "O", Name = "офис"},
                 new Form{ID = "R", Name = "удаленная "},
                  new Form{ID = "OR", Name = "смешенная "},
            };
            forms.ForEach(s => context.Forms.Add(s));
            context.SaveChanges();

            var positions = new List<Position>
            {
                new Position{ID = "J", Name = "junior"},
                 new Position{ID = "M", Name = "middle"},
                  new Position{ID = "S", Name = "senior"},
            };
            positions.ForEach(s => context.Positions.Add(s));
            context.SaveChanges();




        }
    }
}