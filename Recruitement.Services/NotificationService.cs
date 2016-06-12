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
    public class NotificationService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);
        public IEnumerable<Notification> GetNotifications()
        {
            return utOfWork.NotificationRepository.GetAll().ToList();
        }
        public Notification GetNotification(int id)
        {
            return utOfWork.NotificationRepository.GetById(id);
        }
        public Boolean CreateNotification(Recruitement.Domain.Entities.Notification n)
        {
            bool t;
            try
            {
                utOfWork.NotificationRepository.Add(n);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;

        }
        public Boolean UpdateNotification(Recruitement.Domain.Entities.Notification n)
        {
            bool t;
            try
            {
                
                utOfWork.NotificationRepository.Update(n);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteNotification(int i)
        {
            bool t;
            try
            {
                utOfWork.NotificationRepository.Delete(i);
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
