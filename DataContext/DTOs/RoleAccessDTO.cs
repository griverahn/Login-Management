using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class RoleAccessDTO
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "RoleId")]
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Menu Level")]
        public string LevelName { get; set; }
        [Required]
        [Display(Name = "Level Option Id")]
        public int LevelOptionId { get; set; }

        public List<string> menuAccessItems { get; set; }
    }
}
