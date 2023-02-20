using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechnic_Case.Core.Models
{
    public class ShiftTeam:EntitiyBase
    {
        public Guid TeamID { get; set; }
        public Team Team { get; set; } 
        public Guid ShiftID { get; set; }  
        public Shift Shift { get; set; }    
    }
}
