using MyTechnic_Case.Core;
using MyTechnic_Case.Core.Repositories;
using MyTechnic_Case.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.DataAcess
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly MyTechnic_CaseDbContext _context;
        
        private ShiftRepository _shiftRepository;
        private ShiftTeamRepository _shiftTeamRepository;
        private TeamRepository _teamRepository;
        private UserRepository _userRepository;

        public UnitofWork(MyTechnic_CaseDbContext context)
        {
            _context = context;
        }
       

        public ITeamRepository Teams => _teamRepository = _teamRepository ?? new TeamRepository(_context);

        public IShiftRepository Shifts => _shiftRepository = _shiftRepository ?? new ShiftRepository(_context);

        public IShiftTeamRepository ShiftTeams => _shiftTeamRepository = _shiftTeamRepository ?? new ShiftTeamRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            try
            {
				return await _context.SaveChangesAsync();
			}
			catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
