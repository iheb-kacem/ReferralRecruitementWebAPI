using Recruitement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        RecruitementContext DataContext { get; }
    }
}
