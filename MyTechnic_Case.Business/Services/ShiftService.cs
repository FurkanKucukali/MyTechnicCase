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

    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ShiftService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        public async Task<Shift> Create(Shift entity)
        {
            await _unitOfWork.Shifts.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(Shift entity)
        {
            _unitOfWork.Shifts.Remove(entity);

            await _unitOfWork.CommitAsync();
        }



        public async Task<IEnumerable<Shift>> GetAll()
        {
            return await _unitOfWork.Shifts.GetAllAsync();
        }

        public async Task<IEnumerable<Shift>> GetAll(Expression<Func<Shift, bool>> predicate)
        {
            return await _unitOfWork.Shifts.Find(predicate);
        }



        public async Task<Shift> GetById(Guid id)
        {

            var result = await _unitOfWork.Shifts.Find(x => x.Id == id);

            return result.FirstOrDefault();
        }


        public async Task Update(Shift entity)
        {
            var shiftteam = await GetById(entity.Id);



            _unitOfWork.Shifts.Update(shiftteam);
            await _unitOfWork.CommitAsync();
        }

    }
}
