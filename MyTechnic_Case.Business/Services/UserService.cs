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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<User> Create(User entity)
        {
            string password = entity.PasswordHash;
            entity.PasswordHash = null;
            var result = await _userManager.CreateAsync(entity, password);
            //await _unitOfWork.Users.AddAsync(entity);

            //await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(User entity)
        {
            _unitOfWork.Users.Remove(entity);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return await _unitOfWork.Users.Find(predicate);
        }

        public async Task<User> GetById(Guid id)
        {
            string _Id = id.ToString();
            var result = await _unitOfWork.Users.Find(x => x.Id == _Id);

            return result.FirstOrDefault();
        }

        public async Task<User> GetByWorkOrderNumber(string workordernumber)
        {
            string _Id = workordernumber;
            var result = await _unitOfWork.Users.Find(x => x.Id == _Id);
            return result.FirstOrDefault();
        }

       

        public async Task Update(User entity)
        {
            var user = await GetById(Guid.Parse(entity.Id));

          

            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
