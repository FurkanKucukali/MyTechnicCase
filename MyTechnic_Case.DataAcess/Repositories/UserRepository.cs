﻿using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.DataAcess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyTechnic_CaseDbContext context)
            : base(context)
        {

        }
    }
}
