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
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
      

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

       

        public async Task<Team> Create(Team entity)
        {
            await _unitOfWork.Teams.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(Team entity)
        {
            _unitOfWork.Teams.Remove(entity);

            await _unitOfWork.CommitAsync();
        }

    

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _unitOfWork.Teams.GetAllAsync();
        }

        public async Task<IEnumerable<Team>> GetAll(Expression<Func<Team, bool>> predicate)
        {
            return await _unitOfWork.Teams.Find(predicate);
        }

       

        public async Task<Team> GetById(Guid id)
        {
            
            var result = await _unitOfWork.Teams.Find(x => x.Id == id);

            return result.FirstOrDefault();
        } 

       
        public async Task Update(Team entity)
        {
            _unitOfWork.Teams.Update(entity);
            await _unitOfWork.CommitAsync();
        }

    }
}
