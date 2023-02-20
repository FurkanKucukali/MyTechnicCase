using Microsoft.AspNetCore.Identity;
using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;
using MyTechnic_Case.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyTechnic_Case.Business.Services
{

    public class ShiftTeamService : IShiftTeamService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ShiftTeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        public async Task<ShiftTeam> Create(ShiftTeam entity)
        {
            await _unitOfWork.ShiftTeams.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(ShiftTeam entity)
        {
            _unitOfWork.ShiftTeams.Remove(entity);

            await _unitOfWork.CommitAsync();
        }



        public async Task<IEnumerable<ShiftTeam>> GetAll()
        {
            return await _unitOfWork.ShiftTeams.GetAllAsync();
        }

        public async Task<IEnumerable<ShiftTeam>> GetAll(Expression<Func<ShiftTeam, bool>> predicate)
        {
            return await _unitOfWork.ShiftTeams.Find(predicate);
        }

      

        public async Task<ShiftTeam> GetById(Guid id)
        {

            var result = await _unitOfWork.ShiftTeams.Find(x => x.Id == id);

            return result.FirstOrDefault();
        }


        public async Task Update(ShiftTeam entity)
        {
            var shiftteam = await GetById(entity.Id);



            _unitOfWork.ShiftTeams.Update(shiftteam);
            await _unitOfWork.CommitAsync();
        }

    }
}
