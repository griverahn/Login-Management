using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class RoleDTO
    {
        [Display(Name = "RoleId")]
        public int Id { get; set; }
        [Display(Name = "Role")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Enable")]
        public bool IsEnable { get; set; }

        public List<string> menuAccessItems { get; set; }
    }
}
