using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.Core.Models
{
    public class Team:EntitiyBase
    {
        public string TeamLeader { get; set; }
        public string TeamName { get; set; }
        ICollection<User> User { get; set; }


    }
}
