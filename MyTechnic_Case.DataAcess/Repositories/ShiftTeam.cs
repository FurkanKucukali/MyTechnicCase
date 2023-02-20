using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.DataAcess.Repositories
{
    public class ShiftTeamRepository : Repository<ShiftTeam>, IShiftTeamRepository
    {
        public ShiftTeamRepository(MyTechnic_CaseDbContext context)
            : base(context)
        {

        }
    }
}
