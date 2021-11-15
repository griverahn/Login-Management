using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.Entities
{
    public class RoleAccess
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string LevelName { get; set; }
        public int LevelOptionId { get; set; }
    }
}
