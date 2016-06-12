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
    public class RewardService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Reward> GetRewards()
        {
            return utOfWork.RewardRepository.GetAll().ToList();
        }

        public Reward GetReward(int id)
        {
            return utOfWork.RewardRepository.GetById(id);
        }

        public Boolean CreateReward(Recruitement.Domain.Entities.Reward a)
        {
            bool t;
            try
            {
                utOfWork.RewardRepository.Add(a);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
            
        }

        public Boolean UpdateReward(Recruitement.Domain.Entities.Reward a)
        {
            bool t;
            try
            {
                utOfWork.RewardRepository.Update(a);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteReward(int i)
        {
            bool t;
            try
            {
                utOfWork.RewardRepository.Delete(i);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }
    }
    }

