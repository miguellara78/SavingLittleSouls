using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingLittleSouls.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
