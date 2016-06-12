using Recruitement.Domain.Entities;
using Recruitement.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Infrastructure
{
    public class RecruitementInitializer : DropCreateDatabaseIfModelChanges<RecruitementContext>
    {
        protected override void Seed(RecruitementContext context)
        {
            //Personal admin = new Personal
            //{
            //    FirstName = "schellenger",
            //    LastName = "arctic"
            //    ,
            //    Email = "iheb.kacem@hotmail.com",
            //    Password = "player2015"
            //    ,
            //    ConfirmePassword = "player2015"
            //};

            //context.Personals.Add(admin);
            //context.SaveChanges();
        }
    }
}
