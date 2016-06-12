using Recruitement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationRepository ApplicationRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IOfferRepository OfferRepository { get; }
        IPersonalRepository PersonalRepository { get; }
        IRewardRepository RewardRepository { get; }
        ITenancyRepository TenancyRepository { get; }
        IAdministratorRepository AdministratorRepository { get; }
        ISuperuserRepository SuperuserRepository { get; }
        IRecruiterRepository RecruiterRepository { get; }
        IReferralRepository ReferralRepository { get; }

        

        Boolean Commit();
    }
}
