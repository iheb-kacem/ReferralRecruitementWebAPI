using Recruitement.Data.Contracts;
using Recruitement.Data.Infrastructure;
using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Services
{
   public class ApplicationService
   {
       static DatabaseFactory dbFactory = new DatabaseFactory();
       IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

       public IEnumerable<Application> GetApplication()
       {
           return utOfWork.ApplicationRepository.GetAll().ToList();
       }

       public Application GetApplication(int id)
       {
           return utOfWork.ApplicationRepository.GetById(id);
       }

       public Boolean CreateApplication(Recruitement.Domain.Entities.Application ap)
       {
           utOfWork.ApplicationRepository.Add(ap);
           if (utOfWork.Commit())
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public void UpdateApplication(Recruitement.Domain.Entities.Application ap)
       {
           
           utOfWork.ApplicationRepository.Update(ap);
           utOfWork.Commit();
       }

       public void DeleteApplication(int i)
       {
           utOfWork.ApplicationRepository.Delete(i);
           utOfWork.Commit();
       }
   }
}

