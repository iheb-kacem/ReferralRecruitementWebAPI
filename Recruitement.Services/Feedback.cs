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
    
    public class FeedbackService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Feedback> GetFeedback()
        {
            return utOfWork.FeedbackRepository.GetAll().ToList();
        }

        public Feedback GetFeedback(int id)
        {
            return utOfWork.FeedbackRepository.GetById(id);
        }

        public Boolean CreateFeedback(Recruitement.Domain.Entities.Feedback f)
        {
            utOfWork.FeedbackRepository.Add(f);
            if (utOfWork.Commit())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateFeedback(Recruitement.Domain.Entities.Feedback f)
        {

            utOfWork.FeedbackRepository.Update(f);
            utOfWork.Commit();
        }

        public void DeleteFeedback(int i)
        {
            utOfWork.FeedbackRepository.Delete(i);
            utOfWork.Commit();
        }
    }
}