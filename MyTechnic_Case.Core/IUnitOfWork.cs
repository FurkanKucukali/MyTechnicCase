using MyTechnic_Case.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.Core
{
    public interface IUnitOfWork:IDisposable
    {
        
        ITeamRepository Teams { get; }
        IShiftRepository Shifts { get; }   
        IShiftTeamRepository ShiftTeams { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();

    }
}
