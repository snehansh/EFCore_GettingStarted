using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurais();
            //InsertMultipleDifferentObjects();
            //SimpleSamuraiQuery();
            MoreQueries();
        }

        #region Insert
        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "SA" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                //context.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Sneh" };
            var samuraiSammy = new Samurai { Name = "Ravi" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurai, samuraiSammy);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleDifferentObjects()
        {
            var samurai = new Samurai { Name = "Oda Nobunaga" };
            var battle = new Battle
            {
                Name = "Battle of Nagashino",
                StartDate = new DateTime(1575, 06, 16),
                EndDate = new DateTime(1575, 06, 28)
            };
            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }
        #endregion

        #region Query
        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
                Console.ReadKey();
            }
        }

        private static void MoreQueries()
        {
            //var samurais = _context.Samurais.Where(s => s.Name == "Sneh").ToList();
            //var name = "Sneh";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            //var samurai = _context.Samurais.Where(s => s.Name == name).FirstOrDefault();

            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);

            //var samurai = _context.Samurais.Find(2);
            //var samurais =
            //    _context.Samurais
            //    .Where(s => EF.Functions.Like(s.Name, "S%")).ToList();

            //var search = "S%";
            //var samurais =
            //    _context.Samurais
            //    .Where(s => EF.Functions.Like(s.Name, search)).ToList();

            // OrderBy is important before LastOrDefault
            var name = "Sneh";
            var lastSneh = 
                _context.Samurais.
                OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);

        }

        #endregion


    }
}
