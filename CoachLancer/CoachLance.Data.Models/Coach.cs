using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachLance.Data.Models
{
    public class Coach : User
    {
        public virtual ICollection<Teams> Teams { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
